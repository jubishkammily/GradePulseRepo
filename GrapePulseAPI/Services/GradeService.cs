using GradePulseAPI.Data.Repository;
using GradePulseAPI.DTOs;
using GrapePulseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GradePulseAPI.Services
{
    public class GradeService : IGradeService
    {
        private IRepository<Grade> _repository;
        private IRepository<Student> _studentRepository;
        private IRepository<Subject> _subjectRepository;

        public GradeService(IRepository<Grade> repository, IRepository<Student> studentRepository, IRepository<Subject> subjectRepository)
        {
            _repository = repository;
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
        }

        public async Task<IEnumerable<GradeExtendedDto>> GetAllGradesAsync()
        {
            var grades = await _repository.GetAllAsync(g => g.Student, g => g.Subject);

            var gradeDtos = grades.Select(g => new GradeExtendedDto
            {
                Id = g.Id,
                StudentId = g.StudentId,
                StudentName = g.Student.Name,
                SubjectId = g.SubjectId,
                SubjectName = g.Subject.Name,
                GradeValue = g.GradeValue.ToString(),
            });

            //var gradeDtos = GradesEntityToDtoMApping((List<Grade>)grades);
            return gradeDtos;
        }
        public async Task<int> AddGradeAsync(GradeDto dto)
        {
            var grades = await _repository.GetAllAsync();
            var result = grades.FirstOrDefault(x => x.SubjectId == dto.SubjectId && x.StudentId == dto.StudentId);
           
            if (result != null) {
               throw new CustomErrorException("This student already has a grade recorded for the specified subject.", StatusCodes.Status400BadRequest);               
            }

            var grade = await DtoToEntityMapping(dto);
            return await _repository.AddAsync(grade);
        }

        public async Task<List<StudentGradeCrosstabDto>> GetGradesCrosstabAsync()
        {
         var grades = await _repository.GetAllAsync(g => g.Student, g => g.Subject);

            var crosstabData = grades.GroupBy(g => g.Student).Select(studentGroup => new StudentGradeCrosstabDto {
            
            StudentId = studentGroup.Key.Id,
            StudentName = studentGroup.Key.Name,
            Grades = studentGroup.ToDictionary(
                grade => grade.Subject.Name,
                grade => grade.GradeValue

            )
        })
        .ToList();

            return crosstabData;

        }

        public async Task UpdateGradeAsync(GradeDto dto)
        {
            var grades = await _repository.GetAllAsync();
            var result = grades.FirstOrDefault(x => x.SubjectId == dto.SubjectId && x.StudentId == dto.StudentId);
            

            if (result == null)
            {
                throw new CustomErrorException("The Item does not exist.", StatusCodes.Status400BadRequest);
            }
            Grade grade = await _repository.GetByIdAsync(result.Id);
            grade.GradeValue = dto.GradeValue;

             await _repository.UpdateAsync(grade);            
        }

        public async Task DeleteAsync(int subjectId, int studentId)
        {
            var grades = await _repository.GetAllAsync();
            var result = grades.FirstOrDefault(x => x.SubjectId == subjectId && x.StudentId == studentId);
            if (result == null)
            {
                throw new CustomErrorException("The Item does not exist.", StatusCodes.Status400BadRequest);
            }

            await _repository.DeleteAsync(result.Id);
        }

        private async Task<Grade> DtoToEntityMapping(GradeDto dto)
        {
            var student = await _studentRepository.GetByIdAsync(dto.StudentId);
            var subject = await _subjectRepository.GetByIdAsync(dto.SubjectId);
            Grade grade = new Grade()
            {
                StudentId = dto.StudentId,
                SubjectId = dto.SubjectId,
                GradeValue = dto.GradeValue,  
                Subject = subject,
                Student = student
            };
            return grade;
        }

        private List<GradeDto> GradesEntityToDtoMApping(List<Grade> entityList)
        {
            var gradeDtos = new List<GradeDto>();

            foreach (Grade enity in entityList)
            {
                var gradeDto = new GradeDto();                
                gradeDto.StudentId = enity.StudentId;
                gradeDto.SubjectId = enity.SubjectId;
                gradeDto.GradeValue = enity.GradeValue;               
                gradeDtos.Add(gradeDto);
            }

            return gradeDtos;

        }

    }
}
