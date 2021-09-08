﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class CollectionPointService: GenericService<CollectionPointDTO,CollectionPoint>, ICollectionPointService
    {
        private readonly ICollectionPointRepository _collectionPointRepository;
        private readonly IMapper _mapper;

        public CollectionPointService(ICollectionPointRepository collectionPointRepository,
            IMapper mapper): base(collectionPointRepository, mapper)
        {
            _collectionPointRepository = collectionPointRepository;
            _mapper = mapper;
        }
    }
}
