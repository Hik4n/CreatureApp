using Avalonia.Controls;
using CreatureApp.ViewModels;

namespace CreatureApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new CreatureViewModel();
        }
    }
}