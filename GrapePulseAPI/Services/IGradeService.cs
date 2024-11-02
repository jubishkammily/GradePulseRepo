using GradePulseAPI.DTOs;

namespace GradePulseAPI.Services
{
    public interface IGradeService
    {
        Task<int> AddGradeAsync(GradeDto dto);

        Task<IEnumerable<GradeExtendedDto>> GetAllGradesAsync();

        Task<List<StudentGradeCrosstabDto>> GetGradesCrosstabAsync();
        Task UpdateGradeAsync(GradeDto dto);

        Task DeleteAsync(int subjectId, int studentId);
    }
}
