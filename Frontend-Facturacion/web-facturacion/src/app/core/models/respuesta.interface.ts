export interface Respuesta<T> {
    exito: boolean;
    mensaje: string;
    codigo: number;
    errors?: any;
    data: T;
}