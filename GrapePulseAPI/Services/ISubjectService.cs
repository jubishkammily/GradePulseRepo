using GradePulseAPI.DTOs;

namespace GradePulseAPI.Services
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync();

        Task<SubjectDto> GetSubjectAsync(int id);

        Task<int> AddSubjectAsync(SubjectDto dto);

        Task UpdateSubjectAsync(int id, SubjectDto dto);
        Task DeleteAsync(int id);
    }
}
