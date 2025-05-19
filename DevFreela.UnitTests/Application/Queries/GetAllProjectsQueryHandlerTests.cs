using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsQueryHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project("Project Test 1", "Project Cescription Test 1", 1,2, 10000),
                new Project("Project Test 2", "Project Cescription Test 2", 1,1, 20000),
                new Project("Project Test 3", "Project Cescription Test 3", 2,3, 30000)
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(prj => prj.GetAllAsync().Result).Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery("");
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);


            // Act
            var peojectViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            // Assert
            Assert.NotNull(peojectViewModelList);
            Assert.NotEmpty(peojectViewModelList);
            Assert.Equal(projects.Count, peojectViewModelList.Count);

            projectRepositoryMock.Verify(prj => prj.GetAllAsync().Result, Times.Once);
        }
    }
}
