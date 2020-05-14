using System;
using System.Collections.Generic;

namespace DanceSchool_10._05_ASP.NET_MVC.mydb
{
    public partial class Group
    {
        public Group()
        {
            Class = new HashSet<Class>();
            GroupEnrollments = new HashSet<GroupEnrollments>();
            GroupHasDancer = new HashSet<GroupHasDancer>();
        }
        [Key]
        public int GroupId { get; set; }
        public string Supervisor { get; set; }
        public string GroupName { get; set; }
        public int DancestyleId { get; set; }

        public virtual DanceStyle Dancestyle { get; set; }
        public virtual ICollection<Class> Class { get; set; }
        public virtual ICollection<GroupEnrollments> GroupEnrollments { get; set; }
        public virtual ICollection<GroupHasDancer> GroupHasDancer { get; set; }
    }
}
