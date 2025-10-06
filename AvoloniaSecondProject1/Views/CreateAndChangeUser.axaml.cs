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
    private User _currentUser;
    private Login _currentLogin;
    private bool _isEditMode;

    public CreateAndChangeUser()
    {
        InitializeComponent();

        var formData = new
        {
            Roles = App.DbContext.Roles.ToList()
        };


        this.DataContext = formData;

        if (UserVaribleData.selectedUserInMainWindow != null)
        {
 
            _isEditMode = true;
            _currentUser = UserVaribleData.selectedUserInMainWindow;

 
            FullNameText.Text = _currentUser.FullName;
            PhoneNumberText.Text = _currentUser.PhoneNumber;
            DescriptionText.Text = _currentUser.Description;


            ComboUsersAll.SelectedItem = _currentUser.Role;


            _currentLogin = App.DbContext.Logins.FirstOrDefault(x => x.UserId == _currentUser.IdUser);
            if (_currentLogin != null)
            {
                LoginText.Text = _currentLogin.Login1;
                PasswordText.Text = _currentLogin.Password;
            }
        }
        else
        {

            _isEditMode = false;
            _currentUser = new User();
            _currentLogin = new Login();

            ComboUsersAll.SelectedIndex = 0;
        }
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {

        if (string.IsNullOrEmpty(FullNameText.Text) ||
            string.IsNullOrEmpty(DescriptionText.Text) ||
            string.IsNullOrEmpty(PhoneNumberText.Text) ||
            ComboUsersAll.SelectedItem == null ||
            string.IsNullOrEmpty(LoginText.Text) ||
            string.IsNullOrEmpty(PasswordText.Text))
        {
            return;
        }

        try
        {
            if (_isEditMode)
            {
 
                var existingUser = App.DbContext.Users.FirstOrDefault(x => x.IdUser == _currentUser.IdUser);
                if (existingUser == null) return;


                existingUser.FullName = FullNameText.Text;
                existingUser.PhoneNumber = PhoneNumberText.Text;
                existingUser.Description = DescriptionText.Text;
                existingUser.Role = ComboUsersAll.SelectedItem as Role;

                var userLogin = App.DbContext.Logins.FirstOrDefault(x => x.UserId == _currentUser.IdUser);
                if (userLogin != null)
                {
                    userLogin.Login1 = LoginText.Text;
                    userLogin.Password = PasswordText.Text;
                }
            }
            else
            {

                var newUser = new User()
                {
                    FullName = FullNameText.Text,
                    PhoneNumber = PhoneNumberText.Text,
                    Description = DescriptionText.Text,
                    Role = ComboUsersAll.SelectedItem as Role
                };

                App.DbContext.Users.Add(newUser);
                App.DbContext.SaveChanges();

                var newLogin = new Login()
                {
                    Login1 = LoginText.Text,
                    Password = PasswordText.Text,
                    UserId = newUser.IdUser
                };

                App.DbContext.Logins.Add(newLogin);
            }

            App.DbContext.SaveChanges();
            this.Close();
        }
        catch (Exception ex)
        {
            // Обработка ошибок
            Console.WriteLine($"Ошибка при сохранении: {ex.Message}");
        }
    }
}