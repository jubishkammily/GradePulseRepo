using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;

namespace GrapePulseAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public required string Name { get; set; }    
        public DateTime DateOfBirth { get; set; }

        public ICollection<Grade>? Grades { get; set; }
    }
}
