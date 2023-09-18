using GradeMS.Commands;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GradeMS.Controllers
{
    public class GradeController : Controller
    {
        [Route("api/[controller]")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "The MIME type in the Accept HTTP header is not acceptable.", typeof(ProblemDetails))]

           
        [HttpGet]
            public Task<IActionResult> GetStudentsGrade(
           [FromQuery] int? studentId,
           [FromServices] GradeCommand g) => g.ExecuteAsync(studentId);

    }
}
