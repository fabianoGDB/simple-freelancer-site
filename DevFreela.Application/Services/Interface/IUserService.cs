using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Interface
{
    public interface IUserService
    {

        List<UserViewModel> GetAll();
        UserDatailsViewModel GetById(int id);
        int Create(NewUserInputModel inputModel);
        void Update(UpdateUserInputModel inputModel);
        void Delete(int id);

    }
}
