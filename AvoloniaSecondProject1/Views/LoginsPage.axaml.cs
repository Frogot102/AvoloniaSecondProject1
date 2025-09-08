using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvoloniaSecondProject1.Data;
using AvoloniaSecondProject1.ViewModels;

namespace AvoloniaSecondProject1;

public partial class LoginsPage : Window
{
    public LoginsPage()
    {
        InitializeComponent();
        DataContext = new LoginPageViewModel();
    }
}