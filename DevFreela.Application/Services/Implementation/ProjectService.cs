using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interface;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevFreela.Application.Services.Implementation
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;

        public ProjectService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(NewProductInputModel inputModel)
        {
            var project = new Project(
                inputModel.Title,
                inputModel.Descripton,
                inputModel.IdClient,
                inputModel.IdFreelancer,
                inputModel.TotalCost
                );

            _dbContext.Projects.Add(project);

            return project.Id;
        }

        public void CreateComment(CreateCommentInputModel inputModel)
        {
            var projectComment = new ProjectComment(
                inputModel.Content,
                inputModel.IdProject,
                inputModel.IdUser
                );

            _dbContext.ProjectComments.Add(projectComment);
        }

        public void Delete(int id)
        {
            var project = _dbContext.Projects.FirstOrDefault(p => p.Id == id);
            
            project.Cancel();
        }

        public void Finish(int id)
        {
            var project = _dbContext.Projects.FirstOrDefault(p => p.Id == id);

            project.Finish();
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
            var project = _dbContext.Projects.FirstOrDefault(p => p.Id == id);

            var detailProject = new ProjectDatailsViewModel
            (
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt
            );

            return detailProject;
        }

        public void Start(int id)
        {
            var project = _dbContext.Projects.FirstOrDefault(p => p.Id == id);

            project.Start();
        }

        public void Update(UpdateProductInputModel inputModel)
        {
            var project = _dbContext.Projects.FirstOrDefault(p => p.Id == inputModel.Id);

            project.Update(inputModel.Title, inputModel.Descripton, inputModel.TotalCost);
        }
    }
}
