using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvoloniaSecondProject1.Data;
using AvoloniaSecondProject1.Models;
using AvoloniaSecondProject1.ViewModels;

namespace AvoloniaSecondProject1;

public partial class createAndChangeLoginData : Window
{
    public createAndChangeLoginData()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
        if (LoginVaribleData.selectedLoginInMainWindow == null) return;

        LoginText.Text = LoginVaribleData.selectedLoginInMainWindow.Login1;
        PasswordText.Text = LoginVaribleData.selectedLoginInMainWindow.Password;
        IdLoginUserText.Text = Convert.ToString(LoginVaribleData.selectedLoginInMainWindow.UserId);
        ComboUsers.SelectedItem = LoginVaribleData.selectedLoginInMainWindow.User;
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {

        var selectedUsers = ComboUsers.SelectedItem as User;

        if (selectedUsers == null) return;

        if (LoginVaribleData.selectedLoginInMainWindow != null)
        {
            var idLogin = LoginVaribleData.selectedLoginInMainWindow.IdLogin;
            var thisLogin = App.DbContext.Logins.FirstOrDefault(x => x.IdLogin == idLogin);

            if (thisLogin == null) return;

            thisLogin.Login1 = LoginText.Text;
            thisLogin.Password = PasswordText.Text;
            thisLogin.UserId = Convert.ToInt32(IdLoginUserText.Text);
        }
        else
        {
            var newLogin = new Login()
            {
                Login1 = LoginText.Text,
                Password = PasswordText.Text,
                UserId = Convert.ToInt32(IdLoginUserText.Text),
            };
            App.DbContext.Logins.Add(newLogin);
        }
        App.DbContext.SaveChanges();
        this.Close();
    }
}