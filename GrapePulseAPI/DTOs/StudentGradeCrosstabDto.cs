namespace GradePulseAPI.DTOs
{
    public class StudentGradeCrosstabDto
    {        
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public Dictionary<string, string> Grades { get; set; }
    }
}
