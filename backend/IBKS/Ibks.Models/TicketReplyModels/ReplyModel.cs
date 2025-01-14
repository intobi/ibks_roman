namespace Ibks.Models.TicketReplyModels
{
    public class ReplyModel
    {
        public long ReplyId { get; set; } 
        public long TicketId { get; set; } 
        public string Reply { get; set; } 
        public DateTime ReplyDate { get; set; }
    }
}
