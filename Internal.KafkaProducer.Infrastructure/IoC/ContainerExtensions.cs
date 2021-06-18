using Internal.KafkaProducer.Core.Contracts.Services;
using Internal.KafkaProducer.Infrastructure.Services;
using Ninject;

namespace Internal.KafkaProducer.Infrastructure.IoC
{
    public static class ContainerExtensions
    {
        public static IKernel RegistryInfrastructure(this IKernel kernel)
        {
            kernel.Bind<IJsonParserService>().To<JsonParserService>().InTransientScope();
            kernel.Bind<IFileService>().To<FileService>().InTransientScope();

            return kernel;
        }
    }
}