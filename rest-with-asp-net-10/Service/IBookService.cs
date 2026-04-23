using rest_with_asp_net_10.Domain;

namespace rest_with_asp_net_10.Service
{
    public interface IBookService
    {
        List<Book> GetAll();
        
        Book GetById(int id);
        
        Book Create(Book book);
        
        Book Update(Book book);
        
        void Delete(int it);
    }
}
