﻿using Dapper;
using DevFreela.Application.Services.Interface;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementation
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;
        public SkillService(DevFreelaDbContext dbContext, IConfiguration configuration) {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        //public List<SkillViewModel> GetAll()
        //{
        //    using (var sqlConnection = new SqlConnection(_connectionString))
        //    {
        //        var script = "SELECT Id, Description FROM Skills";

        //        return sqlConnection.Query<SkillViewModel>(script).ToList();
        //    }
        //    //var skills = _dbContext.Skills;
        //    //var skillsViewModel = skills.Select(
        //    //    p => new SkillViewModel(p.Id, p.Description)).ToList();

        //    //return skillsViewModel;
        //}
    }
}
