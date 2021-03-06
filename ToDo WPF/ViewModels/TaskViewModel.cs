using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using ToDo_WPF.Annotations;

namespace ToDo_WPF.ViewModels
{
    [JsonSerializable(typeof(TaskViewModel), TypeInfoPropertyName = "ЗАДАЧА")]
    public class TaskViewModel : INotifyPropertyChanged
    {
        [NotNull] [JsonIgnore] private string _id;

        [JsonIgnore] private string _name;

        [JsonIgnore] private string _description;
        
        public TaskViewModel()
        {
            Id = "";
            Name = "";
            Description = "";
        }

        [JsonInclude]
        [JsonPropertyName("ID")]
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
        [JsonPropertyName("ИМЯ")]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        [JsonInclude]
        [JsonPropertyName("ОПИСАНИЕ")]
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
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