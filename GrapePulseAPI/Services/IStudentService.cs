using GradePulseAPI.DTOs;
using GrapePulseAPI.Models;

namespace GradePulseAPI.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
            
        Task<StudentDto> GetStudentAsync(int id);

        Task<int> AddStudentAsync(StudentDto dto);

        Task UpdateStudentAsync(int id,StudentDto dto);
        Task DeleteAsync(int id);
    }
}
