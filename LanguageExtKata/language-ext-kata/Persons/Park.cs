using LanguageExt;

namespace language_ext.kata.Persons
{
    public class Park
    {
        public string Name { get; }
        public Seq<PetType> AuthorizedPetTypes { get; }

        public Park(string name)
            : this(name, Seq<PetType>.Empty)
        {
        }

        public Park(string name, Seq<PetType> authorizedPetTypes)
        {
            Name = name;
            AuthorizedPetTypes = authorizedPetTypes;
        }

        public Park AddAuthorizedPetType(PetType petType) => new(Name, AuthorizedPetTypes.Add(petType));
    }
}
