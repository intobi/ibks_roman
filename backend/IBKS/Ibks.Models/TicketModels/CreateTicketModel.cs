namespace Ibks.Models.TicketModels
{
    public class CreateTicketModel
    {
        public string Title { get; set; }
        public string Module { get; set; }
        public string Lvl { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
    }
}
