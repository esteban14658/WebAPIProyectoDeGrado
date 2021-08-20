using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Utilitys
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            // DTOs para recibir informacion

            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<Reciclador, RecicladorDTO>();
            CreateMap<Direccion, DireccionDTO>();
            CreateMap<Residente, ResidenteDTO>();
            CreateMap<PuntoDeRecoleccion, PuntoDeRecoleccionDTO>();
            CreateMap<Tienda, TiendaDTO>();

            // **** *** **************************************************

            // DTOs para enviar informacion

            CreateMap<RecicladorCreacionDTO, Reciclador>();
            CreateMap<UsuarioCreacionDTO, Usuario>();
            CreateMap<DireccionCreacionDTO, Direccion>();
            CreateMap<PuntoDeRecoleccionCreacionDTO, PuntoDeRecoleccion>();
            CreateMap<ResidenteCreacionDTO, Residente>();
            CreateMap<TiendaCreacionDTO, Tienda>();
        }
    }
}
