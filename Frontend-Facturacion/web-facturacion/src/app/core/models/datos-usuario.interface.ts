export interface Usuarios {
    codigo: number;
    nombre: string;
    usuario: string;
    clave?: string;
    correo: string;
    fecha: Date;
}

export interface DatosUsuarios {
    datos: Usuarios[];
    paginaActual: number;
    tamanoPagina: number;
    totalRegistros: number;
    totalPaginas: number;
}