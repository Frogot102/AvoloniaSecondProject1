using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvoloniaSecondProject1.Data;
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
        //var idUser = UserVaribleData.selectedUserInMainWindow.IdUser;
        //var thisUser = App.DbContext.Users.FirstOrDefault(x => x.IdUser == idUser);

        //if (thisUser == null) return;

        //thisUser.FullName = FullNameText.Text;
        //thisUser.PhoneNumber = PhoneNumberText.Text;
        //thisUser.Description = DescriptionText.Text;

        //App.DbContext.SaveChanges();
        //this.Close();

        if (UserVaribleData.selectedUserInMainWindow != null)
        {
            var idUser = UserVaribleData.selectedUserInMainWindow.IdUser;
            var thisUser = App.DbContext.Users.FirstOrDefault(x => x.IdUser == idUser);

            if (thisUser == null) return;

            thisUser.PhoneNumber = PhoneNumberText.Text;
            thisUser.Description = DescriptionText.Text;
            thisUser.FullName = FullNameText.Text;
        }
        else
        {
            var newUser = new User()
            {
                FullName = FullNameText.Text,
                Description = DescriptionText.Text,
                PhoneNumber = PhoneNumberText.Text,
            };
            App.DbContext.Users.Add(newUser);
        }
        App.DbContext.SaveChanges();
        this.Close();
    }
}