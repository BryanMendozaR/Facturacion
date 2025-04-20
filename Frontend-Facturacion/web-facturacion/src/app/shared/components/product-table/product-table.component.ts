import {Component, EventEmitter, Input, Output, ViewChild} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import {Cabecera} from '../../../core/models/cabecera.interface';

@Component({
  selector: 'app-product-table',
  templateUrl: './product-table.component.html',
  styleUrl: './product-table.component.scss'
})
export class ProductTableComponent {
  @Input() respuesta: any;
  @Input() cabeceras: Cabecera[] = [];
  @Output() cambioPagina = new EventEmitter<number>();
  @Output() edit = new EventEmitter<any>();
  @Output() delete = new EventEmitter<any>();
  @Output() create = new EventEmitter<void>();

  displayedColumns: string[] = [];
  datos = new MatTableDataSource<any>([]);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngOnChanges() {
    console.log("Tabla de datos:", this.respuesta);
    if (this.respuesta.datos) {
      this.displayedColumns = [...this.cabeceras.map(c => c.nombre), 'acciones'];
      this.datos = new MatTableDataSource(this.respuesta.datos);
    }
  }

  onEdit(row: any) {
    this.edit.emit(row);
  }

  onDelete(row: any) {
    this.delete.emit(row);
  }

  onCreate() {
    this.create.emit();
  }

  onPageEvent(event: any) {
    this.cambioPagina.emit(event.pageIndex + 1);
  }
}
