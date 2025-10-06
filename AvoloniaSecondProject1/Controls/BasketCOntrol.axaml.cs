using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvoloniaSecondProject1.Data;
using AvoloniaSecondProject1.Models;
using AvoloniaSecondProject1.ViewModels;

namespace AvoloniaSecondProject1;

public partial class BasketCOntrol : UserControl
{
    public BasketCOntrol()
    {
        InitializeComponent();
        MainDataGridUsers.ItemsSource = App.DbContext.Basckets.ToList();
    }

    private async void Button_Click_Add(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        UserVaribleData.selectedBacketInMainWindow = null;

        var createAndChangeBasket = new createAndChangeBasket();
        var parent = this.VisualRoot as Window;

        await createAndChangeBasket.ShowDialog(parent);

        MainDataGridUsers.ItemsSource = App.DbContext.Basckets.ToList();
    }

    private async void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        var selectedBasket = MainDataGridUsers.SelectedItem as Bascket;

        if (selectedBasket == null) return;

        UserVaribleData.selectedBacketInMainWindow = selectedBasket;

        var parent = this.VisualRoot as Window;
        if (parent == null) return;
        var createAndChangeBasket = new createAndChangeBasket();
        await createAndChangeBasket.ShowDialog(parent);

        MainDataGridUsers.ItemsSource = App.DbContext.Basckets.ToList();
    }
}