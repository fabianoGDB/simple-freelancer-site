using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string name, string email, bool active)
        {
            Name = name;
            Email = email;
            Active = active;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool Active { get; set; }
    }
}
