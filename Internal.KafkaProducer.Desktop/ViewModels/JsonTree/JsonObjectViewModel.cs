namespace Internal.KafkaProducer.Desktop.ViewModels.JsonTree
{
    public class JsonObjectViewModel : BaseViewModel
    {
        private string _json;

        public string Json
        {
            get => _json;
            set
            {
                _json = value;
                OnPropertyChanged(nameof(Json));
            }
        }
    }
}