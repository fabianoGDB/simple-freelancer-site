using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class UserDatailsViewModel
    {
        public UserDatailsViewModel(int id, string name, string email, DateTime birthDate, bool active)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Active = active;
        }

        public int Id { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Active { get; set; }
    }
}
