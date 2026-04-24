using rest_with_asp_net_10.DTOs;

namespace rest_with_asp_net_10.Service
{
    public interface IPersonService
    {
        IEnumerable<PersonDTO> GetAll();

        PersonDTO GetById(int id);

        PersonDTO Create(PersonDTO personDTO);

        PersonDTO Update(PersonDTO personDTO);

        void Delete(int id);
    }
}
