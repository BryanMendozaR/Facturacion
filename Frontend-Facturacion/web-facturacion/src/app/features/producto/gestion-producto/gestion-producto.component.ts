import {Component, OnInit} from '@angular/core';
import {Validators} from '@angular/forms';
import {MatDialog} from '@angular/material/dialog';
import {AccionTabla} from '../../../core/models/acciones-tabla.interface';
import {Botones} from '../../../core/models/botones-barra.interface';
import {Cabecera} from '../../../core/models/cabecera.interface';
import {ConfiguracionTabla} from '../../../core/models/configuracion-tabla.interface';
import {DatosProductos} from '../../../core/models/datos-producto.interface';
import {EditarProducto} from '../../../core/models/editar-producto.interface';
import {AgregarProducto} from '../../../core/models/insertar-producto.interface';
import {ServicioMensaje} from '../../../core/services/message.service';
import {ProductoService} from '../../../data/services/producto.service';
import {ModalComponent} from '../../../shared/components/modal/modal.component';

@Component({
  selector: 'app-gestion-producto',
  templateUrl: './gestion-producto.component.html',
  styleUrl: './gestion-producto.component.scss'
})
export class GestionProductoComponent implements OnInit {
  public productos: DatosProductos[] = [];
  titulo: string = 'Productos';
  botones: Botones[] = [];
  datosProducto: EditarProducto[] = [];
  productoIdentificador: number = 0;
  productoNombre: string = '';
  modalConfirmacion = false;
  headers: Cabecera[] = [
    {nombre: 'codigo', texto: 'Código'},
    {nombre: 'nombre', texto: 'Producto'},
    {nombre: 'estado', texto: 'Estado', cell: row => row.estado ? 'Activo' : 'Inactivo'},
    {nombre: 'agregado', texto: 'Agregado', cell: row => new Date(row.fecha).toLocaleDateString()},
    {nombre: 'precio', texto: 'Precio', cell: row => `$${row.precio.toFixed(2)}`}
  ];

  accionesResumen: AccionTabla[] = [
    {icono: 'edit', color: 'primary', accion: 'editar', tooltip: 'Editar item'},
    {icono: 'delete', color: 'warn', accion: 'eliminar', tooltip: 'Eliminar item'}
  ];

  /*
  * Constructor de la clase se lo utiliza para la inyeccion de dependencias
  */
  constructor(private productoService: ProductoService, private dialog: MatDialog, private mensaje: ServicioMensaje) { }

  /*
  * Metodo que se ejecuta despues de inicializar la vista
  * Se llama al metodo de carga de productos y inicializa los valores de la barra de productos
  */
  ngOnInit(): void {
    this.inicializarBotones();
    this.consultarProductos(1, '');
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
* Metodo para gestionar la accion que envia la tabla
* @param {evento} objeto donde esta la accion y los datos de la columna a afectar
*/
  manejarAccion(evento: {accion: string, row: any}) {
    switch (evento.accion) {
      case 'editar':
        this.editar(evento.row);
        break;
      case 'eliminar':
        this.eliminar(evento.row);
        break;
    }
  }

  /*
  * Metodo para consultar los productos
  * @param {pagina} pagina de la tabla en la cual se encuentra el usuario
  * @param {textoFiltro} string con el nombre o codigo del producto a buscar
  */
  consultarProductos(pagina: number, textoFiltro: string): void {
    this.productoService.filtrarProducto(textoFiltro, pagina).subscribe(producto => this.productos = producto)
  }

  /*
  * Metodo para cargar los productos cuando se manda a realizar una busqueda o se cambia de pagina en la tabla
  * @param {datos} datos  de filtrado
  */
  buscarCambiarPagina(datos: ConfiguracionTabla) {
    this.consultarProductos(datos.numeroPagina, datos.textoBusqueda);
  }

  /*
  * Metodo para editar un producto
  * @param {producto} fila seleccionada
  */
  editar(producto: any) {
    const campos = [
      {nombre: 'codigo', valor: producto.codigo, tipo: 'text', validaciones: [Validators.required]},
      {nombre: 'nombre', valor: producto.nombre, tipo: 'text', validaciones: [Validators.required]},
      {
        nombre: 'estado',
        valor: producto.estado ? 'Activo' : 'Inactivo',
        tipo: 'select',
        opciones: ['Activo', 'Inactivo'],
        validaciones: []
      },
      {nombre: 'precio', valor: producto.precio, tipo: 'number', validaciones: [Validators.required]}
    ];

    const dialogRef = this.dialog.open(ModalComponent, {
      width: '500px',
      data: {titulo: 'Editar Producto', campos},
      disableClose: true
    });

    // Accedemos al componente del modal para suscribirnos al evento
    const instance = dialogRef.componentInstance;

    instance.onGuardar.subscribe((formValue: any) => {
      const productoEditado: EditarProducto = {
        identificador: producto.identificador,
        codigo: formValue.codigo,
        nombre: formValue.nombre,
        precio: formValue.precio,
        estado: formValue.estado === 'Activo'
      };

      this.productoService.editarProducto(productoEditado).subscribe({
        next: (respuesta) => {
          if (respuesta) {
            this.consultarProductos(1, '');
            dialogRef.close();
            this.mensaje.growl.success('Producto modificado exitosamente');
          } else {
            this.mensaje.growl.error('No se pudo editar el producto.');
          }
        },
        error: () => {
          this.mensaje.growl.error('Error al editar el producto.');
        }
      });
    });
  }

  /*
  * Metodo para eliminar un producto de la tabla
  * @param {producto} fila seleccionada
  */
  eliminar(producto: any) {
    this.productoIdentificador = producto.identificador;
    this.productoNombre = producto.codigo;
    this.modalConfirmacion = true;
  }

  /*
  * Metodo para eliminar un producto de la tabla despues de que el usuario confirme la eliminacion
  */
  confirmarEliminacion() {
    this.productoService.eliminarProducto(this.productoIdentificador).subscribe(() => {
      this.consultarProductos(1, '');
      this.cerrarModalConfirmacion();
      this.mensaje.growl.success('Producto eliminado exitosamente');
    });
  }

  /*
  * Metodo para cancelar la eliminacion del producto
  */
  cerrarModalConfirmacion() {
    this.modalConfirmacion = false;
    this.productoIdentificador = 0;
  }

  /*
  * Metodo para insertar un nuevo producto
  */
  crear() {
    const campos = [
      {nombre: 'codigo', valor: '', tipo: 'text', validaciones: [Validators.required]},
      {nombre: 'nombre', valor: '', tipo: 'text', validaciones: [Validators.required]},
      {nombre: 'precio', valor: '', tipo: 'number', validaciones: [Validators.required]}
    ];

    const dialogRef = this.dialog.open(ModalComponent, {
      width: '500px',
      data: {titulo: 'Crear Producto', campos},
      disableClose: true
    });

    // Accedemos al componente del modal para suscribirnos al evento
    const instance = dialogRef.componentInstance;

    instance.onGuardar.subscribe((formValue: any) => {
      const producto: AgregarProducto = {
        codigo: formValue.codigo,
        nombre: formValue.nombre,
        precio: formValue.precio,
      };

      this.productoService.agregarProducto(producto).subscribe({
        next: (respuesta) => {
          if (respuesta) {
            this.consultarProductos(1, '');
            dialogRef.close();
            this.mensaje.growl.success('Producto agregado exitosamente');
          } else {
            this.mensaje.growl.error('No se pudo agregar el producto.');
          }
        },
        error: () => {
          this.mensaje.growl.error('Error al agregar el producto.');
        }
      });
    });
  }
}
