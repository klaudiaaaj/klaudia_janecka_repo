using System;
using System.Collections.Generic;

namespace DanceSchool_10._05_ASP.NET_MVC.mydb
{
    public partial class SoloEnrollments
    {
        public int DancerId { get; set; }
        [Key]
        public int TurnamentSoloId { get; set; }

        public virtual Dancer Dancer { get; set; }
        public virtual TurnamentSolo TurnamentSolo { get; set; }
    }
}
