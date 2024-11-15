using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class MessageType
    {
        public int MessageType_Id { get; set; }
        public bool isForInternalUse { get; set; }
        public string MessageType_Name { get; set; }
        public int MessageType_Order { get; set; }
        public string MessageType_SpecialFeature { get; set; }
    }
}
