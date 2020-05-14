using System;
using System.Collections.Generic;

namespace DanceSchool_10._05_ASP.NET_MVC.mydb
{
    public partial class DanceStyle
    {
        public DanceStyle()
        {
            Group = new HashSet<Group>();
        }
        [Key]
        public int DancestyleId { get; set; }
        public string DancestyleName { get; set; }

        public virtual ICollection<Group> Group { get; set; }
    }
}
