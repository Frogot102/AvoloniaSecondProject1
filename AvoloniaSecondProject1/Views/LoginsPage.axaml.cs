using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvoloniaSecondProject1.Data;
using AvoloniaSecondProject1.Models;
using AvoloniaSecondProject1.ViewModels;

namespace AvoloniaSecondProject1;

public partial class LoginsPage : Window
{
    public LoginsPage()
    {
        InitializeComponent();
        DataContext = new LoginPageViewModel();
    }

    private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        LoginVaribleData.selectedLoginInMainWindow = null;

        var createAmdChangeLogin = new createAndChangeLoginData();
        await createAmdChangeLogin.ShowDialog(this);

        var viewModel = DataContext as MainWindowViewModel;
        viewModel.RefreshData();
    }

    private async void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        var selectedLogin = LoginsPageGrid.SelectedItem as Login;

        if (selectedLogin == null) return;

        LoginVaribleData.selectedLoginInMainWindow = selectedLogin;

        var createAndChangeLogin = new createAndChangeLoginData();
        await createAndChangeLogin.ShowDialog(this);

        var viewModel = DataContext as LoginPageViewModel;
        viewModel.RefreshData();
    }
}