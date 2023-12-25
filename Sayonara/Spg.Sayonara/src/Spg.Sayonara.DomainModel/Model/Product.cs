namespace Spg.Sayonara.DomainModel.Model 
{
    public class Product
    {
        private Product()
        { }
        public Product(string name, string description, DateTime expiryDate)
        {
            Name = name;
            Description = description;
            ExpiryDate = expiryDate;
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
    }
} 
