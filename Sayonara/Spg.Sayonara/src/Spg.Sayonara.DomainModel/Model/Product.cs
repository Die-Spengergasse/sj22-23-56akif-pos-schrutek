using Spg.Sayonara.DomainModel.Dtos;

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
        public Product(string name, string description, DateTime expiryDate, Category categoryNavigation)
        {
            Name = name;
            Description = description;
            ExpiryDate = expiryDate;
            CategoryNavigation = categoryNavigation;
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;    // PK
        public string Description { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }

        public int? CategoryId { get; set; }
        public Category? CategoryNavigation { get; set; } = default!; // Navigational Property

        public ProductDto ToDto()
        {
            return new ProductDto(Name, Description, ExpiryDate);
        }

        public Product FromDto(CreateProductCommand dto)
        {
            return new Product(dto.Name, dto.Description, dto.ExpiryDate);
        }
    }
} 
