using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class User
    {
        public Guid? User_GUID { get; set; }
        public string User_Name { get; set; }
        public string Hotel_Code { get; set; }
        public Guid? Hotel_GUID { get; set; }
        public int Timezone_offsetInMins { get; set; }
    }
}
