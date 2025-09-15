using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvoloniaSecondProject1.Data;
using AvoloniaSecondProject1.Models;
using AvoloniaSecondProject1.ViewModels;

namespace AvoloniaSecondProject1;

public partial class ItemControl : UserControl
{
    public ItemControl()
    {
        InitializeComponent();
    }

    private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        UserVaribleData.selectedItemInMainWindow = null;

        var createAndChangeItem = new createAndChangeItem();
        var parent = this.VisualRoot as Window;

        await createAndChangeItem.ShowDialog(parent);

        var viewModel = DataContext as MainWindowViewModel;
        viewModel.RefreshData();
    }

    private async void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        var selectedItem = MainDataGridUsers.SelectedItem as Item;

        if (selectedItem == null) return;

        UserVaribleData.selectedItemInMainWindow = selectedItem;

        var parent = this.VisualRoot as Window;
        if (parent == null) return;
        var createAndChangeItem = new createAndChangeItem();
        await createAndChangeItem.ShowDialog(parent);

        var viewModel = DataContext as MainWindowViewModel;
        viewModel.RefreshData();
    }
}