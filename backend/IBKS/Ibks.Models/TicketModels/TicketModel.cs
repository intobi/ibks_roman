using Ibks.Models.TicketReplyModels;

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
        //public long Id { get; set; }
        //public string Title { get; set; }
        //public int ApplicationId { get; set; }
        //public string ApplicationName { get; set; }
        //public string Description { get; set; }
        //public string? Url { get; set; }
        //public string? StackTrace { get; set; }
        //public string? Device { get; set; }
        //public string? Browser { get; set; }
        //public string? Resolution { get; set; }
        //public int PriorityId { get; set; }
        //public int StatusId { get; set; }
        //public int? UserId { get; set; }
        //public string UserOID { get; set; }
        //public int InstalledEnvironmentId { get; set; }
        //public int TicketTypeId { get; set; }
        //public DateTime? Date { get; set; }
        //public bool? Deleted { get; set; }
        //public DateTime? LastModified { get; set; }
        //public string? CreatedByOID { get; set; }
    }
}
