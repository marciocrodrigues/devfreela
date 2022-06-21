using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUserService
    {
        UserDetailViewModel GetById(int id);
        int Create(NewUserInputModel inputModel);
    }
}
