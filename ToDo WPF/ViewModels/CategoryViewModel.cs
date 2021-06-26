using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using ToDo_WPF.Annotations;

namespace ToDo_WPF.ViewModels
{
    [JsonSerializable(typeof(CategoryViewModel), TypeInfoPropertyName = "КАТЕГОРИЯ")]
    public class CategoryViewModel : INotifyPropertyChanged
    {
        [JsonIgnore] private string _id;

        [JsonIgnore] private string _name;

        public CategoryViewModel()
        {
            Id = "";
            Name = "";
        }

        [JsonInclude]
        [JsonPropertyName("НОМЕР")]
        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        [JsonInclude]
        [JsonPropertyName("НАЗВАНИЕ")]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}