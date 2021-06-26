using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using ToDo_WPF.Annotations;
using ToDo_WPF.Commands;

namespace ToDo_WPF.ViewModels
{
    [JsonSerializable(typeof(BoardViewModel), TypeInfoPropertyName = "ДОСКА")]
    public class BoardViewModel : INotifyPropertyChanged
    {
        [JsonIgnore] private readonly string _id;
        [JsonIgnore] private ObservableCollection<CategoryViewModel> _categories;

        [JsonIgnore] private string _name;

        [JsonIgnore] private ObservableCollection<TaskViewModel> _tasks;

        [JsonInclude]
        [JsonPropertyName("НОМЕР")]
        public string Id
        {
            get => _id;
            init
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

        [JsonInclude]
        [JsonPropertyName("КАТЕГОРИИ")]
        public ObservableCollection<CategoryViewModel> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }

        [JsonInclude]
        [JsonPropertyName("ЗАДАЧИ")]
        public ObservableCollection<TaskViewModel> Tasks
        {
            get => _tasks;
            set
            {
                _tasks = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public DelegateCommand AddTask
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    this.Tasks.Add(new TaskViewModel() { Id = "0", Name = "Task", Description = "Description" });
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BoardViewModel()
        {
            Categories = new ObservableCollection<CategoryViewModel>();
            Tasks = new ObservableCollection<TaskViewModel>();
        }
    }
}