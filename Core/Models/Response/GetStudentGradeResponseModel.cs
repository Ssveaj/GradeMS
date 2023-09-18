

using Core.DTO;
using Core.Models.Base;

namespace Core.Models.Response
{
    public class GetStudentGradeResponseModel : BaseResponseModel
    {
        public List<GradeDTO> StudentGrade { get; set; } = default!;
    }
}
