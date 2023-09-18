using Core.Interface.UseCases;
using Core.Models.Base;
using Core.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace GradeMS.Commands
{
    public class GradeCommand
    {
        private readonly IGetStudentGradeUseCase usecase;
        public GradeCommand(IGetStudentGradeUseCase usecase)
        {
            this.usecase = usecase;
        }

        public async Task<IActionResult> ExecuteAsync(int? studentId = null)
        {
            try
            {
                if (studentId == null)
                {
                    var errorResponseModel = new GetStudentGradeResponseModel
                    {
                        Success = false,
                        HttpStatusCode = 500,
                        Errors = new List<ApiErrorResponseModel> { new ApiErrorResponseModel { Message = "ID Not Found" } }
                    };

                    return new ObjectResult(errorResponseModel);
                }

                var result = await usecase.ExecuteUseCaseAsync(studentId);

                var retreivedGetStudentResponseModel = new GetStudentGradeResponseModel
                {
                    Success = true,
                    HttpStatusCode = 200,
                    StudentGrade = result.Value.StudentGrade,

                };

                return new OkObjectResult(retreivedGetStudentResponseModel);
            }
            catch (Exception ex) 
            {
                var responseModel = new GetStudentGradeResponseModel
                {
                    Success = false,
                    HttpStatusCode = 500,
                    Errors = new List<ApiErrorResponseModel> { new ApiErrorResponseModel { Message = ex.Message } }

                };
                return new ObjectResult(responseModel);

                throw;

            }
          

        }
    }
}
