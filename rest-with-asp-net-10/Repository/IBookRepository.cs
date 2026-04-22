using rest_with_asp_net_10.Model;

namespace rest_with_asp_net_10.Repository
{
    public interface IBookRepository
    {
        Book FindById(int id);

        List<Book> FindAll();

        Book Create(Book book);

        Book Update(Book book);

        void Delete(int id);
    }
}
