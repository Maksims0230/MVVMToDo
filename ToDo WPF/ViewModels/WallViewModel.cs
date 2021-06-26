using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using ToDo_WPF.Annotations;
using ToDo_WPF.Commands;
using ToDo_WPF.Models;

namespace ToDo_WPF.ViewModels
{
    [JsonSerializable(typeof(WallViewModel), TypeInfoPropertyName = "СТЕНА")]
    public class WallViewModel : INotifyPropertyChanged
    {
        [JsonIgnore] private string _id = DateTime.Now.ToString("yyyyMMddHHssfff");

        [JsonIgnore] private ObservableCollection<BoardViewModel> _wall;

        public WallViewModel()
        {
            Wall = new ObservableCollection<BoardViewModel>();
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
                    Id = Wall.Count.ToString();
                    BoardViewModel board = new() {Name = "Name"};
                    board.Categories.Add(new CategoryViewModel
                        {Id = board.Categories.Count.ToString(), Name = "Category"});
                    board.Tasks.Add(new TaskViewModel
                        {Id = board.Tasks.Count.ToString(), Name = "Task", Description = "Description"});
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
                    foreach (var board in Wall) MessageBox.Show($"{board.Id}\r\n{board.Name}\r\n");
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual async void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            await using (var file = new FileStream("Wall.json", FileMode.Create))
            {
                await JsonSerializer.SerializeAsync(file, this);
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}