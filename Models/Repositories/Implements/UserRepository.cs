﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.Entitys;

namespace WebAPIProyectoDeGrado.Repositories.Implements
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        private readonly DbSet<User> _user;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _user = context.Set<User>();
        }

        public bool ExistsByEmail(string email)
        {
            return _user.Any(x => x.Email.Equals(email));
        }
    }
}
