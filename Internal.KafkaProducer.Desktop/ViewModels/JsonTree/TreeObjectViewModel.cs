using System.Collections.ObjectModel;

namespace Internal.KafkaProducer.Desktop.ViewModels.JsonTree
{
    public class TreeObjectViewModel : BaseViewModel
    {
        private ObservableCollection<TreeNodeViewModel> _children;

        public ObservableCollection<TreeNodeViewModel> Children
        {
            get => _children;
            set
            {
                _children = value;
                OnPropertyChanged(nameof(Children));
            }
        }
    }
}