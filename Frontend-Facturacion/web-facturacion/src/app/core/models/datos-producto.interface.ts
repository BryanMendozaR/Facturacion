export interface Productos {
    identificador: number;
    codigo: string;
    nombre: string;
    precio: number;
    estado: boolean;
    fecha: Date;
}

export interface DatosProductos {
    datos: Productos[];
    paginaActual: number;
    tamanoPagina: number;
    totalRegistros: number;
    totalPaginas: number;
}