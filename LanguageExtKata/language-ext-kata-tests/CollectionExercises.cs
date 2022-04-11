using System;
using System.Collections.Generic;
using FluentAssertions;
using FluentAssertions.LanguageExt;
using language_ext.kata.Persons;
using LanguageExt;
using Xunit;
using static language_ext.kata.Persons.PetType;
using static LanguageExt.Prelude;

namespace language_ext.kata.tests
{
    public class CollectionExercises : PetDomainKata
    {
        [Fact]
        public void GetFirstNamesOfAllPeople()
        {
            // Replace it, with a transformation method on people.
            Seq<string> firstNames = people.Map(person => person.FirstName);
            Seq<string> expectedFirstNames = Seq("Mary", "Bob", "Ted", "Jake", "Barry", "Terry", "Harry", "John");

            firstNames.Should().BeEquivalentTo(expectedFirstNames);
        }

        [Fact]
        public void GetNamesOfMarySmithsPets()
        {
            var person = GetPersonNamed("Mary Smith");

            // Replace it, with a transformation method on people.
            Seq<string> names = person.Pets.Map(pet => pet.Name);

            names.Single()
                .Should()
                .Be("Tabby");
        }

        [Fact]
        public void GetPeopleWithCats()
        {
            // Replace it, with a positive filtering method on people.
            Seq<Person> peopleWithCats = people.Filter(person => person.HasPetType(Cat));

            peopleWithCats.Should().HaveCount(2);
        }

        [Fact]
        public void GetPeopleWithoutCats()
        {
            // Replace it, with a negative filtering method on Seq.
            Seq<string> peopleWithoutCats = Seq<string>();

            peopleWithoutCats.Should().HaveCount(6);
        }

        [Fact]
        public void DoAnyPeopleHaveCats()
        {
            //replace null with a Predicate lambda which checks for PetType.CAT
            var doAnyPeopleHaveCats = people.Any(person => person.HasPetType(Cat));
            var doAnyPeopleHaveCatsAlter = people.Find(person => person.HasPetType(Cat));

            doAnyPeopleHaveCats.Should().BeTrue();
            doAnyPeopleHaveCatsAlter.Should().BeSome();
        }

        [Fact]
        public void DoAllPeopleHavePets()
        {
            Func<Person, bool> predicate = p => true;
            // OR use local functions -> static bool predicate(Person p) => p.IsPetPerson();
            // replace with a method call send to this.people that checks if all people have pets
            var result = people.ForAll(predicate);

            result.Should().BeFalse();
        }

        [Fact]
        public void HowManyPeopleHaveCats()
        {
            // replace 0 with the correct answer
            var count = 0;
            count.Should().Be(2);
        }

        [Fact]
        public void FindMarySmith()
        {
            Person result = null;

            result.FirstName.Should().Be("Mary");
            result.LastName.Should().Be("Smith");
        }

        [Fact]
        public void GetPeopleWithPets()
        {
            // replace with only the pets owners
            Seq<Person> petPeople = Seq<Person>();

            petPeople.Should().HaveCount(7);
        }

        [Fact]
        public void GetAllPetTypesOfAllPeople()
        {
            Seq<PetType> petTypes = people.Bind(p => p.Pets.Map(pet => pet.Type)).Distinct();

            petTypes.Should()
                .BeEquivalentTo(Seq(Cat, Dog, Snake, Bird, Turtle, Hamster));
        }

        [Fact]
        public void TotalPetAge()
        {
            var totalAge = 0L;
            totalAge.Should().Be(17L);
        }

        [Fact]
        public void PetsNameSorted()
        {
            string sortedPetNames = people.Bind(p => p.Pets.Map(pet => pet.Name))
                .OrderBy(p => p)
                .ToSeq()
                .ToFullString();

            sortedPetNames.Should()
                .Be("Dolly, Fuzzy, Serpy, Speedy, Spike, Spot, Tabby, Tweety, Wuzzy");
        }

        [Fact]
        public void SortByAge()
        {
            // Create a Seq<int> with ascending ordered age values.
            Seq<int> sortedAgeList = Seq<int>();

            sortedAgeList.Should()
                .HaveCount(4)
                .And
                .BeEquivalentTo(Seq(1, 2, 3, 4));
        }

        [Fact]
        public void SortByDescAge()
        {
            // Create a Seq<int> with descending ordered age values.
            Seq<int> sortedAgeList = Seq<int>();

            sortedAgeList.Should()
                .HaveCount(4)
                .And
                .BeEquivalentTo(Seq(4, 3, 2, 1));
        }

        [Fact]
        public void Top3OlderPets()
        {
            // Create a Seq<string> with the 3 older pets.
            Seq<string> top3OlderPets = Seq<string>();

            top3OlderPets.Should()
                .HaveCount(3)
                .And
                .BeEquivalentTo(Seq("Spike", "Dolly", "Tabby"));
        }

        [Fact]
        public void GetFirstPersonWithAtLeast2Pets()
        {
            // Find the first person who owns at least 2 pets
            var firstPersonWithAtLeast2Pets = Option<Person>.None;

            firstPersonWithAtLeast2Pets.GetUnsafe()
                .Should()
                .Be("Bob");
        }

        [Fact]
        public void IsThereAnyPetOlderThan4()
        {
            // Check whether any exercises older than 4 exists or not
            var isThereAnyPetOlderThan4 = true;

            isThereAnyPetOlderThan4.Should().BeFalse();
        }

        [Fact]
        public void IsEveryPetsOlderThan1()
        {
            // Check whether all pets are older than 1 or not
            var allOlderThan1 = false;

            allOlderThan1.Should().BeTrue();
        }

        [Fact]
        public void GetListOfPossibleParksForAWalkPerPerson()
        {
            // For each person described as "firstName lastName" returns the list of names possible parks to go for a walk
            Dictionary<string, Seq<string>> possibleParksForAWalkPerPerson =
                people.ToDictionary(p => p.FirstName + " " + p.LastName,
                    p => FilterParksFor(p.Pets.Map(pet => pet.Type)));

            possibleParksForAWalkPerPerson["John Doe"]
                .Should()
                .BeEquivalentTo(Seq("Jurassic", "Central", "Hippy"));

            possibleParksForAWalkPerPerson["Jake Snake"]
                .Should()
                .BeEquivalentTo(Seq("Jurassic", "Hippy"));
        }

        private Seq<string> FilterParksFor(Seq<PetType> petTypes)
            => parks.Filter(park => petTypes.Except(park.AuthorizedPetTypes).ToSeq().Count == 0)
                .Map(park => park.Name);
    }
}
