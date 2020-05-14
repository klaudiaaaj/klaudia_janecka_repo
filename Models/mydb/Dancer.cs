using System;
using System.Collections.Generic;

namespace DanceSchool_10._05_ASP.NET_MVC.mydb
{
    public partial class Dancer
    {
        public Dancer()
        {
            GroupHasDancer = new HashSet<GroupHasDancer>();
            SoloEnrollments = new HashSet<SoloEnrollments>();
        }
        [Key]
        public int DancerId { get; set; }
        public int FunctionId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Status { get; set; }
        public int FunctionFunctionId { get; set; }

        public virtual Function Function { get; set; }
        public virtual ICollection<GroupHasDancer> GroupHasDancer { get; set; }
        public virtual ICollection<SoloEnrollments> SoloEnrollments { get; set; }
    }
}
