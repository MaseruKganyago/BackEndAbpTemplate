using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TransportWiseBackEnd.Authorization;

namespace TransportWiseBackEnd
{
    [DependsOn(
        typeof(TransportWiseBackEndCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TransportWiseBackEndApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TransportWiseBackEndAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TransportWiseBackEndApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            //Configuration.Modules.AbpAutoMapper().Configurators.Add(
            //    // Scan the assembly for classes which inherit from AutoMapper.Profile
            //    cfg => cfg.AddMaps(thisAssembly)
            //);
        }
    }
}
