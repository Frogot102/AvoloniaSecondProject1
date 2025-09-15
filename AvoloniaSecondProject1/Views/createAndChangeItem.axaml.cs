using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvoloniaSecondProject1.Data;
using AvoloniaSecondProject1.Models;
using AvoloniaSecondProject1.ViewModels;

namespace AvoloniaSecondProject1;

public partial class createAndChangeItem : Window
{
    public createAndChangeItem()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();

        if (UserVaribleData.selectedItemInMainWindow != null)
        {
            ItemNameText.Text = UserVaribleData.selectedItemInMainWindow.ItemName;
            ItemDescText.Text = UserVaribleData.selectedItemInMainWindow.Description;
            ItemCostText.Text = UserVaribleData.selectedItemInMainWindow.Cost;
         }
    }

    private void Button_Click_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(ItemNameText.Text) || string.IsNullOrEmpty(ItemDescText.Text) || string.IsNullOrEmpty(ItemCostText.Text)) return;

        if (UserVaribleData.selectedItemInMainWindow != null)
        {
            var idItem = UserVaribleData.selectedItemInMainWindow.IdItem;
            var thisItem = App.DbContext.Items.FirstOrDefault(x => x.IdItem == idItem);

            if (thisItem == null) return;

            thisItem.ItemName = ItemNameText.Text;
            thisItem.Description = ItemDescText.Text;
            thisItem.Cost = ItemCostText.Text;

            //if (thisUser.Role != null && thisUser.FullName != null && thisUser.Description != null) return;

        }
        else
        {
            var newItem = new Item()
            {
                ItemName = ItemNameText.Text,
                Description = ItemDescText.Text,
                Cost = ItemCostText.Text,
            };

            App.DbContext.Items.Add(newItem);

            App.DbContext.SaveChanges();

        }

        App.DbContext.SaveChanges();
        this.Close();
    }
}
