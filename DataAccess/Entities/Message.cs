using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Message
    {
        public int Message_Id { get; set; }
        public DateTime Message_CreatedTime { get; set; }       
        public string Message_From { get; set; }
        public string Message_Title { get; set; }
        public string Message_Body { get; set; }
        public string Message_Priority { get; set; }

        public int Message_Status { get; set; }

    }
}
