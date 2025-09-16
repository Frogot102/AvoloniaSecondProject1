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

            var selectedUser = App.DbContext.Users.FirstOrDefault(x => x.IdUser == UserVaribleData.selectedBacketInMainWindow.IdUser);
            var selectedItem = App.DbContext.Items.FirstOrDefault(z => z.IdItem == UserVaribleData.selectedBacketInMainWindow.IdItem);

            ComboUsersAll.SelectedItem = selectedUser;
            ComboItemsAll.SelectedItem = selectedItem;
            ItemCountText.Text = UserVaribleData.selectedBacketInMainWindow.Count.ToString();
        }
    }

    private void Button_Click_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (ComboItemsAll.SelectedItem == null || ComboUsersAll.SelectedItem == null || string.IsNullOrEmpty(ItemCountText.Text)) return;


        if (UserVaribleData.selectedBacketInMainWindow != null)
        {
            var idBasket = UserVaribleData.selectedBacketInMainWindow.IdBacket;
            var thisBasket = App.DbContext.Basckets.FirstOrDefault(x => x.IdBacket == idBasket);

            if (thisBasket == null) return;

            thisBasket.IdUser = ((User)ComboUsersAll.SelectedItem).IdUser;
            thisBasket.IdItem = ((Item)ComboItemsAll.SelectedItem).IdItem;

        }
        else
        {
            var newBasket = new Bascket
            {
                IdUser = ((User)ComboUsersAll.SelectedItem).IdUser,
                IdItem = ((Item)ComboItemsAll.SelectedItem).IdItem,
                Count = ItemCountText.Text
            };

            App.DbContext.Basckets.Add(newBasket);
        }

        App.DbContext.SaveChanges();
        this.Close();
    }
}