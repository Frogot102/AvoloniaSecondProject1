using System.Threading.Tasks;
using Avalonia.Controls;
using AvoloniaSecondProject1.Data;
using AvoloniaSecondProject1.Models;
using AvoloniaSecondProject1.ViewModels;

namespace AvoloniaSecondProject1.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainControl.Content = new UserControl1();
        }
       
        private void Button_Click_Users(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainControl.Content = new UserControl1();
        }

        private void Button_Click_Items(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainControl.Content = new ItemControl();
        }

        private void Button_Click_Basket(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainControl.Content = new BasketCOntrol();
        }
    }
}