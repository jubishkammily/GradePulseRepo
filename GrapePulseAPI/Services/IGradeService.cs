using GradePulseAPI.DTOs;

namespace GradePulseAPI.Services
{
    public interface IGradeService
    {
        Task<int> AddGradeAsync(GradeDto dto);

        Task<IEnumerable<GradeExtendedDto>> GetAllGradesAsync();

        Task<List<StudentGradeCrosstabDto>> GetGradesCrosstabAsync();
    }
}
