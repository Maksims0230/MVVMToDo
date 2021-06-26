using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Windows;
using ToDo_WPF.Annotations;
using ToDo_WPF.Commands;

namespace ToDo_WPF.ViewModels
{
    [JsonSerializable(typeof(WallViewModel), TypeInfoPropertyName = "СТЕНА")]
    public class WallViewModel : INotifyPropertyChanged
    {
        [JsonIgnore] private string _id;
        [JsonIgnore] private ObservableCollection<BoardViewModel> _wall;

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
        [JsonPropertyName("ДОСКИ")]
        public ObservableCollection<BoardViewModel> Wall
        {
            get => _wall;
            set
            {
                _wall = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public DelegateCommand AddBoard
        {
            get
            {
                return new(obj =>
                {
                    Id = "0";
                    BoardViewModel board = new() {Name = "Name"};
                    board.Categories.Add(new CategoryViewModel {Id = "0", Name = "Category"});
                    board.Tasks.Add(new TaskViewModel {Id = "0", Name = "Task", Description = "Description"});
                    Wall.Add(board);
                });
            }
        }
        
        [JsonIgnore]
        public DelegateCommand SeeBoards
        {
            get
            {
                return new(obj =>
                {
                    foreach (var board in Wall)
                    {
                        MessageBox.Show($"{board.Id}\r\n{board.Name}\r\n");
                    }
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public WallViewModel()
        {
            this.Wall = new ObservableCollection<BoardViewModel>();
        }
    }
}