using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TransportWiseBackEnd.Configuration;
using TransportWiseBackEnd.EntityFrameworkCore;
using TransportWiseBackEnd.Migrator.DependencyInjection;

namespace TransportWiseBackEnd.Migrator
{
    [DependsOn(typeof(TransportWiseBackEndEntityFrameworkModule))]
    public class TransportWiseBackEndMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public TransportWiseBackEndMigratorModule(TransportWiseBackEndEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(TransportWiseBackEndMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                TransportWiseBackEndConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TransportWiseBackEndMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
