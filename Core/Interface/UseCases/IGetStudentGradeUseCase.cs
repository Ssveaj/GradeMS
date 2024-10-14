using Core.Models;
using Core.Models.RequestModel;


namespace Core.Interface.UseCases
{
    public interface IGetStudentGradeUseCase
    {
        public Task<Result<List<GradeResponse>>> ExecuteUseCaseAsync(GetStudentGradeRequestModel requestModel);
    }
}
