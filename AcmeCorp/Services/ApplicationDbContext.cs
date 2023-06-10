namespace AcmeCorp.Services
{
    using AcmeCorp.Model;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        private readonly DbContextOptions<ApplicationDbContext> _options;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            _options = options;
        }
    }
}
