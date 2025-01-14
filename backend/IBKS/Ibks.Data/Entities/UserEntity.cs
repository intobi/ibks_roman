namespace Ibks.Data.Entities
{
    public class UserEntity
    {
        public string OID { get; set; } 
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public DateTime LastScannedUtc { get; set; }
    }
}
