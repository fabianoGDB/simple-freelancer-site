using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetProjectsById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDatailsViewModel>
    {
        private readonly IProjectRepository _repository;
        public GetProjectByIdQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }
        public async Task<ProjectDatailsViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetById(request.Id);

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
    }
}
