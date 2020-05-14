using System;
using System.Collections.Generic;

namespace DanceSchool_10._05_ASP.NET_MVC.mydb
{
    public partial class GroupEnrollments
    {
        public int TurnamentGroupId { get; set; }
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
    }
}
