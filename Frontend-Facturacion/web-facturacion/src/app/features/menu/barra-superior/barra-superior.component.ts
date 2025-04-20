import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-barra-superior',
  templateUrl: './barra-superior.component.html',
  styleUrl: './barra-superior.component.scss'
})
export class BarraSuperiorComponent implements OnInit {
  usuario: string = '';

  constructor(private router: Router) { }

  ngOnInit() {
    this.usuario = "admin";
  }

  cambiarContenido(ruta: string) {
    this.router.navigate([ruta]);
  }

  rutaActiva(ruta: string): boolean {
    return this.router.url === ruta;
  }

  cerrarSesion() {
    this.router.navigate(['/facturacion/login']);
  }
}
