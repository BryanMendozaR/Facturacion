export interface Clientes {
    codigo: number;
    identificacion: string;
    nombre: string;
    telefono: string;
    correo: string;
    direccion: string;
    estado: boolean;
}

export interface DatosClientes {
    datos: Clientes[];
    paginaActual: number;
    tamanoPagina: number;
    totalRegistros: number;
    totalPaginas: number;
}