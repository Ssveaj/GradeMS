using Core.Interface.UseCases;
using Core.Models.RequestModel;
using GradeMS.Helper;
using Microsoft.AspNetCore.Mvc;

namespace GradeMS.Commands
{
    public class SetStudentGradeCommand
    {
        private readonly ISetStudentGradeUseCase setGradeStudentUseCase;
        public SetStudentGradeCommand(ISetStudentGradeUseCase setGradeStudentUseCase)
        {
            this.setGradeStudentUseCase = setGradeStudentUseCase;
        }

        public async Task<IActionResult> ExecuteAsync(SetStudentGradeRequestModel requestModel)
        {
            var validationResult = ValidationStudentHelper.ValidateStudent(requestModel.StudentId, requestModel.StudentName);
            if (!validationResult.Success) 
            {
                return ApiResponseHelper.CreateFailedResponse(validationResult.HttpStatusCode, validationResult.Error, validationResult.Success);
            }

            var useCaseResult = await this.setGradeStudentUseCase.ExecuteUseCaseAsync(requestModel).ConfigureAwait(false);
            if (!useCaseResult.Success)
            {
                return ApiResponseHelper.CreateFailedResponse(useCaseResult.HttpStatusCode, useCaseResult.Error, useCaseResult.Success);
            }

            return new OkObjectResult(useCaseResult);
        }
    }
}
