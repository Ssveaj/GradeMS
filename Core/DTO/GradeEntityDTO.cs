

namespace Core.DTO
{
    public class GradeEntityDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string? StudentGrade { get; set; }        
        public string? StudentName { get; set; }
    }
}
