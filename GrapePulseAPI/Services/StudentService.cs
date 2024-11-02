using GradePulseAPI.Data.Repository;
using GradePulseAPI.DTOs;
using GrapePulseAPI.Data;
using GrapePulseAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GradePulseAPI.Services
{
    public class StudentService : IStudentService
    {      
        private IRepository<Student> _repository;

        public StudentService(IRepository<Student> repository)
        {                       
            _repository = repository;
        }

        public async Task<int> AddStudentAsync(StudentDto dto)
        {
            var student = StudentDtoToEntityMapping(dto);
            return await _repository.AddAsync(student);
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _repository.GetAllAsync();
            var studentDtoList = StudentsEntityToDtoMApping((List<Student>)students);
            return studentDtoList;
        }

        public async Task<StudentDto> GetStudentAsync(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            var studentDto = StudentEntityToDtoMApping(student);
            return studentDto;
        }

        public async Task UpdateStudentAsync(int id, StudentDto dto)
        {
            Student student = await _repository.GetByIdAsync(id);
            student.Name = dto.Name;
            student.DateOfBirth = DateTime.Parse(dto.DateOfBirth).Date;
            await _repository.UpdateAsync(student);            
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);            
        }

        private Student StudentDtoToEntityMapping(StudentDto dto)
        {
            Student student = new Student()
            {
                Name = dto.Name,
                DateOfBirth = DateTime.Parse(dto.DateOfBirth).Date
            };
            return student;
        }

        private StudentDto StudentEntityToDtoMApping(Student entity)
        {
            StudentDto studentDto = new StudentDto();
            studentDto.Id = entity.Id;
            studentDto.Name = entity.Name;
            studentDto.DateOfBirth = entity.DateOfBirth.ToString();

            return studentDto;

        }

        private List<StudentDto> StudentsEntityToDtoMApping(List<Student> entityList)
        {
            var studentDtoList = new List<StudentDto>();

            foreach (Student student in entityList)
            {
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
