export interface Cabecera {
    nombre: string;
    texto: string;
    cell?: (row: any) => string;
}