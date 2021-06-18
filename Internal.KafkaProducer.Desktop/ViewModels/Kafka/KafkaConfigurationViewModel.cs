namespace Internal.KafkaProducer.Desktop.ViewModels.Kafka
{
    public class KafkaConfigurationViewModel : BaseViewModel
    {
        private string _kafkaLocation;

        public string KafkaLocation
        {
            get => _kafkaLocation;
            set
            {
                _kafkaLocation = value;
                OnPropertyChanged(nameof(KafkaLocation));
            }
        }

        private string _topicName;

        public string TopicName
        {
            get => _topicName;
            set
            {
                _topicName = value;
                OnPropertyChanged(nameof(TopicName));
            }
        }

        private string _kafkaServer;

        public string KafkaServer
        {
            get => _kafkaServer;
            set
            {
                _kafkaServer = value;
                OnPropertyChanged(nameof(KafkaServer));
            }
        }
    }
}