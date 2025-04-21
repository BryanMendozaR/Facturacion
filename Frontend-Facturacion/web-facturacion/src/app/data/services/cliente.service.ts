import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {catchError, map, Observable, throwError} from 'rxjs';
import {environments} from '../../../environments/environments';
import {DatosClientes} from '../../core/models/datos-cliente.interface';
import {EditarCliente} from '../../core/models/editar-cliente.interface';
import {AgregarCliente} from '../../core/models/insertar-cliente.interface';
import {Respuesta} from '../../core/models/respuesta.interface';

@Injectable({providedIn: 'root'})
export class ClienteService {

    /*
    * Obtenemos la url base de nuestro archivo de variables
    */
    private apiUrl = environments.Url;

    /*
    * Constructor de la clase se lo utiliza para la inyeccion de dependencias
    */
    constructor(private httpClient: HttpClient) { }

    /*
    * Metodo para consultar los clientes segun parametros de filtrado
    * @param {pagina} numero de pagina donde se encuentra el usuario en la tabla
    * @param {filtro} texto digitado por el usuario con el cual se va a realizar la consulta
    */
    filtrarCliente(filtro: string, pagina: number): Observable<DatosClientes[]> {
        return this.httpClient.get<Respuesta<DatosClientes[]>>(`${this.apiUrl}/Cliente/Filtrar/${pagina}/${filtro}`).pipe(
            map((respuesta) => {
                if (respuesta.exito) {
                    return respuesta.data;
                } else {
                    throw new Error(respuesta.mensaje || 'Error al consultar clientes');
                }
            }),
            catchError((error) => {
                console.error('Error interno al consultar clientes:', error);
                return throwError(() => new Error('Error interno al consultar clientes'));
            })
        );
    }

    /*
    * Metodo para editar los datos del cliente
    * @param {datosCliente} datos del cliente editado
    */
    editarCliente(datosCliente: EditarCliente): Observable<boolean> {
        return this.httpClient.put<Respuesta<[]>>(`${this.apiUrl}/Cliente/Actualizar/Datos`, datosCliente).pipe(
            map((respuesta) => {
                return respuesta.exito;
            }),
            catchError((error) => {
                console.error('Error interno al editar el cliente:', error);
                return throwError(() => new Error('Error interno al editar el cliente'));
            })
        );
    }

    /*
   * Metodo para eliminar el cliente
   * @param {identificacion} identificacion del cliente
   */
    eliminarCliente(identificacion: string): Observable<boolean> {
        return this.httpClient.delete<Respuesta<[]>>(`${this.apiUrl}/Cliente/Eliminar/${identificacion}`).pipe(
            map((respuesta) => {
                if (respuesta.exito) {
                    return respuesta.exito;
                } else {
                    throw new Error(respuesta.mensaje || 'Error al eliminar el cliente');
                }
            }),
            catchError((error) => {
                console.error('Error interno al eliminar el cliente:', error);
                return throwError(() => new Error('Error interno al eliminar el cliente'));
            })
        );
    }

    /*
    * Metodo para agregar un cliente
    * @param {identificador} identificador del cliente
    */
    agregarCliente(cliente: AgregarCliente): Observable<boolean> {
        return this.httpClient.post<Respuesta<[]>>(`${this.apiUrl}/Cliente/Crear`, cliente).pipe(
            map((respuesta) => {
                if (respuesta.exito) {
                    return respuesta.exito;
                } else {
                    throw new Error(respuesta.mensaje || 'Error al agregar el cliente');
                }
            }),
            catchError((error) => {
                console.error('Error interno al agregar el cliente:', error);
                return throwError(() => new Error('Error interno al agregar el cliente'));
            })
        );
    }
}