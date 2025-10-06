using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvoloniaSecondProject1.Data;
using AvoloniaSecondProject1.Models;

namespace AvoloniaSecondProject1;

public partial class createAndChangeBasket : Window
{
    public createAndChangeBasket()
    {
        InitializeComponent();

        ComboUsersAll.ItemsSource = App.DbContext.Users.ToList();
        ComboItemsAll.ItemsSource = App.DbContext.Items.ToList();

        if (UserVaribleData.selectedBacketInMainWindow != null)
        {
            DataContext = UserVaribleData.selectedBacketInMainWindow;
        }
        else
            DataContext = new Bascket()
            {
                Count = "1"
            };
    }

    private void Button_Click_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (ComboItemsAll.SelectedItem == null || ComboUsersAll.SelectedItem == null || string.IsNullOrEmpty(ItemCountText.Text)) return;
        if (!ItemCountText.Text.All(char.IsDigit)) return;

        var basket = DataContext as Bascket;

        if (UserVaribleData.selectedBacketInMainWindow != null)
        {
            App.DbContext.Update(basket);
        }
        else
        { 
            App.DbContext.Basckets.Add(basket);
        }

        App.DbContext.SaveChanges();
        this.Close();
    }
}