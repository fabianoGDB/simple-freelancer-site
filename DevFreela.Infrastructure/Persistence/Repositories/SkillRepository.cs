﻿using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _dbcontext;
        public SkillRepository(DevFreelaDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<SkillDTO>> GetAllAsync()
        {
            //using (var sqlConnection = new SqlConnection(_connectionString))
            //{
            //    sqlConnection.Open();

            //    var script = "SELECT Id, Description FROM Skills";

            //    var skills = await sqlConnection.QueryAsync<SkillDTO>(script);

            //    return skills.ToList();
            //}

            // COM EF CORE
            var skills = _dbcontext.Skills;

            var skillsViewModel = skills
              .Select(s => new SkillDTO(s.Id, s.Description))
               .ToList();

            return new List<SkillDTO>();
        }
    }
}
