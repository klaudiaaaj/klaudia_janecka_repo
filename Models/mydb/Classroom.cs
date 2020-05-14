using System;
using System.Collections.Generic;

namespace DanceSchool_10._05_ASP.NET_MVC.mydb
{
    public partial class Classroom
    {

        public Classroom()
        {
            Class = new HashSet<Class>();
        }
        [Key]
        public int ClassroomId { get; set; }
        public short? Free { get; set; }
        public TimeSpan? Hour { get; set; }
        public int? Weekday { get; set; }

        public virtual ICollection<Class> Class { get; set; }
    }
}
