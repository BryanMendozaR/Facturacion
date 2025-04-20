import {Component, OnInit} from '@angular/core';
import {Cabecera} from '../../../../core/models/cabecera.interface';
import {ConfiguracionTabla} from '../../../../core/models/configuracion-tabla.interface';
import {DatosProductos} from '../../../../core/models/datos-producto.interface';
import {ProductoService} from '../../../../data/services/producto.service';

@Component({
  selector: 'app-gestion-producto',
  templateUrl: './gestion-producto.component.html',
  styleUrl: './gestion-producto.component.scss'
})
export class GestionProductoComponent implements OnInit {
  public productos: DatosProductos[] = [];
  headers: Cabecera[] = [
    {nombre: 'codigo', texto: 'Código'},
    {nombre: 'nombre', texto: 'Producto'},
    {nombre: 'estado', texto: 'Estado', cell: row => row.estado ? 'Activo' : 'Inactivo'},
    {nombre: 'agregado', texto: 'Agregado', cell: row => new Date(row.fecha).toLocaleDateString()},
    {nombre: 'precio', texto: 'Precio', cell: row => `$${row.precio.toFixed(2)}`}
  ];

  constructor(private productoService: ProductoService) { }

  ngOnInit(): void {
    this.consultarProductos(1, '');
  }

  consultarProductos(pagina: number, texto: string): void {
    this.productoService.filtrarProducto(texto, pagina).subscribe(producto => this.productos = producto)
  }

  buscarCambiarPagina(datos: ConfiguracionTabla) {
    this.consultarProductos(datos.numeroPagina, datos.textoBusqueda);
  }

  editar(producto: any) {
    console.log('Editar', producto);
  }

  eliminar(producto: any) {
    console.log('Eliminar', producto);
  }

  crear() {
    console.log('Crear nuevo producto');
  }

}
