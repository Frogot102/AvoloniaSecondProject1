using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvoloniaSecondProject1.Data;
using AvoloniaSecondProject1.Models;
using AvoloniaSecondProject1.ViewModels;

namespace AvoloniaSecondProject1;

public partial class CreateAndChangeUser : Window
{
    public CreateAndChangeUser()
    {
        InitializeComponent();

        DataContext = new MainWindowViewModel();

        if (UserVaribleData.selectedUserInMainWindow == null) return;

        FullNameText.Text = UserVaribleData.selectedUserInMainWindow.FullName;
        PhoneNumberText.Text = UserVaribleData.selectedUserInMainWindow.PhoneNumber;
        DescriptionText.Text = UserVaribleData.selectedUserInMainWindow.Description;

        if (LoginVaribleData.selectedLoginInMainWindow == null) return;

        LoginText.Text = LoginVaribleData.selectedLoginInMainWindow.Login1;
        PasswordText.Text = LoginVaribleData.selectedLoginInMainWindow.Password;
        LoginText.Text = Convert.ToString(LoginVaribleData.selectedLoginInMainWindow.UserId);
        ComboUsersAll.SelectedItem = UserVaribleData.selectedUserInMainWindow.Role.RoleName;
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        

        if (UserVaribleData.selectedUserInMainWindow != null)
        {
            var idUser = UserVaribleData.selectedUserInMainWindow.IdUser;
            var thisUser = App.DbContext.Users.FirstOrDefault(x => x.IdUser == idUser);

            if (thisUser == null) return;

            thisUser.PhoneNumber = PhoneNumberText.Text;
            thisUser.Description = DescriptionText.Text;
            thisUser.FullName = FullNameText.Text;

            var selectedUsers = ComboUsersAll.SelectedItem as Role;

            if (selectedUsers == null) return;

            if (LoginVaribleData.selectedLoginInMainWindow != null) return;

            var idLogin = LoginVaribleData.selectedLoginInMainWindow.IdLogin;
            var thisLogin = App.DbContext.Logins.FirstOrDefault(x => x.IdLogin == idLogin);

            if (thisLogin == null) return;

            thisLogin.Login1 = LoginText.Text;
            thisLogin.Password = PasswordText.Text;
            thisLogin.UserId = Convert.ToInt32(LoginText.Text);
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
            var newLogin = new Login()
            {
                Login1 = LoginText.Text,
                Password = PasswordText.Text,
            };
            App.DbContext.Logins.Add(newLogin);
        }     
        App.DbContext.SaveChanges();
        this.Close();
    }
}