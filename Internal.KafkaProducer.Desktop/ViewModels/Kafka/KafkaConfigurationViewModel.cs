namespace Internal.KafkaProducer.Desktop.ViewModels.Kafka
{
    public class KafkaConfigurationViewModel : BaseViewModel
    {
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

        private string _kafkaServers;

        public string KafkaServers
        {
            get => _kafkaServers;
            set
            {
                _kafkaServers = value;
                OnPropertyChanged(nameof(KafkaServers));
            }
        }
    }
}