using System.Windows.Input;
using Internal.KafkaProducer.Core.Contracts.Services;
using Internal.KafkaProducer.Desktop.Commands;
using Internal.KafkaProducer.Desktop.ViewModels.JsonTree;
using Internal.KafkaProducer.Desktop.ViewModels.Kafka;
using Internal.KafkaProducer.Domain;

namespace Internal.KafkaProducer.Desktop.ViewModels.Main
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IJsonLoader _jsonLoader;
        private readonly IFileService _fileService;
        private readonly IKafkaService _kafkaService;

        private JsonObjectViewModel _jsonObject;

        public JsonObjectViewModel JsonObject
        {
            get => _jsonObject;
            set
            {
                _jsonObject = value;
                OnPropertyChanged(nameof(JsonObject));
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
            IJsonLoader jsonLoader,
            IFileService fileService,
            IKafkaService kafkaService)
        {
            _fileService = fileService;
            _kafkaService = kafkaService;
            _jsonLoader = jsonLoader;

            SetupDefault();
        }

        private void SetupDefault()
        {
            JsonObject = new JsonObjectViewModel();
            KafkaConfigurationViewModel = new KafkaConfigurationViewModel
            {
                TopicName = "rslon.asset.fct.registrations",
                KafkaServers = "localhost:9092",
            };
        }

        public ICommand LoadTopicContract => new RelayCommand(async _ =>
        {
            string filePath = _fileService.PeekFilePath();
            if (string.IsNullOrEmpty(filePath))
            {
                //TODO: Throw exception
            }

            var treeObject = await _jsonLoader.LoadAsync(filePath);
            JsonObject = new JsonObjectViewModel
            {
                Json = treeObject.Json
            };
        });

        public ICommand PushMessage => new RelayCommand(async _ =>
        {
            await _kafkaService.ProduceAsync(JsonObject.Json.TrimEnd().TrimStart(), new KafkaConfiguration
            {
                KafkaServer = KafkaConfigurationViewModel.KafkaServers,
                TopicName = KafkaConfigurationViewModel.TopicName
            });
        });
    }
}