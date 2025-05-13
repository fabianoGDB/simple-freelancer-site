using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
    {
        private readonly ISkillRepository _repostory;
        public GetAllSkillsQueryHandler(ISkillRepository repository)
        {
            _repostory = repository;
        }
        public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await _repostory.GetAll();
            var skillsViewModel = skills.Select(
                p => new SkillViewModel(p.Id, p.Description)).ToList();

            return skillsViewModel;
        }
    }
}
