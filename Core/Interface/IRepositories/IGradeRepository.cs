using Core.DTO;
using Core.Models;
using Core.Models.RequestModel;

namespace Core.Interface.DataAccess
{
    public interface IGradeRepository
    {
        Task<List<GradeEntityDTO>> GetListOfStudentsGradeAsync(int studentId, string studentName);
        Task<Result<bool>> SetGradeStudentAsync(SetStudentGradeRequestModel requestModel);
    }
}
