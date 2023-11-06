namespace bank_api.Models
{
    public class Wallet
    {
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public decimal CurrentValue { get; set; }
        public string? Bank { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
