using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TransportWiseBackEnd.Authorization.Roles;
using TransportWiseBackEnd.Authorization.Users;
using TransportWiseBackEnd.MultiTenancy;
using TransportWiseBackEnd.Models;

namespace TransportWiseBackEnd.EntityFrameworkCore
{
    public class TransportWiseBackEndDbContext : AbpZeroDbContext<Tenant, Role, User, TransportWiseBackEndDbContext>
    {
		/* Define a DbSet for each entity of the application */
		public DbSet<ArticleModel> Articles { get; set; }
		public DbSet<AuthorModel> Authors { get; set; }
		public DbSet<FileStorageModel> FileStorage { get; set; }
		public DbSet<FuelWiseModel> FuelWise { get; set; }

		public TransportWiseBackEndDbContext(DbContextOptions<TransportWiseBackEndDbContext> options)
            : base(options)
        {
        }
    }
}
