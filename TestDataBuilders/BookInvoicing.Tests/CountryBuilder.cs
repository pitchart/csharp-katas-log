using BookInvoicing.Domain.Country;

namespace BookInvoicing.Tests
{
    public class CountryBuilder
    {
        private string _name = "";

        private Currency _currency = Currency.Euro;

        private Language _language = Language.English;

        public static CountryBuilder Create()
        {
            return new CountryBuilder();
        }

        public CountryBuilder Named(string name)
        {
            _name = name;

            return this;
        }

        public CountryBuilder WithCurrency(Currency currency)
        {
            _currency = currency;

            return this;
        }

        public CountryBuilder Speaking(Language language)
        {
            _language = language;

            return this;
        }

        public Country Build()
        {
            return new Country(_name, _currency, _language);
        }

        public static Country Usa()
        {
            return new Country("Usa", Currency.UsDollar, Language.English);
        }
    }

}
