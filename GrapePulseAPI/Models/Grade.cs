﻿namespace GrapePulseAPI.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public string GradeValue { get; set; }

        public Student? Student { get; set; }
        public Subject? Subject { get; set; }

    }
}
