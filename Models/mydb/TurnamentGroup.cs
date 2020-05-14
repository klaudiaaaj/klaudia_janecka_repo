using System;
using System.Collections.Generic;

namespace DanceSchool_10._05_ASP.NET_MVC.mydb
{
    public partial class TurnamentGroup
    {
        [Key]
        public int TurnamentGroupId { get; set; }
        public DateTime? Data { get; set; }
        public int GroupId { get; set; }
        public int? Place { get; set; }
        public string Aword { get; set; }
        public int DancestyleId { get; set; }
        public string TurnamentName { get; set; }
        public string City { get; set; }
    }
}
