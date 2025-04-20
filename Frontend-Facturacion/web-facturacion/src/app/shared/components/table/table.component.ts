import {Component, EventEmitter, Input, Output, ViewChild} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import {Cabecera} from '../../../core/models/cabecera.interface';
import {ConfiguracionTabla} from '../../../core/models/configuracion-tabla.interface';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrl: './table.component.scss'
})
export class TableComponent {
  @Input() respuesta: any;
  @Input() cabeceras: Cabecera[] = [];
  @Output() cambioPagina = new EventEmitter<ConfiguracionTabla>();
  @Output() editar = new EventEmitter<any>();
  @Output() eliminar = new EventEmitter<any>();
  @Output() cambiarBusqueda = new EventEmitter<any>();
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  displayedColumns: string[] = [];
  datos = new MatTableDataSource<any>([]);
  peticionConsultaDatos: ConfiguracionTabla = {
    numeroPagina: 1,
    textoBusqueda: ''
  }

  /*
  * Metodo que carga la tabla al detectar cambios
  */
  ngOnChanges() {
    if (this.respuesta.datos) {
      this.displayedColumns = [...this.cabeceras.map(c => c.nombre), 'acciones'];
      this.datos = new MatTableDataSource(this.respuesta.datos);
    }
  }

  /*
  * Metodo que dispara el evento padre para editar
  */
  eventoEditar(row: any) {
    this.editar.emit(row);
  }

  /*
  * Metodo que dispara el evento padre para eliminar
  */
  eventoEliminar(row: any) {
    this.eliminar.emit(row);
  }

  /*
  * Metodo maestro para cambiar de pagina o buscar algun item en la tabla
  */
  cambioPaginaBusqueda(event: any) {
    this.peticionConsultaDatos.numeroPagina = event.pageIndex + 1;
    this.cambioPagina.emit(this.peticionConsultaDatos);
  }

  /*
  * Metodo que permite buscar un item en la tabla se ejecuta en cada busqueda
  */
  buscar() {
    this.peticionConsultaDatos.numeroPagina = 1;
    this.cambiarBusqueda.emit(this.peticionConsultaDatos);
  }
}
