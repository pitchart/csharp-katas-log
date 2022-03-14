using System;
using language_ext.kata.Persons;
using LanguageExt;
using static LanguageExt.Prelude;

namespace language_ext.kata.tests
{
    public abstract class PetDomainKata
    {
        protected Seq<Person> people;
        protected Seq<Park> parks;

        public PetDomainKata()
        {
            people = Seq(new Person("Mary", "Smith").AddPet(PetType.Cat, "Tabby", 2),
                new Person("Bob", "Smith")
                    .AddPet(PetType.Cat, "Dolly", 3)
                    .AddPet(PetType.Dog, "Spot", 2),
                new Person("Ted", "Smith").AddPet(PetType.Dog, "Spike", 4),
                new Person("Jake", "Snake").AddPet(PetType.Snake, "Serpy", 1),
                new Person("Barry", "Bird").AddPet(PetType.Bird, "Tweety", 2),
                new Person("Terry", "Turtle").AddPet(PetType.Turtle, "Speedy", 1),
                new Person("Harry", "Hamster")
                    .AddPet(PetType.Hamster, "Fuzzy", 1)
                    .AddPet(PetType.Hamster, "Wuzzy", 1),
                new Person("John", "Doe"));

            parks = Seq(new Park("Jurassic")
                    .AddAuthorizedPetType(PetType.Bird)
                    .AddAuthorizedPetType(PetType.Snake)
                    .AddAuthorizedPetType(PetType.Turtle),
                new Park("Central")
                    .AddAuthorizedPetType(PetType.Bird)
                    .AddAuthorizedPetType(PetType.Cat)
                    .AddAuthorizedPetType(PetType.Dog),
                new Park("Hippy")
                    .AddAuthorizedPetType(PetType.Bird)
                    .AddAuthorizedPetType(PetType.Cat)
                    .AddAuthorizedPetType(PetType.Dog)
                    .AddAuthorizedPetType(PetType.Turtle)
                    .AddAuthorizedPetType(PetType.Hamster)
                    .AddAuthorizedPetType(PetType.Snake));
        }

        protected Person GetPersonNamed(string fullName) =>
            people.Find(p => p.Named(fullName))
                .IfNone(() => throw new ArgumentException("Can't find person named: " + fullName));
    }
}
