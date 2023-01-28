using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkEx
{
    public partial class Student
    {
        public Student()
        {
            GradeRecords = new HashSet<GradeRecord>();
        }
        [Key]
        public int PersonalNumber { get; set; }
        public string StudentName { get; set; } = null!;
        public string StudentLastName { get; set; } = null!;
        public string Class { get; set; } = null!;

        public virtual ICollection<GradeRecord> GradeRecords { get; set; }
    }
}
