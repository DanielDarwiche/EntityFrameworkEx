using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkEx
{
    public partial class GradeRecord
    {
        [Key]
        public int GradeId { get; set; }
        public string GradeName { get; set; } = null!;
        public int GradeValue { get; set; }
        public DateTime GradeSetDate { get; set; }
        public int TeacherId { get; set; }
        public int StudentId { get; set; }

        public virtual Student Student { get; set; } = null!;
        public virtual staff Teacher { get; set; } = null!;
    }
}
