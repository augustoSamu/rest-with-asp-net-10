using rest_with_asp_net_10.DTOs.V1;

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
