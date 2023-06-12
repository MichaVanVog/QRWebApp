namespace QR.Db.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateOnly ProductionDate { get; set; }
        public DateOnly ExpireDate { get; set; }
        public Location Location { get; set; }
    }
}
