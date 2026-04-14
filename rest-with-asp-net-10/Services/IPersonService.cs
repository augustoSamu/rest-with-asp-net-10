using rest_with_asp_net_10.Model;

namespace rest_with_asp_net_10.Services
{
    public interface IPersonService
    {
        Person FindById(int id);

        List<Person> FindAll();

        Person Create(Person person);

        Person Update(Person person);

        void Delete(int id);
    }
}
