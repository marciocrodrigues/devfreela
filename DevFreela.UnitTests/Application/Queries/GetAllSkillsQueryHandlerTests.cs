using DevFreela.Application.Queries.GetAllSkills;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllSkillsQueryHandlerTests
    {
        [Fact]
        public async Task ThreeSkillsExists_Executed_ReturnThreeSkillsViewmodels()
        {
            // Arrange
            var skillsList = new List<Skill>
            {
                new Skill("Skill Teste 1"),
                new Skill("Skill Teste 2"),
                new Skill("Skill Teste 3")
            };

            var skillRepositoryMock = new Mock<ISkillRepository>();
            skillRepositoryMock.Setup(pr => pr.GetAllSkills().Result).Returns(skillsList);

            var getAllSkillsQuery = new GetAllSkillsQuery();
            var getAllSkillsQueryHandler = new GetAllSkillsQueryHandler(skillRepositoryMock.Object);

            // Act
            var skillsViewModelList = await getAllSkillsQueryHandler.Handle(getAllSkillsQuery, new CancellationToken());

            // Assert
            Assert.NotNull(skillsViewModelList);
            Assert.NotEmpty(skillsViewModelList);
            Assert.Equal(skillsList.Count, skillsViewModelList.Count);

            // Valida se o metodo foi chamado e quantas vezes, no caso uma vez
            skillRepositoryMock.Verify(pr => pr.GetAllSkills().Result, Times.Once);
        }
    }
}
