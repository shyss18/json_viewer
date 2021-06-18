using System.Windows;
using Internal.KafkaProducer.Desktop.IoC;
using Internal.KafkaProducer.Infrastructure.IoC;
using Ninject;

namespace Internal.KafkaProducer.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private IKernel _ninjectKernel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _ninjectKernel = new StandardKernel();
            
            _ninjectKernel
                .RegistryViewModels()
                .RegistryInfrastructure();

            MainWindow mainWindow = _ninjectKernel.Get<MainWindow>();
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            _ninjectKernel.Dispose();
        }
    }
}