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

        // «аполн€ем данные пользовател€ если он выбран
        if (UserVaribleData.selectedUserInMainWindow != null)
        {
            FullNameText.Text = UserVaribleData.selectedUserInMainWindow.FullName;
            PhoneNumberText.Text = UserVaribleData.selectedUserInMainWindow.PhoneNumber;
            DescriptionText.Text = UserVaribleData.selectedUserInMainWindow.Description;
            ComboUsersAll.SelectedItem = UserVaribleData.selectedUserInMainWindow.Role;

            // ѕолучаем логин и пароль дл€ выбранного пользовател€
            var userLogin = App.DbContext.Logins.FirstOrDefault(x => x.UserId == UserVaribleData.selectedUserInMainWindow.IdUser);

            if (userLogin != null)
            {
                LoginText.Text = userLogin.Login1;
                PasswordText.Text = userLogin.Password;
            }
        }
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (UserVaribleData.selectedUserInMainWindow != null)
        {
            // –едактирование существующего пользовател€
            var idUser = UserVaribleData.selectedUserInMainWindow.IdUser;
            var thisUser = App.DbContext.Users.FirstOrDefault(x => x.IdUser == idUser);

            if (thisUser == null) return;

            thisUser.PhoneNumber = PhoneNumberText.Text;
            thisUser.Description = DescriptionText.Text;
            thisUser.FullName = FullNameText.Text;

            // ќбновл€ем логин и пароль
            var userLogin = App.DbContext.Logins.FirstOrDefault(x => x.UserId == idUser);
            if (userLogin != null)
            {
                userLogin.Login1 = LoginText.Text;
                userLogin.Password = PasswordText.Text;
            }
        }
        else
        {
            // —оздание нового пользовател€
            var newUser = new User()
            {
                FullName = FullNameText.Text,
                Description = DescriptionText.Text,
                PhoneNumber = PhoneNumberText.Text,
            };
            App.DbContext.Users.Add(newUser);

            // —охран€ем чтобы получить ID нового пользовател€
            App.DbContext.SaveChanges();

            var newLogin = new Login()
            {
                Login1 = LoginText.Text,
                Password = PasswordText.Text,
                UserId = newUser.IdUser // —в€зываем логин с пользователем
            };
            App.DbContext.Logins.Add(newLogin);
        }

        App.DbContext.SaveChanges();
        this.Close();
    }
}