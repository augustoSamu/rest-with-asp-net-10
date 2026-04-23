using Microsoft.EntityFrameworkCore;
using rest_with_asp_net_10.Model;

namespace rest_with_asp_net_10.Context
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options)
            : base(options) { }
        
        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
