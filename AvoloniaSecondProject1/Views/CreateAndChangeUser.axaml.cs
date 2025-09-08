using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvoloniaSecondProject1.Models;

namespace AvoloniaSecondProject1;

public partial class CreateAndChangeUser : Window
{
    public CreateAndChangeUser()
    {
        InitializeComponent();

        if (UserVaribleData.selectedUserInMainWindow == null) return;

        FullNameText.Text = UserVaribleData.selectedUserInMainWindow.FullName;
        PhoneNumberText.Text = UserVaribleData.selectedUserInMainWindow.PhoneNumber;
        DescriptionText.Text = UserVaribleData.selectedUserInMainWindow.Description;
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var idUser = UserVaribleData.selectedUserInMainWindow.IdUser;
        var thisUser = App.DbContext.Users.FirstOrDefault(x => x.IdUser == idUser);

        if (thisUser == null) return;

        thisUser.FullName = FullNameText.Text;
        thisUser.PhoneNumber = PhoneNumberText.Text;
        thisUser.Description = DescriptionText.Text;

        App.DbContext.SaveChanges();
        this.Close();
        
    }
}