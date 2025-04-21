import {Component} from '@angular/core';
import {Validators} from '@angular/forms';
import {MatDialog} from '@angular/material/dialog';
import {Botones} from '../../../core/models/botones-barra.interface';
import {Cabecera} from '../../../core/models/cabecera.interface';
import {ConfiguracionTabla} from '../../../core/models/configuracion-tabla.interface';
import {DatosClientes} from '../../../core/models/datos-cliente.interface';
import {EditarCliente} from '../../../core/models/editar-cliente.interface';
import {AgregarCliente} from '../../../core/models/insertar-cliente.interface';
import {ServicioMensaje} from '../../../core/services/message.service';
import {ClienteService} from '../../../data/services/cliente.service';
import {ModalComponent} from '../../../shared/components/modal/modal.component';

@Component({
  selector: 'app-gestion-cliente',
  templateUrl: './gestion-cliente.component.html',
  styleUrl: './gestion-cliente.component.scss'
})
export class GestionClienteComponent {
  public clientes: DatosClientes[] = [];
  titulo: string = 'Clientes';
  botones: Botones[] = [];
  clienteIdentificacion: string = '';
  clienteNombre: string = '';
  modalConfirmacion = false;
  headers: Cabecera[] = [
    {nombre: 'identificacion', texto: 'Identificacion'},
    {nombre: 'nombre', texto: 'Nombre'},
    {nombre: 'telefono', texto: 'Teléfono'},
    {nombre: 'correo', texto: 'Correo'},
    {nombre: 'direccion', texto: 'Direccion'},
  ];

  /*
  * Constructor de la clase se lo utiliza para la inyeccion de dependencias
  */
  constructor(private clienteService: ClienteService, private dialog: MatDialog, private mensaje: ServicioMensaje) { }

  /*
  * Metodo que se ejecuta despues de inicializar la vista
  * Se llama al metodo de carga de productos y inicializa los valores de la barra de productos
  */
  ngOnInit(): void {
    this.inicializarBotones();
    this.consultarClientes(1, '');
  }

  /*
  * Metodo que inicializa los valores del componente de la barra de productos
  */
  private inicializarBotones() {
    this.botones = [
      {
        etiqueta: 'NUEVO',
        icono: 'add',
        clasesCss: 'btn-success',
        tipoAccion: () => this.crear(),
      },
    ];
  }

  /*
  * Metodo para consultar los clientes
  * @param {pagina} pagina de la tabla en la cual se encuentra el usuario
  * @param {textoFiltro} string con el nombre o codigo del producto a buscar
  */
  consultarClientes(pagina: number, textoFiltro: string): void {
    this.clienteService.filtrarCliente(textoFiltro, pagina).subscribe(cliente => this.clientes = cliente)
  }

  /*
  * Metodo para cargar los productos cuando se manda a realizar una busqueda o se cambia de pagina en la tabla
  * @param {datos} datos  de filtrado
  */
  buscarCambiarPagina(datos: ConfiguracionTabla) {
    this.consultarClientes(datos.numeroPagina, datos.textoBusqueda);
  }

  /*
  * Metodo para editar un producto
  * @param {producto} fila seleccionada
  */
  editar(cliente: any) {
    const campos = [
      {nombre: 'nombre', valor: cliente.nombre, tipo: 'text', validaciones: [Validators.required]},
      {nombre: 'telefono', valor: cliente.telefono, tipo: 'text', validaciones: [Validators.required]},
      {nombre: 'correo', valor: cliente.correo, tipo: 'text', validaciones: [Validators.required, Validators.email]},
      {nombre: 'direccion', valor: cliente.direccion, tipo: 'text', validaciones: [Validators.required]},
      {
        nombre: 'estado',
        valor: cliente.estado ? 'Activo' : 'Inactivo',
        tipo: 'select',
        opciones: ['Activo', 'Inactivo'],
        validaciones: []
      }
    ];

    const dialogRef = this.dialog.open(ModalComponent, {
      width: '500px',
      data: {titulo: 'Editar Cliente', campos},
      disableClose: true
    });

    // Accedemos al componente del modal para suscribirnos al evento
    const instance = dialogRef.componentInstance;

    instance.onGuardar.subscribe((formValue: any) => {
      const clienteEditado: EditarCliente = {
        identificacion: cliente.identificacion,
        nombre: formValue.nombre,
        correo: formValue.correo,
        direccion: formValue.direccion,
        telefono: formValue.telefono,
        estado: formValue.estado === 'Activo' ? true : false
      };

      this.clienteService.editarCliente(clienteEditado).subscribe({
        next: (respuesta) => {
          if (respuesta) {
            this.consultarClientes(1, '');
            dialogRef.close();
            this.mensaje.growl.success('cliente modificado exitosamente');
          } else {
            this.mensaje.growl.error('No se pudo editar el cliente.');
          }
        },
        error: () => {
          this.mensaje.growl.error('Error al editar el cliente.');
        }
      });
    });
  }

  /*
  * Metodo para eliminar un producto de la tabla
  * @param {cliente} fila seleccionada
  */
  eliminar(cliente: any) {
    this.clienteIdentificacion = cliente.identificacion;
    this.clienteNombre = cliente.nombre;
    this.modalConfirmacion = true;
  }

  /*
  * Metodo para eliminar un cliente de la tabla despues de que el usuario confirme la eliminacion
  */
  confirmarEliminacion() {
    this.clienteService.eliminarCliente(this.clienteIdentificacion).subscribe(() => {
      this.consultarClientes(1, '');
      this.cerrarModalConfirmacion();
      this.mensaje.growl.success('cliente eliminado exitosamente');
    });
  }

  /*
  * Metodo para cancelar la eliminacion del producto
  */
  cerrarModalConfirmacion() {
    this.modalConfirmacion = false;
    this.clienteIdentificacion = '';
  }

  /*
  * Metodo para insertar un nuevo producto
  */
  crear() {
    const campos = [
      {
        nombre: 'identificacion', valor: '', tipo: 'text', validaciones: [Validators.required, Validators.minLength(10),
        Validators.maxLength(13),
        Validators.pattern(/^\d+$/)]
      },
      {nombre: 'nombre', valor: '', tipo: 'text', validaciones: [Validators.required]},
      {nombre: 'telefono', valor: '', tipo: 'text', validaciones: [Validators.required]},
      {nombre: 'correo', valor: '', tipo: 'text', validaciones: [Validators.required, Validators.email]},
      {nombre: 'direccion', valor: '', tipo: 'text', validaciones: []}
    ];

    const dialogRef = this.dialog.open(ModalComponent, {
      width: '500px',
      data: {titulo: 'Crear Cliente', campos},
      disableClose: true
    });

    // Accedemos al componente del modal para suscribirnos al evento
    const instance = dialogRef.componentInstance;

    instance.onGuardar.subscribe((formValue: any) => {
      const cliente: AgregarCliente = {
        identificacion: formValue.identificacion,
        nombre: formValue.nombre,
        telefono: formValue.telefono,
        correo: formValue.correo,
        direccion: formValue.direccion,
      };

      this.clienteService.agregarCliente(cliente).subscribe({
        next: (respuesta) => {
          if (respuesta) {
            this.consultarClientes(1, '');
            dialogRef.close();
            this.mensaje.growl.success('Cliente agregado exitosamente');
          } else {
            this.mensaje.growl.error('No se pudo agregar el cliente.');
          }
        },
        error: () => {
          this.mensaje.growl.error('Error al agregar el cliente.');
        }
      });
    });
  }
}
