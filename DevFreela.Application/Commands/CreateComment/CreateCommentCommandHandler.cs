using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly IProjectRepository _projectRepsoitory;

        public CreateCommentCommandHandler(IProjectRepository projectRepsoitory)
        {
            _projectRepsoitory = projectRepsoitory;
        }

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);

            await _projectRepsoitory.CreateProjectComment(comment);

            return Unit.Value;
        }
    }
}
