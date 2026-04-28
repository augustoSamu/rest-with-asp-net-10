using FluentAssertions;
using rest_with_asp_net_10.Domain;
using rest_with_asp_net_10.DTOs.Mappings.V2;
using rest_with_asp_net_10.DTOs.V2;

namespace rest_with_asp_net_10.Tests
{
    public class PersonDTOMappingExtensionsTests
    {
        [Fact]
        public void ToPersonDTO_PersonShouldToPersonDTO()
        {
            Person person = new Person
            {
                Id = 1,
                FirstName = "Son",
                LastName = "Goku",
                Address = "Earth",
                Gender = "Male"
            };

            PersonDTO expectedDto = new PersonDTO
            {
                Id = 1,
                FirstName = "Son",
                LastName = "Goku",
                Address = "Earth",
                Gender = "Male"
            };

            PersonDTO? personDto = person.ToPersonDTO();

            personDto.Should().NotBeNull();
            personDto.Id.Should().Be(expectedDto.Id);
            personDto.FirstName.Should().Be(expectedDto.FirstName);
            personDto.LastName.Should().Be(expectedDto.LastName);
            personDto.Address.Should().Be(expectedDto.Address);
            personDto.Gender.Should().Be(expectedDto.Gender);
        }

        [Fact]
        public void ToPersonDTO_NullPersonShouldReturnNull()
        {
            Person? person = null;
            PersonDTO? personDto = person.ToPersonDTO();
            personDto.Should().BeNull();
        }

        [Fact]
        public void ToPerson_PersonDTOShouldToPerson()
        {
            PersonDTO dto = new PersonDTO
            {
                Id = 2,
                FirstName = "Rei",
                LastName = "Vegeta",
                Address = "Saiyan Planet",
                Gender = "Male",
                BirthDay = new DateTime(2026, 08, 14)
            };

            Person expectedPerson = new Person
            {
                Id = 2,
                FirstName = "Rei",
                LastName = "Vegeta",
                Address = "Saiyan Planet",
                Gender = "Male",
            };

            Person? person = dto.ToPerson();

            person.Should().NotBeNull();
            person.Id.Should().Be(expectedPerson.Id);
            person.FirstName.Should().Be(expectedPerson.FirstName);
            person.LastName.Should().Be(expectedPerson.LastName);
            person.Address.Should().Be(expectedPerson.Address);
            person.Gender.Should().Be(expectedPerson.Gender);
            person.Gender.Should().Be(expectedPerson.Gender);
            person.Should().BeEquivalentTo(expectedPerson);
        }

        [Fact]
        public void ToPerson_NullPersonDTOShouldReturnNull()
        {
            PersonDTO? dto = null;
            Person? person = dto.ToPerson();
            person.Should().BeNull();
        }

        [Fact]
        public void ToPersonDTOList_PersonListShouldToPersonDTOList()
        {
            IEnumerable<Person> persons = new List<Person>()
            {
                new Person()
                {
                    Id = 1,
                    FirstName = "Son",
                    LastName = "Goku",
                    Address = "Earth",
                    Gender = "Male",                   
                },
                new Person()
                {
                    Id = 2,
                    FirstName = "Rei",
                    LastName = "Vegeta",
                    Address = "Saiyan Planet",
                    Gender = "Male",
                }
            };

            IEnumerable<PersonDTO> expectedDto = new List<PersonDTO>()
            {
                new PersonDTO()
                {
                    Id = 1,
                    FirstName = "Son",
                    LastName = "Goku",
                    Address = "Earth",
                    Gender = "Male"
                },
                new PersonDTO()
                {
                    Id = 2,
                    FirstName = "Rei",
                    LastName = "Vegeta",
                    Address = "Saiyan Planet",
                    Gender = "Male"
                }
            };

            IEnumerable<PersonDTO>? personsDto = persons.ToPersonDTOList();

            personsDto.Should().NotBeNull();
            personsDto.Should().BeEquivalentTo(expectedDto);
        }

        [Fact]
        public void ToPersonDTOList_NullPersonListShouldReturnEmptyList()
        {
            IEnumerable<Person>? persons = null;
            IEnumerable<PersonDTO>? personsDto = persons.ToPersonDTOList();
            personsDto.Should().NotBeNull();
            personsDto.Should().BeEmpty();
        }
    }
}
