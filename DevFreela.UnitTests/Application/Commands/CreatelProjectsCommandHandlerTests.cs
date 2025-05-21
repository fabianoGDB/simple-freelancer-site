using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.InputModels;
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

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreatelProjectsCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectId()
        {
            //Arange

            var projectReposityMock = new Mock<IProjectRepository>();

            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Project Test 1",

                Description = "Project Description Test 1",
                IdClient = 1,
                IdFreelancer = 2,
                TotalCost = 10000
            };

            var createProjectCommandHandler = new CreateProjectCommandHandler(projectReposityMock.Object);


            //Act

            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());


            //Assert
            Assert.NotNull(id);
            Assert.True(id >= 0);

            projectReposityMock.Verify(prj => prj.AddAsync(It.IsAny<Project>()), Times.Once);
        }
    }
}
