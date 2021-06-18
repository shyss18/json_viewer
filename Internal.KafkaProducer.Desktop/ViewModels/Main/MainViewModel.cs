using System.Windows.Input;
using Internal.KafkaProducer.Core.Contracts.Services;
using Internal.KafkaProducer.Desktop.Commands;
using Internal.KafkaProducer.Desktop.ViewModels.JsonTree;
using Internal.KafkaProducer.Desktop.ViewModels.Kafka;

namespace Internal.KafkaProducer.Desktop.ViewModels.Main
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IJsonParserService _jsonParserService;
        private readonly IFileService _fileService;

        private TreeObjectViewModel _treeObject;

        public TreeObjectViewModel TreeObject
        {
            get => _treeObject;
            set
            {
                _treeObject = value;
                OnPropertyChanged(nameof(TreeObject));
            }
        }

        private TreeNodeViewModel _selectedNodeViewModel;

        public TreeNodeViewModel SelectedNodeViewModel
        {
            get => _selectedNodeViewModel;
            set
            {
                _selectedNodeViewModel = value;
                OnPropertyChanged(nameof(SelectedNodeViewModel));
            }
        }

        private KafkaConfigurationViewModel _kafkaConfigurationViewModel;

        public KafkaConfigurationViewModel KafkaConfigurationViewModel
        {
            get => _kafkaConfigurationViewModel;
            set
            {
                _kafkaConfigurationViewModel = value;
                OnPropertyChanged(nameof(KafkaConfigurationViewModel));
            }
        }

        public MainViewModel(
            IJsonParserService jsonParserService,
            IFileService fileService)
        {
            _fileService = fileService;
            _jsonParserService = jsonParserService;
        }

        public ICommand ConfigureKafkaProducer => new RelayCommand(_ => { });

        public ICommand LoadTopicContract => new RelayCommand(async _ =>
        {
            string filePath = _fileService.PeekFile();
            if (string.IsNullOrEmpty(filePath))
            {
                //TODO: Throw exception
            }

            var treeObject = await _jsonParserService.ParseJsonAsync(filePath);
        });

        public ICommand PushMessage =>  new RelayCommand(_ => { });
    }
}