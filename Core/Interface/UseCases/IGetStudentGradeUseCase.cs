using Core.Models;
using Core.Models.Response;

namespace Core.Interface.UseCases
{
    public interface IGetStudentGradeUseCase
    {
        public Task<Result<GetStudentGradeResponseModel>> ExecuteUseCaseAsync(int? studentId = null);
    }
}
