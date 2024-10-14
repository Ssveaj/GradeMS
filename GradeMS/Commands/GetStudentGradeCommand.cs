using Core.Interface.UseCases;
using Core.Models.RequestModel;
using GradeMS.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GradeMS.Commands
{
    public class GetStudentGradeCommand
    {
        private readonly IGetStudentGradeUseCase getStudentGradeUseCase;
        public GetStudentGradeCommand(IGetStudentGradeUseCase getStudentGradeUseCase)
        {
            this.getStudentGradeUseCase = getStudentGradeUseCase;
        }

        public async Task<IActionResult> ExecuteAsync(GetStudentGradeRequestModel requestModel)
        {
            try
            {
                var validationResult = ValidationStudentHelper.ValidateStudent(requestModel.StudentId, requestModel.StudentName);
                if (!validationResult.Success)
                {
                    return ApiResponseHelper.CreateFailedResponse(validationResult.HttpStatusCode, validationResult.Error, validationResult.Success);
                }

                var useCaseResult = await this.getStudentGradeUseCase.ExecuteUseCaseAsync(requestModel).ConfigureAwait(false);
                if(!useCaseResult.Success)
                {
                    return ApiResponseHelper.CreateFailedResponse(useCaseResult.HttpStatusCode, useCaseResult.Error, useCaseResult.Success); 
                }

                return new OkObjectResult(useCaseResult);
            }
            catch (Exception ex) 
            {
                return ApiResponseHelper.CreateFailedResponse((int)HttpStatusCode.InternalServerError, ex.Message, false);
            }
        }
    }
}
