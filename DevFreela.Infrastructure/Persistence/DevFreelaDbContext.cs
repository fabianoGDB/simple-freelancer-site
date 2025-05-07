using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Users = new List<User>{
                new User("Fabiano", "fabiano.bortolussi@gmail.com", new DateTime(2000, 1, 1)),
                new User("Jhon Doe", "jhon.doe@gmail.com", new DateTime(2000, 11, 11)),
                new User("No Body", "no.nody@gmail.com", new DateTime(1899, 12, 21)),
            };
            Projects = new List<Project>
            {
                new Project("Meu projeto AspNet Core 1", "Minha Descrição 1",1,1,10000),
                new Project("Meu projeto AspNet Core 2", "Minha Descrição 2",1,1,20000),
                new Project("Meu projeto AspNet Core 3", "Minha Descrição 3",1,1,30000)
            };
            Skills = new List<Skill> {
                new Skill(".Net Core"),
                new Skill("C#"),
                new Skill("Sql")
            };

            ProjectComments = new List<ProjectComment> { };
        }

        public List<User> Users { get; set; }
        public List<Project> Projects { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }
    }
}