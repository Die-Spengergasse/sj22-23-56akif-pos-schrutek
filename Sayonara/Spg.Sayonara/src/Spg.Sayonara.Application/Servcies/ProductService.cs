using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ProductService> _logger;
        private readonly IDateTimeService _dateTimeService;
        private readonly IReadOnlyCategoryRepository _categoryRepository;
        private readonly IReadOnlyProductRepository _readOnlyProductRepository;
        private readonly IWritableProductRepository _writableProductRepository;
        private readonly IGuidService _guidService;

        public ProductService(
            ILogger<ProductService> logger,
            IDateTimeService dateTimeService,
            IReadOnlyCategoryRepository categoryRepository,
            IReadOnlyProductRepository readOnlyProductRepository,
            IWritableProductRepository writableProductRepository,
            IGuidService guidService)
        {
            _logger = logger;
            _dateTimeService = dateTimeService;
            _categoryRepository = categoryRepository;
            _readOnlyProductRepository = readOnlyProductRepository;
            _writableProductRepository = writableProductRepository;
            _guidService = guidService;
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
        public ProductDto Create(CreateProductCommand command)
        {
            //_logger.LogInformation($"Parameters for Create(): Name:{command.Name}|Description:{command.Description}|ExpiryDate:{command.ExpiryDate}");

            // Init (Product benötigt eine Category)
            Category existingCategory = _categoryRepository.GetCategoryOrDefault(command.CategoryId)
                ?? throw ProductServiceValidationException.FromCategoryNotFound();

            // Validation
            // * Productname muss pro Kategorie eindeutig sein
            if (_readOnlyProductRepository.ExistsByCategoryOrDefault(existingCategory.Id, command.Name))
            {
                //_logger.LogError();
                throw ProductServiceValidationException.FromNameExists();
            }
            // * Ablaufdatum muss mind. 14 Tge in der zukuft liegen
            if (command.ExpiryDate < DateTime.Now.AddDays(14))
            {
                //_logger.LogError();
                throw ProductServiceValidationException.FromDatenotInFuture();
            }
            // * ...
            // * ...
            // * ...
            // * ...

            // Act
            Product product = new Product(command.Name, command.Description, command.ExpiryDate, existingCategory);
            product.Guid = _guidService.NewGuid(); // alt: Guid.NewGuid(); // Wird nur in der App vergeben

            // Persist
            try
            {
                //_logger.LogInformation("Save...");
                _writableProductRepository.Create(product);
            }
            catch (RepositoryCreateException ex)
            {
                //_logger.LogError();
                throw new ProductServiceCreateException("Methode 'ProductDto Create(CreateProductCommand command)' ist fehlgeschlagen!", ex);
            }

            return product.ToDto();
        }
    }
}
