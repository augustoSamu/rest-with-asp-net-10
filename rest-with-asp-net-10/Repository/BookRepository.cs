using Microsoft.Data.SqlClient;
using rest_with_asp_net_10.Model;
using rest_with_asp_net_10.Model.Context;

namespace rest_with_asp_net_10.Repository
{
    public class BookRepository : IBookRepository
    {
        private MSSQLContext _context;

        public BookRepository(MSSQLContext context)
        {
            _context = context;
        }

        public List<Book> FindAll()
        {
             return _context.Books.ToList();
        }

        public Book FindById(int id)
        {
            return _context.Books.Find(id);
        }

        public Book Create(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();

            return book;
        }

        public Book Update(Book book)
        {
            var existingBook = _context.Books.Find(book.Id);

            if (existingBook is null)
                return null;

            _context.Entry(existingBook).CurrentValues.SetValues(book);
            _context.SaveChanges();

            return book;
        }

        public void Delete(int id)
        {
            var book = _context.Books.Find(id);

            if (book is null)
                return;

            _context.Remove(book);
            _context.SaveChanges();
        }
    }
}
