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

        public int Id { get; set; } // PK, wird von der DB erstellt, int/long macht auto increment

        [NoHomerValidator("homer", ErrorMessage = "homer darf nicht rein")]
        [StringLength(maximumLength: 10)]
        public string Name { get; set; }
        
        
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
                newCategory.ShopId = Id;
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
    }
}
