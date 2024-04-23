using Spg.Sayonara.DomainModel.Dtos;
using Spg.Sayonara.DomainModel.Validation.Validators;
using System.ComponentModel.DataAnnotations;

namespace Spg.Sayonara.DomainModel.Model
{
    public class Shop
    {
        public Shop(
            string name,
            string companySuffix,
            Address? address,
            PhoneNumber phoneNumber)
        {
            Name = name;
            CompanySuffix = companySuffix;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        // Wirklich nur, weil EF Core das braucht
        private Shop()
        { }

        public bool IsValid { get; private set; } = true;

        [NoHomerValidator("homer", ErrorMessage = "homer darf nicht rein")]
        [StringLength(maximumLength: 10)]
        public string Name { get; set; } // P.K.
        
        
        public string? CompanySuffix { get; set; } // in DB Allow NULL
        public Address? Address { get; set; }
        public PhoneNumber PhoneNumber { get; set; } = default!;

        private List<Category> _categories = new();

        public IReadOnlyList<Category> Categories => _categories;

        //public EMail EMail { get; set; } // kommt später, weil Set<EMail>

        public Shop AddCategory(Category newCategory)
        {
            // TODO: Checks, Properties setzen, ...
            if (newCategory is not null)
            {
                newCategory.ShopNavigation = this;
                newCategory.ShopName = Name;
                _categories.Add(newCategory);
            }
            return this;
        }

        public Shop AddCategories(IEnumerable<Category> categories)
        {
            var result = categories
                .Where(c => c is not null)
                .Select(c => new Category(c.Name, this));
            _categories.AddRange(result);
            return this;
        }

        public Shop Validate()
        {
            if (Name?.ToString()?.ToLower().Contains("homer") ?? false)
            {
                IsValid = false;
            }
            return this;
        }

        public ShopDto ToDto()
        {
            return new ShopDto(
                Name, 
                CompanySuffix, 
                new AddressDto(Address?.Street, Address?.HouseNumber, Address?.City, Address?.Zipcode), 
                new PhoneNumberDto(PhoneNumber.Prefix, PhoneNumber.Number), 
                new());
        }
    }
}
