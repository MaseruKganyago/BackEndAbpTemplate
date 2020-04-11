using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TransportWiseBackEnd.Configuration;
using TransportWiseBackEnd.Web;

namespace TransportWiseBackEnd.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class TransportWiseBackEndDbContextFactory : IDesignTimeDbContextFactory<TransportWiseBackEndDbContext>
    {
        public TransportWiseBackEndDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TransportWiseBackEndDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            TransportWiseBackEndDbContextConfigurer.Configure(builder, configuration.GetConnectionString(TransportWiseBackEndConsts.ConnectionStringName));

            return new TransportWiseBackEndDbContext(builder.Options);
        }
    }
}
