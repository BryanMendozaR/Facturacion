import {Component, Input, OnInit} from '@angular/core';
import {Botones} from '../../../core/models/botones-barra.interface';

@Component({
  selector: 'app-barra',
  templateUrl: './barra.component.html',
  styleUrl: './barra.component.scss'
})
export class BarraComponent implements OnInit {
  @Input() titulo: string = '';
  @Input() elementos: Botones[] = [];

  /*
  * Metodo que se ejecuta despues de inicializar la vista
  */
  ngOnInit(): void {
    if (!this.elementos) this.elementos = [];
    this.elementos.forEach((it: any) => {
      it.visible = it.visible === undefined ? true : it.visible
    });
  }
}
