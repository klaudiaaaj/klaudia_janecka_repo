using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DanceSchool_10._05_ASP.NET_MVC.mydb
{
    public partial class Class
    { [Key]
        public int ClassId { get; set; }
        public string DancestyleId { get; set; }
        public int GroupId { get; set; }
        public int Weekday { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public int? Long { get; set; }
        public int? ClassroomId { get; set; }

        public virtual Classroom Classroom { get; set; }
        public virtual Group Group { get; set; }
    }
}
