

using Core.Models;
using Core.Models.RequestModel;

namespace Core.Interface.UseCases
{
    public interface ISetStudentGradeUseCase
    {
        Task<Result<bool>> ExecuteUseCaseAsync(SetStudentGradeRequestModel requestModel);
    }
}
