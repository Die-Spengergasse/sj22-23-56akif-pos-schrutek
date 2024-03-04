using Spg.Sayonara.DomainModel.Dtos;
using Spg.Sayonara.DomainModel.Exceptions;
using Spg.Sayonara.DomainModel.Interfaces;
using Spg.Sayonara.DomainModel.Model;
using Spg.Sayonara.Infrastructure;
using Spg.Sayonara.Repository;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.Application.Servcies
{
    public class ProductService : IReadOnlyProductService, IWritableProductService
    {
        private readonly SayonaraContext _context;
        private readonly IDateTimeService _dateTimeService;
        private readonly IReadOnlyCategoryRepository _categoryRepository;

        public ProductService(
            SayonaraContext context, 
            IDateTimeService dateTimeService, 
            IReadOnlyCategoryRepository categoryRepository)
        {
            //_context = new SayonaraContext();
            _dateTimeService = dateTimeService;
            _categoryRepository = categoryRepository;
            _context = context;
        }

        /// <summary>
        /// Legt ein neues Produkt an.
        /// </summary>
        /// <remarks>
        /// Produkt wird nur angelegt, bei folgende Bedingungen:
        /// * Die Kategorie muss vorhanden sein
        /// * Der Name muss innerhalb einer Kategorie eindeutig sein
        /// * Das Ablaufdatum muss mind. 14 Tage in der Zukunft liegen
        /// * Das Produkt muss verfügbar sein.
        /// * Maximale Anzahl
        /// * Das Produkt muss einen gültigen Normalpreis haben
        /// * User darf das tun
        /// </remarks>
        /// <exception cref="DomainModel.Exceptions.ProductServiceCreateException">
        /// Wird geworfen, wenn beim speichern etwas schief gegangen ist.
        /// </exception>
        /// <exception cref="DomainModel.Exceptions.ProductServiceValidationException">
        /// Wird geworfen, wenn eine Bedingung nicht zutrifft.
        /// </exception>
        /// <returns>Gibt erstamal 0 zurück.</returns>
        /// <example>
        /// var result = Create("asdasd", "asdasdasdsdadsaasd", new DateTime.Now);
        /// </example>
        /// <permission cref=""
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="expiryDate"></param>
        public int Create(CreateProductCommand command)
        {
            // Init (Product benötigt eine Category)
            Category existingCategory = _categoryRepository.GetCategoryOrDefault(command.CategoryId) 
                ?? throw new ProductServiceValidationException("Kategorie wurde nicht gefunden!");

            // Validation

            // Act
            Product product = new Product(command.Name, command.Description, command.ExpiryDate, existingCategory);

            // Persist
            _context.Products.Add(product);
            _context.SaveChanges();

            return 0;
        }
    }
}
