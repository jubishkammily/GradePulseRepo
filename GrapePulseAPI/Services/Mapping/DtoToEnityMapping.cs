using GradePulseAPI.DTOs;
using GrapePulseAPI.Models;

namespace GradePulseAPI.Services.Mapping
{
    public class DtoToEnityMapping : IDtoToEnityMapping
    {
        public Student StudentDtoToEntityMapping(StudentDto dto)
        {
            Student student = new Student() {                
                Name = dto.Name,
                DateOfBirth = DateTime.Parse(dto.DateOfBirth)
            };
            return student;
        }
    }
}
