using System;
using System.Text;
using FluentAssertions;
using language_ext.kata.Persons;
using LanguageExt;
using LanguageExt.UnsafeValueAccess;
using Xunit;
using static LanguageExt.Prelude;

namespace language_ext.kata.tests
{
    public class OptionExercises : PetDomainKata
    {
        [Fact]
        public void FilterAListOfPerson()
        {
            // Filter this list with only defined persons
            var persons = Seq(None, Some(new Person("John", "Doe")), Some(new Person("Mary", "Smith")), None);

            Seq<Person> definedPersons = persons.Filter(option => option.IsSome).Map(option => option.ValueUnsafe());

            definedPersons.Should().HaveCount(2);
        }

        [Fact]
        public void WorkingWithNull()
        {
            // Instantiate a None Option of string
            // map it to an Upper case function
            // then it must return the string "Ich bin empty" if empty
            var iamAnOption = Option<string>.None;
            string optionValue = iamAnOption.Map(s1 => s1.ToUpper()).IfNone("Ich bin empty");
            
            iamAnOption.IsNone.Should().BeTrue();
            optionValue.Should().Be("Ich bin empty");
        }

        [Fact]
        public void FindKaradoc()
        {
            // Find Karadoc in the people List or returns Perceval
            var foundPersonLastName = people
                .Find(person => person.LastName.Equals("Karadoc"))
                .Map(option => option.LastName)
                .IfNone("Perceval");

            foundPersonLastName.Should().Be("Perceval");
        }

        [Fact]
        public void FindPersonOrDieTrying()
        {
            // Find a person matching firstName and lastName, throws an ArgumentException if not found
            var firstName = "Rick";
            var lastName = "Sanchez";

            Func<Person> findPersonOrDieTrying = () => people
                .Find(person => person.Named($"{firstName} {lastName}"))
                .Match(p => p, () => throw new ArgumentException());

            findPersonOrDieTrying.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ChainCall()
        {
            // Chain calls to the half method 4 times with start in argument
            // For each half append the value to the resultBuilder (side effect)
            double start = 500d;
            StringBuilder resultBuilder = new StringBuilder();

            Option<double> result = Option<double>
                .Some(start);
            for (int i = 0; i < 4; i++)
            {
                result = result.Bind(Half)
                    .Bind(d =>
                    {
                        resultBuilder.Append(d.ToString());
                        return Option<double>.Some(d);
                    });
            }

            result.IsNone.Should().BeTrue();
            resultBuilder.ToString().Should().Be("250125");
        }

        private Option<double> Half(double x)
            => x % 2 == 0 ? Some(x / 2) : None;
    }
}
