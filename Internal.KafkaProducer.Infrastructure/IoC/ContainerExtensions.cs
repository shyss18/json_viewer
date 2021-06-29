using Internal.KafkaProducer.Core.Contracts.Services;
using Internal.KafkaProducer.Infrastructure.Services;
using Ninject;

namespace Internal.KafkaProducer.Infrastructure.IoC
{
    public static class ContainerExtensions
    {
        public static IKernel RegistryInfrastructure(this IKernel kernel)
        {
            kernel.Bind<IJsonLoader>().To<JsonLoader>().InTransientScope();
            kernel.Bind<IFileService>().To<FileService>().InTransientScope();
            kernel.Bind<IKafkaService>().To<KafkaService>().InTransientScope();

            return kernel;
        }
    }
}