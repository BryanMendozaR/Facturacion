import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {catchError, map, Observable, throwError} from 'rxjs';
import {environments} from '../../../environments/environments';
import {DatosProductos} from '../../core/models/datos-producto.interface';
import {EditarProducto} from '../../core/models/editar-producto.interface';
import {Respuesta} from '../../core/models/respuesta.interface';

@Injectable({providedIn: 'root'})
export class ProductoService {

    /*
    * Obtenemos la url base de nuestro archivo de variables
    */
    private apiUrl = environments.Url;

    /*
    * Constructor de la clase se lo utiliza para la inyeccion de dependencias
    */
    constructor(private httpClient: HttpClient) { }

    /*
    * Metodo para consultar los productos
    * @param {pagina} numero de pagina donde se encuentra el usuario en la tabla
    */
    consultarProductos(pagina: number): Observable<DatosProductos[]> {
        console.log("entro al servicio");
        return this.httpClient.get<Respuesta<DatosProductos[]>>(`${this.apiUrl}/Producto/Consultar/${pagina}`).pipe(
            map((respuesta) => {
                console.log(respuesta);
                if (respuesta.exito) {
                    return respuesta.data;
                } else {
                    throw new Error(respuesta.mensaje || 'Error al consultar productos');
                }
            }),
            catchError((error) => {
                console.error('Error interno al consultar productos:', error);
                return throwError(() => new Error('Error interno al consultar productos'));
            })
        );
    }

    /*
    * Metodo para consultar los productos segun parametros de filtrado
    * @param {pagina} numero de pagina donde se encuentra el usuario en la tabla
    * @param {filtro} texto digitado por el usuario con el cual se va a realizar la consulta
    */
    filtrarProducto(filtro: string, pagina: number): Observable<DatosProductos[]> {
        console.log("entro al servicio");
        return this.httpClient.get<Respuesta<DatosProductos[]>>(`${this.apiUrl}/Producto/Filtrar/${pagina}/${filtro}`).pipe(
            map((respuesta) => {
                console.log(respuesta);
                if (respuesta.exito) {
                    return respuesta.data;
                } else {
                    throw new Error(respuesta.mensaje || 'Error al consultar productos');
                }
            }),
            catchError((error) => {
                console.error('Error interno al consultar productos:', error);
                return throwError(() => new Error('Error interno al consultar productos'));
            })
        );
    }

    /*
    * Metodo para editar el producto
    * @param {datosProducto} datos del producto editado
    */
    editarProducto(datosProducto: EditarProducto): Observable<boolean> {
        console.log("entro al servicio");
        return this.httpClient.put<Respuesta<DatosProductos[]>>(`${this.apiUrl}/Producto/Actualizar/Datos`, datosProducto).pipe(
            map((respuesta) => {
                return respuesta.exito;
            }),
            catchError((error) => {
                console.error('Error interno al editar el producto:', error);
                return throwError(() => new Error('Error interno al editar el producto'));
            })
        );
    }

    /*
   * Metodo para eliminar el producto
   * @param {identificador} identificador del producto
   */
    eliminarProducto(identificador: number): Observable<boolean> {
        return this.httpClient.delete<Respuesta<DatosProductos[]>>(`${this.apiUrl}/Producto/Eliminar/${identificador}`).pipe(
            map((respuesta) => {
                console.log(respuesta);
                if (respuesta.exito) {
                    return respuesta.exito;
                } else {
                    throw new Error(respuesta.mensaje || 'Error al eliminar el producto');
                }
            }),
            catchError((error) => {
                console.error('Error interno al eliminar el producto:', error);
                return throwError(() => new Error('Error interno al eliminar el producto'));
            })
        );
    }
}