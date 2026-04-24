using rest_with_asp_net_10.Domain;

namespace rest_with_asp_net_10.DTOs.Mappings
{
    public static class PersonDTOMappingExtensions
    {
        public static PersonDTO? ToPersonDTO(this Person person)
        {
            if (person is null)
                return null;

            return new PersonDTO
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Address = person.Address,
                Gender = person.Gender
            };
        }

        public static Person? ToPerson(this PersonDTO personDTO)
        {
            if (personDTO is null)
                return null;

            return new Person
            {
                Id = personDTO.Id,
                FirstName = personDTO.FirstName,
                LastName = personDTO.LastName,
                Address = personDTO.Address,
                Gender = personDTO.Gender
            };
        }

        public static IEnumerable<PersonDTO>? ToPersonDTOList(this IEnumerable<Person> persons)
        {
            if (persons is null || !persons.Any())
                return new List<PersonDTO>();

            return persons.Select(p => new PersonDTO()
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Address = p.Address,
                Gender = p.Gender
            }).ToList();
        }
    }
}