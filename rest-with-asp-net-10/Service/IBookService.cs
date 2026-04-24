using rest_with_asp_net_10.DTOs;

namespace rest_with_asp_net_10.Service
{
    public interface IBookService
    {
        IEnumerable<BookDTO> GetAll();
        
        BookDTO GetById(int id);
        
        BookDTO Create(BookDTO book);
        
        BookDTO Update(BookDTO book);
        
        void Delete(int it);
    }
}
