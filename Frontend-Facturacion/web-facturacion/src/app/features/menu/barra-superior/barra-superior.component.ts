import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-barra-superior',
  templateUrl: './barra-superior.component.html',
  styleUrl: './barra-superior.component.scss'
})
export class BarraSuperiorComponent implements OnInit {
  usuario: string = '';

  /*
  * Constructor de la clase se lo utiliza para la inyeccion de dependencias
  */
  constructor(private router: Router) { }

  /*
  * Metodo que se ejecuta despues de inicializar la vista
  * Se establece un titulo para la barra
  */
  ngOnInit() {
    if (localStorage.getItem('codigo') && localStorage.getItem('nombre') && localStorage.getItem('usuario') && localStorage.getItem('correo')) {
      this.usuario = localStorage.getItem('usuario')!;
    } else {
      this.router.navigate(['/facturacion/login']);
    }

  }

  /*
  * Metodo para cambiar de pagina
  * @param {ruta} ruta a la cual se desea cambiar
  */
  cambiarContenido(ruta: string) {
    this.router.navigate([ruta]);
  }

  /*
  * Metodo para activar el boton segun la pagina donde se encuentra
  * @param {ruta} ruta actual
  */
  rutaActiva(ruta: string): boolean {
    return this.router.url === ruta;
  }

  /*
  * Metodo para cerrar la sesion del usuario
  */
  cerrarSesion() {
    this.router.navigate(['/facturacion/login']);
  }
}
