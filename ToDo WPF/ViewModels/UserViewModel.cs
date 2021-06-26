using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToDo_WPF.Annotations;
using ToDo_WPF.Commands;

namespace ToDo_WPF.ViewModels
{
    class UserViewModel: INotifyPropertyChanged
    {

        private string _email;

        private string _password;

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DelegateCommand ClickSeeEmail
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    MessageBox.Show(Email);
                });
            }
        }
    }
}
