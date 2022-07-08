using DevFreela.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAll();
        Task<Project> GetById(int id);
        Task CreateProjectComment(ProjectComment comment);
        Task CreateProject(Project project);
        Task UpdateProject(Project project);
        Task DeleteProject(int id);
        Task FinishProject(int id);
        Task StartProject(int id);
    }
}
