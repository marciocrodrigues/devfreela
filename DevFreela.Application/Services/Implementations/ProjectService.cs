﻿using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;

        public ProjectService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(NewProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdCliente, inputModel.IdFreelancer, inputModel.TotalCost);

            _dbContext.Projects.Add(project);

            return project.Id;
        }

        public void CreateComment(CreateCommentInputModel inputModel)
        {
            var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);

            _dbContext.ProjectComments.Add(comment);
        }

        public void Delete(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(x => x.Id == id);
            project.Cancel();
        }

        public void Finish(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(x => x.Id == id);
            project.Finish();
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _dbContext.Projects;

            return projects.Select(p => new ProjectViewModel(p.Title, p.CreatedAt, p.Id)).ToList();
        }

        public ProjectDetailViewModel GetById(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(x => x.Id == id);

            return new ProjectDetailViewModel(project.Id, project.Title, project.Description, project.StartedAt, project.FinishedAt, project.TotalCost);
        }

        public void Start(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(x => x.Id == id);
            project.Start();
        }

        public void Update(UpdateProjectInputModel inputModel)
        {
            var project = _dbContext.Projects.SingleOrDefault(x => x.Id == inputModel.Id);
            project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
        }
    }
}
