using System;
using System.Collections.Generic;

namespace DanceSchool_10._05_ASP.NET_MVC.mydb
{
    public partial class Function
    {
        public Function()
        {
            Dancer = new HashSet<Dancer>();
        }
        [Key]
        public int FunctionId { get; set; }
        public string FunctionName { get; set; }

        public virtual ICollection<Dancer> Dancer { get; set; }
    }
}
