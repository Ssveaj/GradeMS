using Core.Interface.DataAccess;
using Core.Interface.UseCases;
using Core.Models;
using Core.Models.RequestModel;
using System.Net;

namespace Core.UseCase
{
    public class GetStudentGradeUseCase : IGetStudentGradeUseCase
    {
        private readonly IGradeRepository gradeRepository;
        public GetStudentGradeUseCase(IGradeRepository gradeRepository)
        {
            this.gradeRepository = gradeRepository;
        }

        public async Task<Result<List<GradeResponse>>> ExecuteUseCaseAsync(GetStudentGradeRequestModel requestModel)
        {
            var gradeResult = await this.gradeRepository.GetListOfStudentsGradeAsync(requestModel.StudentId, requestModel.StudentName).ConfigureAwait(false);
            if (!gradeResult.Any())
            {
                return new Result<List<GradeResponse>>
                {
                    Error = "Could not receive grades. The list is empty.",
                    HttpStatusCode = (int)HttpStatusCode.BadRequest,
                    Success = false
                };
            }

            var gradeResponseList = gradeResult.Select(x => new GradeResponse
            {
                Id = x.Id,
                StudentId = x.StudentId,
                StudentGrade = x.StudentGrade

            }).ToList();

            return new Result<List<GradeResponse>>
            {
                Success = true,
                Value = gradeResponseList
            };
        }
    }
}
