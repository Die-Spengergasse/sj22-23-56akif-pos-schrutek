﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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

        public int Id { get; set; } // PK, wird von der DB erstellt, int/long macht auto increment
        public string Name { get; set; }
        public string? CompanySuffix { get; set; } // in DB Allow NULL
        public Address? Address { get; set; }
        public PhoneNumber PhoneNumber { get; set; } = default!;

        private List<Category> _categories = new();
        private string name = string.Empty;

        public IReadOnlyList<Category> Categories => _categories;

        //public EMail EMail { get; set; } // kommt später, weil Set<EMail>

        public Shop AddCategory(Category newCategory)
        {
            // TODO: Checks, Properties setzen, ...
            if (newCategory is not null)
            {
                newCategory.ShopNavigation = this;
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
    }
}
