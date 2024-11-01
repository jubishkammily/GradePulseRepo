using GradePulseAPI.Data.Repository;
using GradePulseAPI.DTOs;
using GradePulseAPI.Services.Mapping;
using GrapePulseAPI.Data;
using GrapePulseAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GradePulseAPI.Services
{
    public class StudentService : IStudentService
    {
        private IEntityToDtoMapping _entityToDtoMapping;
        private IDtoToEnityMapping _dtoToEnitytoMapping;
        private IRepository<Student> _repository;

        public StudentService(IEntityToDtoMapping EntityToDtoMapping, IDtoToEnityMapping dtoToEnitytoMapping,IRepository<Student> repository)
        {           
            _entityToDtoMapping = EntityToDtoMapping;
            _dtoToEnitytoMapping = dtoToEnitytoMapping; 
            _repository = repository;
        }

        public async Task<int> AddStudentAsync(StudentDto dto)
        {
            var student = _dtoToEnitytoMapping.StudentDtoToEntityMapping(dto);
            return await _repository.AddAsync(student);
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _repository.GetAllAsync();
            var studentDtoList = _entityToDtoMapping.StudentsEntityToDtoMApping((List<Student>)students);
            return studentDtoList;
        }

        public async Task<StudentDto> GetStudentAsync(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            var studentDto = _entityToDtoMapping.StudentEntityToDtoMApping(student);
            return studentDto;
        }

        public async Task UpdateStudentAsync(int id, StudentDto dto)
        {
            Student student = await _repository.GetByIdAsync(id);
            student.Name = dto.Name;
            student.DateOfBirth = DateTime.Parse(dto.DateOfBirth);
            await _repository.UpdateAsync(student);            
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);            
        }
    }
}
