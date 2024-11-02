using GradePulseAPI.Data.Repository;
using GradePulseAPI.DTOs;
using GrapePulseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GradePulseAPI.Services
{
    public class GradeService : IGradeService
    {
        private IRepository<Grade> _repository;

        public GradeService(IRepository<Grade> repository)
        {
            _repository = repository;
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
                return 0;
            }

            var grade = DtoToEntityMapping(dto);
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

        private Grade DtoToEntityMapping(GradeDto dto)
        {
            Grade grade = new Grade()
            {
                StudentId = dto.StudentId,
                SubjectId = dto.SubjectId,
                GradeValue = dto.GradeValue,                
            };
            return grade;
        }

        private List<GradeDto> GradesEntityToDtoMApping(List<Grade> entityList)
        {
            var gradeDtos = new List<GradeDto>();

            foreach (Grade enity in entityList)
            {
                var gradeDto = new GradeDto();
                gradeDto.Id = enity.Id;
                gradeDto.StudentId = enity.StudentId;
                gradeDto.SubjectId = enity.SubjectId;
                gradeDto.GradeValue = enity.GradeValue;               
                gradeDtos.Add(gradeDto);
            }

            return gradeDtos;

        }

    }
}
