namespace GradePulseAPI.DTOs
{
    public class StudentGradeCrosstabDto
    {        
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public Dictionary<string, double> Grades { get; set; }
    }
}
