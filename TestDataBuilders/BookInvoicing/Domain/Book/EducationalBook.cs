using System;
using BookInvoicing.Domain.Country;

namespace BookInvoicing.Domain.Book
{
    public sealed class EducationalBook : IBook
    {
        public string Name { get; }
        public double Price { get; }
        public Author Author { get; }
        public Language Language { get; }
        public Category Category { get; }

        public EducationalBook(string name, double price, Author author, Language language, Category category)
        {
            Name = name;
            Price = price;
            Author = author;
            Language = language;
            Category = category;
        }

        public override string ToString() => $"EducationalBook [ {nameof(Name)}: {Name}" +
                                             $", {nameof(Price)}: '{Price}'" +
                                             $", {nameof(Author)}: '{Author}'" +
                                             $", {nameof(Language)}: '{Language}'" +
                                             $", {nameof(Category)}: '{Category}' ]";

        private bool Equals(EducationalBook other) => Name == other.Name
                                                      && Price.Equals(other.Price)
                                                      && Equals(Author, other.Author)
                                                      && Language == other.Language
                                                      && Category == other.Category;

        public override bool Equals(object obj) => ReferenceEquals(this, obj)
                                                   || obj is EducationalBook other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Name, Price, Author, (int) Language, (int) Category);
    }
}
