using Core.Models;
using Core.Models.RequestModel;

namespace GradeMS.Helper
{
    public class ValidationStudentHelper
    {
        public static Result<bool> ValidateStudent(int studentId, string studentName)
        {

            if (studentId is 0)
            {
                return new Result<bool>
                {
                    Error = "The provided student Id is invalid.",
                    HttpStatusCode = (int)StatusCodes.Status400BadRequest,
                    Success = false,
                };
            }

            if (string.IsNullOrWhiteSpace(studentName))
            {
                return new Result<bool>
                {
                    Error = "The provided student name is invalid.",
                    HttpStatusCode = (int)StatusCodes.Status400BadRequest,
                    Success = false,
                };
            }

            return new Result<bool>
            {
                HttpStatusCode = (int)StatusCodes.Status200OK,
                Success = true,
            };
        }
    }
}
