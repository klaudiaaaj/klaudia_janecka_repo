using System;
using System.Collections.Generic;

namespace DanceSchool_10._05_ASP.NET_MVC.mydb
{
    public partial class TurnamentSolo
    {
        public int DancerId { get; set; }
        public int? Place { get; set; }
        public string Aword { get; set; }
        public DateTime? Data { get; set; }
        public string TurnamentName { get; set; }
        public string City { get; set; }
        public int TurnamentSoloId { get; set; }

        public virtual SoloEnrollments SoloEnrollments { get; set; }
    }
}
