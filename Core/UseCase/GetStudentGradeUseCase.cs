using Core.DTO;
using Core.Interface.DataAccess;
using Core.Interface.UseCases;
using Core.Models;
using Core.Models.Response;

namespace Core.UseCase
{
    public class GetStudentGradeUseCase : IGetStudentGradeUseCase
    {
        private readonly IGradeRepository repo;
        public GetStudentGradeUseCase(IGradeRepository repo)
        {
            this.repo = repo;
        }

        public async Task<Result<GetStudentGradeResponseModel>> ExecuteUseCaseAsync(int? studentId = null)
        {
            var gradeList = repo.GetStudentsGrade();
            if (gradeList == null && gradeList.Count > 0)
            {
                return new Result<GetStudentGradeResponseModel>
                {
                    Error = "List Of Grades Not Found",
                    ErrorCode = ErrorCode.NotFound,
                    Success = false
                };
            }

            List<GradeDTO> foundGrade = gradeList.Where(x => x.StudentId == studentId).ToList();
            if (foundGrade == null)
            {
                return new Result<GetStudentGradeResponseModel>
                {
                    Error = "No Student Found or Grade has not been completed",
                    ErrorCode = ErrorCode.NotFound,
                    Success = false
                };
            }

            var responseModel = new GetStudentGradeResponseModel
            {
                StudentGrade = foundGrade
            };

            return new Result<GetStudentGradeResponseModel>
            {
                Success = true,
                Value = responseModel
            };
        }
    }
}
