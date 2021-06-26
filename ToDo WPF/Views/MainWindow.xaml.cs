using System.Windows;
using System.Windows.Controls;
using ToDo_WPF.ViewModels;

namespace ToDo_WPF.Views
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void EmailTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}