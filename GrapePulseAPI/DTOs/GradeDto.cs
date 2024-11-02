using GrapePulseAPI.Models;

namespace GradePulseAPI.DTOs
{
    public class GradeDto
    {      
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public string GradeValue { get; set; }

    }
}
