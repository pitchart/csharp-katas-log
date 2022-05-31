using BookInvoicing.Domain.Book;
using BookInvoicing.Domain.Country;
using BookInvoicing.Purchase;
using BookInvoicing.Report;
using BookInvoicing.Tests.Storage;
using System;
using System.Collections.Generic;
using Xunit;

namespace BookInvoicing.Tests
{
    public partial class ReportGeneratorTests
    {
        [Fact]
        public void ShouldComputeTotalAmount_WithoutDiscount_WithoutTaxExchange()
        {
            // Arrange
            var inMemoryRepository = OverrideRepositoryForTests();

            ReportGenerator generator = new ReportGenerator();

            Country usa = CountryBuilder.Usa();

            Author author = AuthorBuilder
                .Create()
                .WithName("Uncle Bob")
                .WithCountry(usa)
                .Build();

            EducationalBook book = EducationalBookBuilder
                .Create()
                .WithName("Clean Code")
                .WithPrice(25)
                .WithAuthor(author)
                .WithLanguage(Language.English)
                .WithCategory(Category.Computer)
                .Build();

            var purchasedBook = new PurchasedBook(book, 2);

            Invoice invoice = InvoiceBuilder
                .AnInvoice()
                .InUSA()
                .Build();
                
            invoice.AddPurchasedBooks(new List<PurchasedBook> { purchasedBook });

            // Act
            inMemoryRepository.AddInvoice(invoice);

            // Assert
            Assert.Equal(50, generator.GetTotalAmount());
            Assert.Equal(1, generator.GetNumberOfIssuedInvoices());
            Assert.Equal(2, generator.GetTotalSoldBooks());

            ResetTestsRepository();
        }

        [Fact]
        public void ShouldComputeTotalAmount_WithDiscount_WithTaxExchanges()
        {
            // Arrange
            var inMemoryRepository = OverrideRepositoryForTests();
            ReportGenerator generator = new ReportGenerator();

            var book = new Novel("A mysterious adventure fiction", 35.5, new Author(
                    "Some Guy", new Country(
                        "France", Currency.Euro, Language.French
                        )
                    ),
                Language.English, new List<Genre> { Genre.Mystery, Genre.AdventureFiction }
            );

            var purchasedBook = new PurchasedBook(book, 3);

            var invoice = new Invoice("John Doe", new Country(
                "Germany", Currency.Euro, Language.German
            ));
            invoice.AddPurchasedBooks(new List<PurchasedBook> { purchasedBook });

            // Act
            inMemoryRepository.AddInvoice(invoice);

            // Assert
            Assert.Equal(106.5, generator.GetTotalAmount());
            Assert.Equal(1, generator.GetNumberOfIssuedInvoices());
            Assert.Equal(3, generator.GetTotalSoldBooks());

            ResetTestsRepository();
        }

        private InMemoryRepository OverrideRepositoryForTests()
        {
            InMemoryRepository inMemoryRepository = new InMemoryRepository();
            MainRepository.Override(inMemoryRepository);
            return inMemoryRepository;
        }

        private void ResetTestsRepository()
        {
            MainRepository.Reset();
        }
    }

    internal class InvoiceBuilder
    {
        private string _customerName= "John Doe";
        private Country _country;

        internal static InvoiceBuilder AnInvoice()
        {
            return new InvoiceBuilder();
        }

        internal Invoice Build()
        {
            return new Invoice(_customerName,_country);
        }

        internal InvoiceBuilder InUSA()
        {
             _country= CountryBuilder.Usa();

           return this;
        }

        internal InvoiceBuilder PurchasedBy(string customerName)
        {
            _customerName = customerName;
            return this;
        }
    }

    public class EducationalBookBuilder
    {
        public string _name;
        private int _price;
        private Author _author;
        private Language _language;
        private Category _category;

        public static EducationalBookBuilder Create()
        {
            return new EducationalBookBuilder();
        }

        public EducationalBookBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public EducationalBookBuilder WithAuthor(Author author)
        {
            _author = author;
            return this;
        }

        public EducationalBookBuilder WithPrice(int price)
        {
            _price = price;
            return this;
        }

        public EducationalBookBuilder WithLanguage(Language language)
        {
            _language = language;
            return this;
        }

        public EducationalBookBuilder WithCategory(Category category)
        {
            _category = category;
            return this;
        }

        public EducationalBook Build()
        {
            return new EducationalBook(_name, _price, _author, _language, _category);
        }
    }
}
