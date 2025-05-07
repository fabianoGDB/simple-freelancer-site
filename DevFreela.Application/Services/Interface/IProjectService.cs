using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Interface
{
    public interface IProjectService
    {

        List<ProjectViewModel> GetAll(string query);
        ProjectDatailsViewModel GetById(int id);
        int Create(NewProductInputModel inputModel);
        void Update(UpdateProductInputModel inputModel);
        void Delete(int id);
        void CreateComment(CreateCommentInputModel inputModel);
        void Start(int  id);
        void Finish(int id);

    }
}
