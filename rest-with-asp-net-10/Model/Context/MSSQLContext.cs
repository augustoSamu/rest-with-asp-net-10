using Microsoft.EntityFrameworkCore;

namespace rest_with_asp_net_10.Model.Context
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options) 
            : base(options) { }
        public DbSet<Person> Persons { get; set; }
    }
}
