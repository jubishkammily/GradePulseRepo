using GradePulseAPI.DTOs;
using GrapePulseAPI.Models;

namespace GradePulseAPI.Services.Mapping
{
    public interface IEntityToDtoMapping
    {
        StudentDto StudentEntityToDtoMApping(Student entity);
        List<StudentDto> StudentEntityToDtoMApping(List<Student> entityList);
    }
}
