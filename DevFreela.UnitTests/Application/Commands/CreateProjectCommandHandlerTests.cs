﻿using DevFreela.Application.Commands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectId()
        {
            // Arrange
            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Titulo de Teste",
                Description = "Descrição teste",
                TotalCost = 50000,
                IdClient = 1,
                IdFreelancer = 2
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();

            var createProjectCommandHandler = new CreateProjectCommandHandler(projectRepositoryMock.Object);

            // Act
            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            // Assert
            Assert.True(id >= 0);

            projectRepositoryMock.Verify(pr => pr.CreateProject(It.IsAny<Project>()), Times.Once);
        }
    }
}
