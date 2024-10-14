

namespace Core.Models.RequestModel
{
    public class GetStudentGradeRequestModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = default!;
    }
}
