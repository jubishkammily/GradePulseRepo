﻿namespace GrapePulseAPI.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public ICollection<Grade>? Grades { get; set; }
    }
}
