import {Component, OnInit} from '@angular/core';
import {Botones} from '../../../../core/models/botones-barra.interface';
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
  titulo: string = 'Productos';
  botones: Botones[] = [];
  headers: Cabecera[] = [
    {nombre: 'codigo', texto: 'Código'},
    {nombre: 'nombre', texto: 'Producto'},
    {nombre: 'estado', texto: 'Estado', cell: row => row.estado ? 'Activo' : 'Inactivo'},
    {nombre: 'agregado', texto: 'Agregado', cell: row => new Date(row.fecha).toLocaleDateString()},
    {nombre: 'precio', texto: 'Precio', cell: row => `$${row.precio.toFixed(2)}`}
  ];

  /*
  * Constructor de la clase se lo utiliza para la inyeccion de dependencias
  */
  constructor(private productoService: ProductoService) { }

  /*
  * Metodo que se ejecuta despues de inicializar la vista
  * Se llama al metodo de carga de productos y inicializa los valores de la barra de productos
  */
  ngOnInit(): void {
    this.inicializarBotones();
    this.consultarProductos(1, '');
  }

  /*
  * Metodo que inicializa los valores del componente de la barra de productos
  */
  private inicializarBotones() {
    this.botones = [
      {
        etiqueta: 'NUEVO',
        icono: 'fas fa-plus',
        clasesCss: 'btn-success',
        tipoAccion: () => this.crear(),
      },
    ];
  }

  /*
  * Metodo para consultar los productos
  * @param {pagina} pagina de la tabla en la cual se encuentra el usuario
  * @param {textoFiltro} string con el nombre o codigo del producto a buscar
  */
  consultarProductos(pagina: number, textoFiltro: string): void {
    this.productoService.filtrarProducto(textoFiltro, pagina).subscribe(producto => this.productos = producto)
  }

  /*
  * Metodo para cargar los productos cuando se manda a realizar una busqueda o se cambia de pagina en la tabla
  * @param {datos} datos  de filtrado
  */
  buscarCambiarPagina(datos: ConfiguracionTabla) {
    this.consultarProductos(datos.numeroPagina, datos.textoBusqueda);
  }

  /*
  * Metodo para editar un producto
  * @param {producto} fila seleccionada
  */
  editar(producto: any) {
    console.log('Editar', producto);
  }

  /*
  * Metodo para eliminar un producto
  * @param {producto} fila seleccionada
  */
  eliminar(producto: any) {
    console.log('Eliminar', producto);
  }

  /*
  * Metodo para insertar un nuevo producto
  */
  crear() {
    console.log('Crear nuevo producto');
  }

}
