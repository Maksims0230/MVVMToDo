using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Windows;
using ToDo_WPF.Annotations;
using ToDo_WPF.Commands;

namespace ToDo_WPF.ViewModels
{
    internal class UserViewModel : INotifyPropertyChanged
    {
        [JsonIgnore] private string _email;

        [JsonIgnore] private string _password;

        public UserViewModel()
        {
            Email = "";
            Password = "";
        }

        [JsonInclude]
        [JsonPropertyName("ПОЧТА")]
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        [JsonInclude]
        [JsonPropertyName("ПАРОЛЬ")]
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public DelegateCommand ClickSeeEmail
        {
            get { return new(obj => { MessageBox.Show(Email); }); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}