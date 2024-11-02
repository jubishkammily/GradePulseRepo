﻿using GrapePulseAPI.Models;

namespace GradePulseAPI.DTOs
{
    public class GradeDto
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public double GradeValue { get; set; }

    }
}