using Avalonia.Controls;
using AvoloniaSecondProject1.ViewModels;

namespace AvoloniaSecondProject1.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}