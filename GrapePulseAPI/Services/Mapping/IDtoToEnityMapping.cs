using GradePulseAPI.DTOs;
using GrapePulseAPI.Models;

namespace GradePulseAPI.Services.Mapping
{
    public interface IDtoToEnityMapping
    {
        Student StudentDtoToEntityMapping(StudentDto dto);
    }
}
