import {Component} from '@angular/core';
import {Validators} from '@angular/forms';
import {MatDialog} from '@angular/material/dialog';
import {AccionTabla} from '../../../core/models/acciones-tabla.interface';
import {ActualizarClave} from '../../../core/models/actualizar-clave.interface';
import {Botones} from '../../../core/models/botones-barra.interface';
import {Cabecera} from '../../../core/models/cabecera.interface';
import {ConfiguracionTabla} from '../../../core/models/configuracion-tabla.interface';
import {DatosUsuarios} from '../../../core/models/datos-usuario.interface';
import {EditarUsuario} from '../../../core/models/editar-usuario.interface';
import {AgregarUsuario} from '../../../core/models/insertar-usuario.interface';
import {ServicioMensaje} from '../../../core/services/message.service';
import {ValidatorsService} from '../../../core/services/validator.service';
import {UsuarioService} from '../../../data/services/usuario.service';
import {ModalComponent} from '../../../shared/components/modal/modal.component';

@Component({
  selector: 'app-gestion-usuario',
  templateUrl: './gestion-usuario.component.html',
  styleUrl: './gestion-usuario.component.scss'
})
export class GestionUsuarioComponent {
  public usuarios: DatosUsuarios[] = [];
  titulo: string = 'Usuarios';
  botones: Botones[] = [];
  datosProducto: EditarUsuario[] = [];
  usuarioCodigo: number = 0;
  usuario: string = '';
  modalConfirmacion = false;
  headers: Cabecera[] = [
    {nombre: 'codigo', texto: 'Código'},
    {nombre: 'nombre', texto: 'Nombres'},
    {nombre: 'usuario', texto: 'Usuario'},
    {nombre: 'agregado', texto: 'Agregado', cell: row => new Date(row.fecha).toLocaleDateString()},
  ];

  accionesResumen: AccionTabla[] = [
    {icono: 'edit', color: 'primary', accion: 'editar', tooltip: 'Editar item'},
    {icono: 'settings', color: 'secondary', accion: 'editar-password', tooltip: 'Editar Contraseña'},
    {icono: 'delete', color: 'warn', accion: 'eliminar', tooltip: 'Eliminar item'}
  ];

  /*
  * Constructor de la clase se lo utiliza para la inyeccion de dependencias
  */
  constructor(private usuarioService: UsuarioService, private dialog: MatDialog, private mensaje: ServicioMensaje, private validadorService: ValidatorsService) { }

