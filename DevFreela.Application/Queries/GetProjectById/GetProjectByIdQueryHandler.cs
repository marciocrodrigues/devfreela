using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailViewModel>
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectByIdQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ProjectDetailViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetById(request.Id);

            return new ProjectDetailViewModel(project.Id,
                                              project.Title,
                                              project.Description,
                                              project.StartedAt,
                                              project.FinishedAt,
                                              project.TotalCost,
                                              project.Client.FullName,
                                              project.Freelancer.FullName);
        }
    }
}
