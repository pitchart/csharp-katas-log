using BookInvoicing.Domain.Book;
using BookInvoicing.Domain.Country;

namespace BookInvoicing.Tests
{
    public partial class ReportGeneratorTests
    {
        public class AuthorBuilder
        {
            private string _name = "";
            private Country _country = CountryBuilder.Usa();

            public static AuthorBuilder Create()
            {
                return new AuthorBuilder();
            }

            public AuthorBuilder WithName(string name)
            {
                _name = name;
                return this;
            }

            public AuthorBuilder WithCountry(Country country)
            {
                _country = country;
                return this;
            }

            public Author Build()
            {
                return new Author(_name, _country);
            }
        }
    }

}
