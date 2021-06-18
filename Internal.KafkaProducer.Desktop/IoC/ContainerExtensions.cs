using Internal.KafkaProducer.Desktop.ViewModels.Main;
using Ninject;

namespace Internal.KafkaProducer.Desktop.IoC
{
    public static class ContainerExtensions
    {
        public static IKernel RegistryViewModels(this IKernel kernel)
        {
            kernel.Bind<MainViewModel>().ToSelf().InSingletonScope();
            kernel.Bind<MainWindow>().ToSelf();

            return kernel;
        }
    }
}