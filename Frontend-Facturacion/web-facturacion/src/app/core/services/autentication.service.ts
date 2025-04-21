import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {catchError, map, Observable, throwError} from 'rxjs';
import {environments} from '../../../environments/environments';
import {Respuesta} from '../../core/models/respuesta.interface';
import {IniciarSesion} from '../models/iniciar-sesion.interface';

@Injectable({providedIn: 'root'})
export class AutenticacionService {

    /*
    * Obtenemos la url base de nuestro archivo de variables
    */
    private apiUrl = environments.Url;

    /*
    * Constructor de la clase se lo utiliza para la inyeccion de dependencias
    */
    constructor(private httpClient: HttpClient) { }

    /*
    * Metodo para iniciar sesion
    * @param {usuario} usuario
    * @param {clave} clave
    */
    iniciarSesion(usuario: string, clave: number): Observable<IniciarSesion> {
        return this.httpClient.get<Respuesta<IniciarSesion>>(`${this.apiUrl}/Usuario/IniciarSesion/${usuario}/${clave}`).pipe(
            map((respuesta) => {
                if (respuesta.exito) {
                    if (respuesta.data.inicio) {
                        localStorage.setItem('codigo', respuesta.data.codigo.toString());
                        localStorage.setItem('nombre', respuesta.data.nombre.toString());
                        localStorage.setItem('usuario', respuesta.data.usuario.toString());
                        localStorage.setItem('correo', respuesta.data.correo.toString());
                    }
                    return respuesta.data;
                } else {
                    throw new Error(respuesta.mensaje || 'Error al inciar sesion');
                }
            }),
            catchError((error) => {
                console.error('Error interno al iniciar sesion:', error);
                return throwError(() => new Error('Error interno al iniciar sesion'));
            })
        );
    }
}