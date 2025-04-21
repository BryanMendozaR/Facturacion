import {Component, EventEmitter, Input, Output, ViewChild} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import {AccionTabla} from '../../../core/models/acciones-tabla.interface';
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
  @Input() accionesDisponibles: AccionTabla[] = [];
  @Output() cambioPagina = new EventEmitter<ConfiguracionTabla>();
  @Output() cambiarBusqueda = new EventEmitter<any>();
  @Output() accionEjecutada = new EventEmitter<{accion: string, row: any}>();
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
    console.log(this.respuesta.datos);
    if (this.respuesta.datos) {
      this.displayedColumns = [...this.cabeceras.map(c => c.nombre), 'acciones'];
      this.datos = new MatTableDataSource(this.respuesta.datos);
    }
  }

  /*
  * Metodo que envia la accion y la fila para que el componente padre gestione esa accion
  */
  ejecutarAccion(accion: string, row: any) {
    this.accionEjecutada.emit({accion, row});
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
