
namespace Core.Models.RequestModel
{
    public class SetStudentGradeRequestModel
    {
        public int StudentId {  get; set; }
        public string StudentName { get; set; } = default!;       
        public string StudentGrade { get; set; } = default!;
    }
}
