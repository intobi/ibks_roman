using Ibks.Models.TicketReplyModels;
using Newtonsoft.Json;

namespace Ibks.Models.TicketModels
{
    public class TicketModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Module { get; set; }
        public string Lvl { get; set; } 
        public string Type { get; set; } 
        public string State { get; set; } 
        public string Description { get; set; }
        public List<TicketReplyModel> Replies { get; set; } 
    }
}
