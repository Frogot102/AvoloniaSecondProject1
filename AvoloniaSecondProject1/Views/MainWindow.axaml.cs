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
            DataContext = new MainWindowViewModel();
        }

        private void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            var selectedUser = MainDataGridUsers.SelectedItem as User;

            if (selectedUser == null) return;

            UserVaribleData.selectedUserInMainWindow = selectedUser;

            var createAndChangeUserWindow = new CreateAndChangeUser();
            createAndChangeUserWindow.ShowDialog(this);



        }
    }
}