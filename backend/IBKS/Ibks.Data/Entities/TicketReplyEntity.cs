using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibks.Data.Entities
{
    public class TicketReplyEntity
    {
        public int ReplyId { get; set; }
        public long Tid { get; set; } 
        public string Reply { get; set; } 
        public DateTime ReplyDate { get; set; }
        public TicketEntity Ticket { get; set; }
    }
}
