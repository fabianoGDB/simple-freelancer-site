using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interface;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        //private readonly DevFreelaDbContext _dbContext;
        //public UserService(DevFreelaDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}
        //public int Create(NewUserInputModel inputModel)
        //{
        //    var user = new User(inputModel.Name, inputModel.Email, inputModel.BirthDate);
        //    _dbContext.Users.Add(user);
        //    return user.Id;
        //}

        //public void Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<UserViewModel> GetAll()
        //{
        //    var users = _dbContext.Users;
        //    var userViewModel = users.Select(
        //        u => new UserViewModel(u.Name, u.Email, u.Active)).ToList();

        //    return userViewModel;
        //}

        //public UserDatailsViewModel GetById(int id)
        //{
        //    var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
        //    var userViewModel = new UserDatailsViewModel(user.Id, user.Name, user.Email, user.BirthDate, user.Active);

        //    return userViewModel;
        //}

        //public void Update(UpdateUserInputModel inputModel)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
