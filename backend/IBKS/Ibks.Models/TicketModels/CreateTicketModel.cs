namespace Ibks.Models.TicketModels
{
    public class CreateTicketModel
    {
        public string Title { get; set; }
        public string Module { get; set; }
        public int Lvl { get; set; }
        public int Type { get; set; }
        public int State { get; set; }
        public string Description { get; set; }
    }
}
