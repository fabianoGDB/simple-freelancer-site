﻿using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByEmailAndPasswordAsync(string email, string password)
        {

            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
        }
    }
}
