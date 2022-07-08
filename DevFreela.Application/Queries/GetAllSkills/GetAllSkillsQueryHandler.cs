using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
    {
        private readonly ISkillRepository _skilRepository;

        public GetAllSkillsQueryHandler(ISkillRepository skilRepository)
        {
            _skilRepository = skilRepository;
        }

        public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await _skilRepository.GetAllSkills();

            return skills.Select(s => new SkillViewModel(s.Id, s.Description)).ToList();
        }
    }
}
