using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkEx
{
    public partial class staff
    {
        public staff()
        {
            GradeRecords = new HashSet<GradeRecord>();
        }
        [Key]

        public int PersonalNumber { get; set; }
        public string StaffName { get; set; } = null!;
        public string StaffRole { get; set; } = null!;

        public virtual ICollection<GradeRecord> GradeRecords { get; set; }
    }
}
