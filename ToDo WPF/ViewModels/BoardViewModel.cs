using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Windows;
using GongSolutions.Wpf.DragDrop;
using ToDo_WPF.Annotations;
using ToDo_WPF.Commands;

namespace ToDo_WPF.ViewModels
{
    [JsonSerializable(typeof(BoardViewModel), TypeInfoPropertyName = "ДОСКА")]
    public class BoardViewModel : INotifyPropertyChanged, IDropTarget
    {
        [JsonIgnore] private ObservableCollection<CategoryViewModel> _categories;
        [JsonIgnore] private string _id;

        [JsonIgnore] private string _name;

        [JsonIgnore] private ObservableCollection<TaskViewModel> _tasks;

        public BoardViewModel()
        {
            Id = "";
            Name = "";
            Categories = new ObservableCollection<CategoryViewModel>();
            Tasks = new ObservableCollection<TaskViewModel>();
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
                return new(obj =>
                {
                    Tasks.Add(new TaskViewModel
                        {Id = Tasks.Count.ToString(), Name = "Task", Description = "Description"});
                });
            }
        }

        public void DragOver(IDropInfo dropInfo)
        {
            if (dropInfo.Data is TaskViewModel)
            {
                dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                dropInfo.Effects = DragDropEffects.Move;
            }
        }

        public void Drop(IDropInfo dropInfo)
        {
            if (dropInfo.Data is TaskViewModel task)
            {
                Tasks.Add(new TaskViewModel
                    {Id = Tasks.Count.ToString(), Name = task.Name, Description = task.Description});
                ((IList) dropInfo.DragInfo.SourceCollection).Remove(task);
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