using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.Controllers
{
    [ApiController]
    [Route("api/residentes")]
    public class ResidenteController: ControllerBase
    {

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
    }
}
