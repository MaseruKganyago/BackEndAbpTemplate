using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace TransportWiseBackEnd.EntityFrameworkCore
{
    public static class TransportWiseBackEndDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TransportWiseBackEndDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TransportWiseBackEndDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
