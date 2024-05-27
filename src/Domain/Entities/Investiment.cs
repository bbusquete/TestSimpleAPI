namespace Domain.Entities
{
    public class Investiment
    {
        public int IdUser { get; set; }
        public string Symbol { get; set; }
        public decimal Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }

    }
}