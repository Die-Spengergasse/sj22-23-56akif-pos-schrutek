﻿using Spg.Sayonara.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.Test
{
    public class ModelLogicTests
    {
        [Fact()]
        public void ShouldAddOneCategory_WhenCategoryisNOTNULL()
        {
            // Arrange
            Shop newShop = new Shop(
                "MyShop",
                "WasWeißIch",
                    new Address("Street1", "4711", "City1", "1324"),
                    new PhoneNumber("0123", "123456789")
                );

            // Act
            newShop.AddCategory(new Category("Kleidung"));

            // Assert
            Assert.Equal(1, newShop.Categories.Count);
        }

        [Fact()]
        public void ShouldNOTAddOneCategory_WhenCategoryISNULL()
        {
            // Arrange
            Shop newShop = new Shop(
                "MyShop",
                "WasWeißIch",
                    new Address("Street1", "4711", "City1", "1324"),
                    new PhoneNumber("0123", "123456789")
                );

            // Act
            newShop.AddCategory(null!);

            // Assert
            Assert.Equal(0, newShop.Categories.Count);
        }

        [Fact()]
        public void ShouldSetNavigationalPropertyToCategory_WhenCategoryIsAdded()
        {
            // Arrange
            Shop newShop = new Shop(
                "MyShop",
                "WasWeißIch",
                    new Address("Street1", "4711", "City1", "1324"),
                    new PhoneNumber("0123", "123456789")
                );

            // Act
            newShop.AddCategory(new Category("Kleidung"));

            // Assert
            Assert.Equal(newShop, newShop.Categories.First().ShopNavigation);
        }
    }
}
