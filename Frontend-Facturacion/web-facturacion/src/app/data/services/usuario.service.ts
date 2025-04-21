import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {catchError, map, Observable, throwError} from 'rxjs';
import {environments} from '../../../environments/environments';
import {ActualizarClave} from '../../core/models/actualizar-clave.interface';
import {DatosUsuarios} from '../../core/models/datos-usuario.interface';
import {EditarUsuario} from '../../core/models/editar-usuario.interface';
import {AgregarUsuario} from '../../core/models/insertar-usuario.interface';
import {Respuesta} from '../../core/models/respuesta.interface';

@Injectable({providedIn: 'root'})
export class UsuarioService {

    /*
    * Obtenemos la url base de nuestro archivo de variables
    */
    private apiUrl = environments.Url;

    /*
    * Constructor de la clase se lo utiliza para la inyeccion de dependencias
    */
    constructor(private httpClient: HttpClient) { }

    /*
    * Metodo para consultar los usuarios segun parametros de filtrado
    * @param {pagina} numero de pagina donde se encuentra el usuario en la tabla
    * @param {filtro} texto digitado por el usuario con el cual se va a realizar la consulta
    */
    filtrarUsuario(filtro: string, pagina: number): Observable<DatosUsuarios[]> {
        return this.httpClient.get<Respuesta<DatosUsuarios[]>>(`${this.apiUrl}/Usuario/Filtrar/${pagina}/${filtro}`).pipe(
            map((respuesta) => {
                if (respuesta.exito) {
                    return respuesta.data;
                } else {
                    throw new Error(respuesta.mensaje || 'Error al consultar usuarios');
                }
            }),
            catchError((error) => {
                console.error('Error interno al consultar usuarios:', error);
                return throwError(() => new Error('Error interno al consultar usuarios'));
            })
        );
    }

    /*
    * Metodo para editar los datos del usuario
    * @param {datosCliente} datos del usuario editado
    */
    editarUsuario(datosUsuario: EditarUsuario): Observable<boolean> {
        return this.httpClient.put<Respuesta<[]>>(`${this.apiUrl}/Usuario/Actualizar/Datos`, datosUsuario).pipe(
            map((respuesta) => {
                return respuesta.exito;
            }),
            catchError((error) => {
                console.error('Error interno al editar el usuario:', error);
                return throwError(() => new Error('Error interno al editar el usuario'));
            })
        );
    }

    /*
    * Metodo para actualizar la clave del usuario
    * @param {datosCliente} datos del usuario
    */
    actualizarClaveUsuario(datosUsuario: ActualizarClave): Observable<boolean> {
        return this.httpClient.put<Respuesta<[]>>(`${this.apiUrl}/Usuario/Actualizar/Clave`, datosUsuario).pipe(
            map((respuesta) => {
                return respuesta.exito;
            }),
            catchError((error) => {
                console.error('Error interno al actualizar la clave del usuario:', error);
                return throwError(() => new Error('Error interno al actualizar la clave del usuario'));
            })
        );
    }

    /*
   * Metodo para eliminar el usuario
   * @param {codigo} Codigo del usuario
   */
    eliminarUsuario(codigo: number): Observable<boolean> {
        return this.httpClient.delete<Respuesta<[]>>(`${this.apiUrl}/Usuario/Eliminar/${codigo}`).pipe(
            map((respuesta) => {
                if (respuesta.exito) {
                    return respuesta.exito;
                } else {
                    throw new Error(respuesta.mensaje || 'Error al eliminar el usuario');
                }
            }),
            catchError((error) => {
                console.error('Error interno al eliminar el usuario:', error);
                return throwError(() => new Error('Error interno al eliminar el usuario'));
            })
        );
    }

    /*
    * Metodo para agregar un usuario
    * @param {identificador} identificador del usuario
    */
    agregarUsuario(usuario: AgregarUsuario): Observable<boolean> {
        console.log("Objeto enviado", usuario);
        return this.httpClient.post<Respuesta<[]>>(`${this.apiUrl}/Usuario/Crear`, usuario).pipe(
            map((respuesta) => {
                if (respuesta.exito) {
                    return respuesta.exito;
                } else {
                    throw new Error(respuesta.mensaje || 'Error al agregar el usuario');
                }
            }),
            catchError((error) => {
                console.error('Error interno al agregar el usuario:', error);
                return throwError(() => new Error('Error interno al agregar el usuario'));
            })
        );
    }
}