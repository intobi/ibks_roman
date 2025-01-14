using Ibks.Models.TicketReplyModels;
using Newtonsoft.Json;

namespace Ibks.Models.TicketModels
{
    public class TicketModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Module { get; set; }
        public int Lvl { get; set; } 
        public int Type { get; set; } 
        public int State { get; set; } 
        public string Description { get; set; }
        public List<TicketReplyModel> Replies { get; set; } 
    }
}
