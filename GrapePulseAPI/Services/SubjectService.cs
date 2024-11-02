using GradePulseAPI.Data.Repository;
using GradePulseAPI.DTOs;
using GrapePulseAPI.Models;

namespace GradePulseAPI.Services
{
    public class SubjectService : ISubjectService
    {
        private IRepository<Subject> _repository;

        public SubjectService(IRepository<Subject> repository)
        {          
            _repository = repository;
        }
        public async Task<int> AddSubjectAsync(SubjectDto dto)
        {
            var subject = SubjectsDtoToEntityMapping(dto);
            return await _repository.AddAsync(subject);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync()
        {
            var subjects = await _repository.GetAllAsync();
            var subjectsDtos = SubjectsEntityToDtoMApping((List<Subject>)subjects);
            return subjectsDtos;
        }

        public async Task<SubjectDto> GetSubjectAsync(int id)
        {
            var subject = await _repository.GetByIdAsync(id);
            var subjectDto = SubjectsEntityToDtoMApping(subject);
            return subjectDto;
        }

        public async Task UpdateSubjectAsync(int id, SubjectDto dto)
        {
            Subject subject = await _repository.GetByIdAsync(id);
            subject.Name = dto.Name;            
            await _repository.UpdateAsync(subject);
        }

        private Subject SubjectsDtoToEntityMapping(SubjectDto dto)
        {
            Subject subject = new Subject()
            {
                Name = dto.Name,                
            };
            return subject;
        }

        private SubjectDto SubjectsEntityToDtoMApping(Subject entity)
        {
            var subjectDto = new SubjectDto()
            {
                Id = entity.Id,
                Name = entity.Name
            };
           
            return subjectDto;
        }

        private List<SubjectDto> SubjectsEntityToDtoMApping(List<Subject> entityList)
        {
            var subjectDtos = new List<SubjectDto>();
            foreach (var entity in entityList)
            {
                var subjectDto = new SubjectDto();
                subjectDto.Id = entity.Id;
                subjectDto.Name = entity.Name;
                subjectDtos.Add(subjectDto);
            }
            return subjectDtos;

        }
    }
}
