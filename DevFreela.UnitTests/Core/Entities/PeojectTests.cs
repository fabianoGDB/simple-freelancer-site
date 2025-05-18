using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Core.Entities
{
    public class PeojectTests
    {
        [Fact]
        public void TestIfProjectStartWorks()
        {
            var project = new Project("Test Project Nome", "Test Description Project", 1, 2, 10000);

            Assert.Equal(ProjectStatusEnum.Created, project.Status);
            Assert.Null(project.StartedAt);

            project.Start();

            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);

            Assert.NotEmpty(project.Title);
            Assert.NotEmpty(project.Description);
        }
    }
}
