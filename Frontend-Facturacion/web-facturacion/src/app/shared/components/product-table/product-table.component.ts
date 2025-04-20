import {Component, EventEmitter, Input, Output, ViewChild} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import {Cabecera} from '../../../core/models/cabecera.interface';
import {ConfiguracionTabla} from '../../../core/models/configuracion-tabla.interface';

@Component({
  selector: 'app-product-table',
  templateUrl: './product-table.component.html',
  styleUrl: './product-table.component.scss'
})
export class ProductTableComponent {
  @Input() respuesta: any;
  @Input() cabeceras: Cabecera[] = [];
  @Output() cambioPagina = new EventEmitter<ConfiguracionTabla>();
  @Output() editar = new EventEmitter<any>();
  @Output() eliminar = new EventEmitter<any>();
  @Output() cambiarBusqueda = new EventEmitter<any>();

  peticionConsultaDatos: ConfiguracionTabla = {
    numeroPagina: 1,
    textoBusqueda: ''
  }

  displayedColumns: string[] = [];
  datos = new MatTableDataSource<any>([]);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngOnChanges() {
    if (this.respuesta.datos) {
      this.displayedColumns = [...this.cabeceras.map(c => c.nombre), 'acciones'];
      this.datos = new MatTableDataSource(this.respuesta.datos);
    }
  }

  eventoEditar(row: any) {
    this.editar.emit(row);
  }

  eventoEliminar(row: any) {
    this.eliminar.emit(row);
  }

  // Metodo para cambio de pagina
  cambioPaginaBusqueda(event: any) {
    this.peticionConsultaDatos.numeroPagina = event.pageIndex + 1;
    this.cambioPagina.emit(this.peticionConsultaDatos);
  }

  // Metodo de busqueda
  buscar() {
    this.peticionConsultaDatos.numeroPagina = 1;
    this.cambiarBusqueda.emit(this.peticionConsultaDatos);
  }
}
