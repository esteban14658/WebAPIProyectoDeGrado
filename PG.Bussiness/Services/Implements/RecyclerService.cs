using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class RecyclerService: GenericService<Recycler>, IRecyclerService
    {
        private readonly IRecyclerRepository recicladorRepository;

        public RecyclerService(IRecyclerRepository recicladorRepository): base(recicladorRepository)
        {
            this.recicladorRepository = recicladorRepository;
        }
    }
}
