namespace Spg.Sayonara.DomainModel.Model 
{
    public class Product
    {
        private int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateOnly ExpiryDate { get; set; }
    }
} 
