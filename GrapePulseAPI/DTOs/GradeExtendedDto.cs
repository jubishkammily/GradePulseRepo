namespace GradePulseAPI.DTOs
{
    public class GradeExtendedDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; } 
        public int SubjectId { get; set; }
        public string SubjectName { get; set; } 
        public string GradeValue { get; set; }
    }
}
