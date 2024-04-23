using Spg.Sayonara.DomainModel.Dtos;
using Spg.Sayonara.DomainModel.Interfaces;

namespace Spg.Sayonara.DomainModel.Model 
{
    public class Product : IFindableByGuid
    {
        private Product()
        { }
        public Product(Guid guid, string name, string description, DateTime expiryDate)
        {
            Guid = guid;
            Name = name;
            Description = description;
            ExpiryDate = expiryDate;
        }
        public Product(Guid guid, string name, string description, DateTime expiryDate, Category categoryNavigation)
        {
            Guid = guid;
            Name = name;
            Description = description;
            ExpiryDate = expiryDate;
            CategoryNavigation = categoryNavigation;
        }

        public int Id { get; set; }
        public Guid Guid { get; private set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }

        public int? CategoryId { get; set; }
        public Category? CategoryNavigation { get; set; } = default!; // Navigational Property

        public ProductDto ToDto()
        {
            return new ProductDto(Name, Description, ExpiryDate, Guid);
        }

        public Product FromDto(CreateProductCommand dto)
        {
            return new Product(new Guid(), dto.Name, dto.Description, dto.ExpiryDate);
        }
    }
} 
