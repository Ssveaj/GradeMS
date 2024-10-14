using Core.Models.RequestModel;
using GradeMS.Commands;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GradeMS.Controllers
{
    public class GradeController : ControllerBase
    {
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "The MIME type in the Accept HTTP header is not acceptable.", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status200OK, "Success")]

        [HttpGet("/internal/grade")]
        public async Task<IActionResult> GetStudentsGradeAsync(
           [FromQuery] GetStudentGradeRequestModel requestModel,
           [FromServices] GetStudentGradeCommand command) => await command.ExecuteAsync(requestModel).ConfigureAwait(false);
        
        [HttpPost("/internal/grade")]
        public async Task<IActionResult> SetStudentGradeAsync(
           [FromQuery] SetStudentGradeRequestModel requestModel,
           [FromServices] SetStudentGradeCommand command) => await command.ExecuteAsync(requestModel).ConfigureAwait(false);

    }
}
