using System;
using System.Collections.Immutable;
using System.Linq;
using LanguageExt;

namespace language_ext.kata.Persons
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Seq<Pet> Pets { get; set; }

        public Person(string firstName, string lastName)
            : this(firstName, lastName, Seq<Pet>.Empty)
        {
        }

        public Person(string firstName, string lastName, Seq<Pet> pets)
        {
            FirstName = firstName;
            LastName = lastName;
            Pets = pets;
        }

        public bool Named(string fullName) => fullName.Equals(FirstName + " " + LastName);

        public ImmutableDictionary<PetType, int> GetPetTypes() =>
            Pets.GroupBy(p => p.Type)
                .ToDictionary(g => g.Key, g => g.Count())
                .ToImmutableDictionary();

        public bool HasPetType(PetType type) =>
            GetPetTypes()
                .ContainsKey(type);

        public Person AddPet(PetType petType, string name, int age) =>
            new(FirstName, LastName, Pets.Add(new Pet(petType, name, age)));

        public bool IsPetPerson() => GetNumberOfPets >= 1;

        public int GetNumberOfPets => Pets.Count;
    }
}
