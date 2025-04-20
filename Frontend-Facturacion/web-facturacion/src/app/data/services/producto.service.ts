import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {catchError, map, Observable, throwError} from 'rxjs';
import {environments} from '../../../environments/environments';
import {DatosProductos} from '../../core/models/datos-producto.interface';
import {Respuesta} from '../../core/models/respuesta.interface';

@Injectable({providedIn: 'root'})
export class ProductoService {

    private apiUrl = environments.Url;

    constructor(private httpClient: HttpClient) { }

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
}