  /*
  * Metodo que se ejecuta despues de inicializar la vista
  * Se llama al metodo de carga de productos y inicializa los valores de la barra de productos
  */
  ngOnInit(): void {
    this.inicializarBotones();
    this.consultarUsuarios(1, '');
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
      case 'editar-password':
        this.actualizarContrasenia(evento.row);
        break;
    }
  }

  /*
  * Metodo para consultar los usuarios
  * @param {pagina} pagina de la tabla en la cual se encuentra el usuario
  * @param {textoFiltro} string con el nombre o codigo del producto a buscar
  */
  consultarUsuarios(pagina: number, textoFiltro: string): void {
    this.usuarioService.filtrarUsuario(textoFiltro, pagina).subscribe(usuario => this.usuarios = usuario)
  }

  /*
  * Metodo para cargar los productos cuando se manda a realizar una busqueda o se cambia de pagina en la tabla
  * @param {datos} datos  de filtrado
  */
  buscarCambiarPagina(datos: ConfiguracionTabla) {
    this.consultarUsuarios(datos.numeroPagina, datos.textoBusqueda);
  }

  /*
  * Metodo para editar un producto
  * @param {producto} fila seleccionada
  */
  editar(usuario: any) {
    const campos = [
      {nombre: 'nombres', valor: usuario.nombre, tipo: 'text', validaciones: [Validators.required]},
      {nombre: 'usuario', valor: usuario.usuario, tipo: 'text', validaciones: [Validators.required]},
      {nombre: 'correo', valor: usuario.correo, tipo: 'text', validaciones: [Validators.required]}
    ];

    const dialogRef = this.dialog.open(ModalComponent, {
      width: '500px',
      data: {titulo: 'Editar Usuario', campos},
      disableClose: true
    });

    // Accedemos al componente del modal para suscribirnos al evento
    const instance = dialogRef.componentInstance;

    instance.onGuardar.subscribe((formValue: any) => {
      const usuarioEditado: EditarUsuario = {
        codigo: usuario.codigo,
        nombre: formValue.nombres,
        usuario: formValue.usuario,
        correo: formValue.correo
      };

      this.usuarioService.editarUsuario(usuarioEditado).subscribe({
        next: (respuesta) => {
          if (respuesta) {
            this.consultarUsuarios(1, '');
            dialogRef.close();
            this.mensaje.growl.success('Usuario modificado exitosamente');
          } else {
            this.mensaje.growl.error('No se pudo editar el usuario.');
          }
        },
        error: () => {
          this.mensaje.growl.error('Error al editar el usuario.');
        }
      });
    });
  }

  /*
  * Metodo para eliminar un producto de la tabla
  * @param {producto} fila seleccionada
  */
  eliminar(usuario: any) {
    this.usuarioCodigo = usuario.codigo;
    this.usuario = usuario.usuario;
    this.modalConfirmacion = true;
  }

  /*
  * Metodo para eliminar un producto de la tabla despues de que el usuario confirme la eliminacion
  */
  confirmarEliminacion() {
    this.usuarioService.eliminarUsuario(this.usuarioCodigo).subscribe(() => {
      this.consultarUsuarios(1, '');
      this.cerrarModalConfirmacion();
      this.mensaje.growl.success('Usuario eliminado exitosamente');
    });
  }

  /*
  * Metodo para cancelar la eliminacion del producto
  */
  cerrarModalConfirmacion() {
    this.modalConfirmacion = false;
    this.usuarioCodigo = 0;
  }

  /*
  * Metodo para cancelar la eliminacion del producto
  */
  actualizarContrasenia(usuario: any) {
    const campos = [
      {nombre: 'clave', valor: '', tipo: 'password', validaciones: [Validators.required]},
      {nombre: 'rclave', valor: '', tipo: 'password', validaciones: [Validators.required]}
    ];

    const dialogRef = this.dialog.open(ModalComponent, {
      width: '500px',
      data:
      {
        titulo: 'Actualizar Contraseña',
        campos: campos,
        validacionGrupo: this.validadorService.validacionCamposIguales('clave', 'rclave')
      },
      disableClose: true
    });

    // Accedemos al componente del modal para suscribirnos al evento
    const instance = dialogRef.componentInstance;

    instance.onGuardar.subscribe((formValue: any) => {
      const datos: ActualizarClave = {
        codigo: usuario.codigo,
        clave: formValue.clave
      };

      this.usuarioService.actualizarClaveUsuario(datos).subscribe({
        next: (respuesta) => {
          if (respuesta) {
            this.consultarUsuarios(1, '');
            dialogRef.close();
            this.mensaje.growl.success('Usuario modificado exitosamente');
          } else {
            this.mensaje.growl.error('No se pudo actualizar la clave del usuario.');
          }
        },
        error: () => {
          this.mensaje.growl.error('Error al actualizar la clave del usuario.');
        }
      });
    });
  }

  /*
  * Metodo para insertar un nuevo producto
  */
  crear() {
    const campos = [
      {nombre: 'nombres', valor: '', tipo: 'text', validaciones: [Validators.required]},
      {nombre: 'usuario', valor: '', tipo: 'text', validaciones: [Validators.required]},
      {nombre: 'correo', valor: '', tipo: 'text', validaciones: [Validators.required, Validators.email]},
      {nombre: 'clave', valor: '', tipo: 'password', validaciones: [Validators.required]},
      {nombre: 'rclave', valor: '', tipo: 'password', validaciones: [Validators.required]}
    ];

    const dialogRef = this.dialog.open(ModalComponent, {
      width: '500px',
      data: {
        titulo: 'Crear Usuario',
        campos: campos,
        validacionGrupo: this.validadorService.validacionCamposIguales('clave', 'rclave')
      },
      disableClose: true
    });

    // Accedemos al componente del modal para suscribirnos al evento
    const instance = dialogRef.componentInstance;

    instance.onGuardar.subscribe((formValue: any) => {
      const usuario: AgregarUsuario = {
        nombre: formValue.nombres,
        usuario: formValue.usuario,
        correo: formValue.correo,
        clave: formValue.clave,
      };

      this.usuarioService.agregarUsuario(usuario).subscribe({
        next: (respuesta) => {
          if (respuesta) {
            this.consultarUsuarios(1, '');
            dialogRef.close();
            this.mensaje.growl.success('Usuario agregado exitosamente');
          } else {
            this.mensaje.growl.error('No se pudo agregar el usuario.');
          }
        },
        error: () => {
          this.mensaje.growl.error('Error al agregar el usuario.');
        }
      });
    });
  }
}
