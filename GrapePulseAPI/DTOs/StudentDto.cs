using System.Text.Json.Serialization;

namespace GradePulseAPI.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string DateOfBirth { get; set; }
    }
}
