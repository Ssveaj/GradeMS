
using Core.Interface.DataAccess;
using Core.Interface.UseCases;
using Core.Models;
using Core.Models.RequestModel;

namespace Core.UseCases
{
    public class SetStudentGradeUseCase : ISetStudentGradeUseCase
    {
        private readonly IGradeRepository gradeRepository;
        public SetStudentGradeUseCase(IGradeRepository gradeRepository)
        {
            this.gradeRepository = gradeRepository;
        }

        public async Task<Result<bool>> ExecuteUseCaseAsync(SetStudentGradeRequestModel requestModel)
        {
            var studentResult = await this.gradeRepository.SetGradeStudentAsync(requestModel).ConfigureAwait(false);
            if (!studentResult.Success)
            {
                return new Result<bool>
                {
                    Error = studentResult.Error,
                    HttpStatusCode = studentResult.HttpStatusCode,
                    Success = studentResult.Success,
                };
            }

            return new Result<bool>
            {
                HttpStatusCode = studentResult.HttpStatusCode,
                Success = studentResult.Success,
            };
        }
    }
}
