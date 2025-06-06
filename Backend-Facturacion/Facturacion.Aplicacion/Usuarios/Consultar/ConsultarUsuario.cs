﻿using Facturacion.Dominio.Modelos;
using MediatR;

namespace Facturacion.Aplicacion.Usuarios.Consultar
{
    public class ConsultarUsuario : IRequest<RespuestaPaginadaModelo<UsuarioModelo>>
    {
        public int Pagina { get; set; }
        public int TamanoPagina { get; set; }

        public ConsultarUsuario(int pagina = 1, int tamanoPagina = 10)
        {
            Pagina = pagina;
            TamanoPagina = tamanoPagina;
        }
    }
}
