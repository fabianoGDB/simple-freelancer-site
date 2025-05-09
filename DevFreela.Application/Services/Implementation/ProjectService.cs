using Dapper;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interface;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevFreela.Application.Services.Implementation
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;

        public ProjectService(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        //public int Create(NewProductInputModel inputModel)
        //{
        //    var project = new Project(
        //        inputModel.Title,
        //        inputModel.Descripton,
        //        inputModel.IdClient,
        //        inputModel.IdFreelancer,
        //        inputModel.TotalCost
        //        );

        //    _dbContext.Projects.Add(project);
        //    _dbContext.SaveChanges();

        //    return project.Id;
        //}

        //public void CreateComment(CreateCommentInputModel inputModel)
        //{
        //    var projectComment = new ProjectComment(
        //        inputModel.Content,
        //        inputModel.IdProject,
        //        inputModel.IdUser
        //        );

        //    _dbContext.ProjectComments.Add(projectComment);

        //    _dbContext.SaveChanges();
        //}

        //public void Delete(int id)
        //{
        //    var project = _dbContext.Projects.FirstOrDefault(p => p.Id == id);
            
        //    project.Cancel();

        //    _dbContext.SaveChanges();
        //}

        public void Finish(int id)
        {
            var project = _dbContext.Projects.FirstOrDefault(p => p.Id == id);

            project.Finish();

            _dbContext.SaveChanges();
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _dbContext.Projects;
            var projectsViewModel = projects.Select(
                p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt)).ToList();

            return projectsViewModel;
        }

        public ProjectDatailsViewModel GetById(int id)
        {
            var project = _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .FirstOrDefault(p => p.Id == id);

            var detailProject = new ProjectDatailsViewModel
            (
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt,
                project.Client.Name,
                project.Freelancer.Name
            );

            return detailProject;
        }

        public void Start(int id)
        {
            var project = _dbContext.Projects.FirstOrDefault(p => p.Id == id);

            project.Start();

            //_dbContext.SaveChanges();

            using(var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "UPDATE Projects SET Status = @status, StartedAt = @startedat WHERE Id = @id";

                sqlConnection.Execute(script, new { status = project.Status, startedat = DateTime.Now, id});
            }
        }

        //public void Update(UpdateProductInputModel inputModel)
        //{
        //    var project = _dbContext.Projects.FirstOrDefault(p => p.Id == inputModel.Id);

        //    project.Update(inputModel.Title, inputModel.Descripton, inputModel.TotalCost);

        //    _dbContext.SaveChanges();
        //}
    }
}
