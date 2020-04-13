using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TransportWiseBackEnd.Authorization.Roles;
using TransportWiseBackEnd.Authorization.Users;
using TransportWiseBackEnd.MultiTenancy;
using TransportWiseBackEnd.Domain;

namespace TransportWiseBackEnd.EntityFrameworkCore
{
    public class TransportWiseBackEndDbContext : AbpZeroDbContext<Tenant, Role, User, TransportWiseBackEndDbContext>
    {
		/* Define a DbSet for each entity of the application */
		public DbSet<Article> Articles { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Filestorage> FileStorage { get; set; }
		public DbSet<Fuelwise> FuelWise { get; set; }

		public TransportWiseBackEndDbContext(DbContextOptions<TransportWiseBackEndDbContext> options)
            : base(options)
        {
        }
    }
}
