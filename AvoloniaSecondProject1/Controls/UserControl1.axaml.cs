using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvoloniaSecondProject1.Data;
using AvoloniaSecondProject1.Models;
using AvoloniaSecondProject1.ViewModels;

namespace AvoloniaSecondProject1;

public partial class UserControl1 : UserControl
{
    public UserControl1()
    {
        InitializeComponent();
        MainDataGridUsers.ItemsSource = App.DbContext.Users.ToList();
    }
    private async void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        var selectedUser = MainDataGridUsers.SelectedItem as User;

        if (selectedUser == null) return;

        UserVaribleData.selectedUserInMainWindow = selectedUser;

        var parent = this.VisualRoot as Window;
        if (parent == null) return;
        var createAndChangeUserWindow = new CreateAndChangeUser();
        await createAndChangeUserWindow.ShowDialog(parent);

        MainDataGridUsers.ItemsSource = App.DbContext.Users.ToList();

    }

    private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        UserVaribleData.selectedUserInMainWindow = null;

        var createAndChangeUserWindow = new CreateAndChangeUser();
        var parent = this.VisualRoot as Window;

        await createAndChangeUserWindow.ShowDialog(parent);

        MainDataGridUsers.ItemsSource = App.DbContext.Users.ToList();
    }

    private async void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var loginsPageOpen = new LoginsPage();
        var parent = this.VisualRoot as Window;

        await loginsPageOpen.ShowDialog(parent);
        MainDataGridUsers.ItemsSource = App.DbContext.Users.ToList();
    }
}