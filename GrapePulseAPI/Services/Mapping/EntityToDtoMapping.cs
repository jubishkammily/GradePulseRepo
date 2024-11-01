using GradePulseAPI.DTOs;
using GrapePulseAPI.Models;

namespace GradePulseAPI.Services.Mapping
{
    public class EntityToDtoMapping : IEntityToDtoMapping
    {
        public EntityToDtoMapping() { }
        public StudentDto StudentEntityToDtoMApping(Student entity)
        {
            StudentDto studentDto = new StudentDto();
            studentDto.Id = entity.Id;
            studentDto.Name = entity.Name;
            studentDto.DateOfBirth = entity.DateOfBirth.ToString();

            return studentDto;

        }

        public List<StudentDto> StudentsEntityToDtoMApping(List<Student> entityList)
        {
            var studentDtoList = new List<StudentDto>();               

            foreach (Student student in entityList) {
                var studentDto = new StudentDto();
                studentDto.Id = student.Id;
                studentDto.Name = student.Name;
                studentDto.DateOfBirth = student.DateOfBirth.ToString();
                studentDtoList.Add(studentDto);
            }

            return studentDtoList;

        }
    }
}
