import {Component, inject, signal} from '@angular/core';
import {UntypedFormBuilder, UntypedFormGroup, Validators} from '@angular/forms';
import {Router} from '@angular/router';
import {AutenticacionService} from '../../../core/services/autentication.service';
import {ServicioMensaje} from '../../../core/services/message.service';

@Component({
  selector: 'app-inicio-sesion',
  templateUrl: './inicio-sesion.component.html',
  styleUrl: './inicio-sesion.component.scss'
})

export class InicioSesionComponent {
  private formBuilder = inject(UntypedFormBuilder);
  formularioInicioSesion: UntypedFormGroup = this.formBuilder.group({});
  submitted: any = false;
  error: any = '';
  returnUrl: string = "";
  year: number = new Date().getFullYear();
  hide = signal(true);
  clickEvent(event: MouseEvent) {
    this.hide.set(!this.hide());
    event.stopPropagation();
  }

  /*
  * Constructor de la clase se lo utiliza para la inyeccion de dependencias
  */
  constructor(private router: Router, private autenticacionService: AutenticacionService, private mensaje: ServicioMensaje) { }

  /*
  * Metodo que se ejecuta despues de inicializar la vista
  * Se inicializan los validadores del formulario
  */
  ngOnInit(): void {
    const usuario = '';
    const contrasena = '';

    this.formularioInicioSesion = this.formBuilder.group({
      usuario: [usuario, [Validators.required]],
      contrasena: [contrasena, [Validators.required]],
    });
  }

  /*
  * Metodo para obtener los controles del formulario
  */
  get formulario() {return this.formularioInicioSesion.controls;}

  /*
  * Metodo para autenticar al usuario
  */
  enviarFormulario() {
    const usuario = this.formularioInicioSesion.get('usuario')?.value;
    const contrasena = this.formularioInicioSesion.get('contrasena')?.value;
    this.autenticacionService.iniciarSesion(usuario, contrasena).subscribe({
      next: (respuesta) => {
        if (respuesta.inicio) {
          this.router.navigate(['/facturacion/inicio']);
        } else {
          this.mensaje.growl.error(' Usuario / Contraseña Inválida.');
        }
      },
      error: (err) => {
        this.error = 'Error en la autenticación';
        console.error(err);
      }
    });
  }
}
