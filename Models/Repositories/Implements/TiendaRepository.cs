﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories.Implements
{
    public class TiendaRepository: GenericRepository<Shop>, ITiendaRepository
    {
        public TiendaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}