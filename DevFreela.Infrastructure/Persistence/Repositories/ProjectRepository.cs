using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        public ProjectRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateProject(Project project)
        {
            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateProjectComment(ProjectComment comment)
        {
            await _dbContext.ProjectComments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProject(int id)
        {
            var project = await _dbContext.Projects.SingleOrDefaultAsync(x => x.Id == id);
            project.Cancel();
            _dbContext.Update(project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task FinishProject(int id)
        {
            var project = await _dbContext.Projects.SingleOrDefaultAsync(x => x.Id == id);
            project.Finish();

            _dbContext.Update(project);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Project>> GetAll()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetById(int id)
        {
            return await _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task StartProject(int id)
        {
            var project = await _dbContext.Projects.SingleOrDefaultAsync(x => x.Id == id);
            project.Start();

            _dbContext.Update(project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProject(Project project)
        {
            _dbContext.Update(project);

            await _dbContext.SaveChangesAsync();
        }
    }
}
