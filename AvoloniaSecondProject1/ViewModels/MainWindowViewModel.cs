using System.Collections.Generic;
using System.Linq;
using AvoloniaSecondProject1.Data;

namespace AvoloniaSecondProject1.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
       public List<User> Users { get; set; }
       public List<Login> Logins { get; set; }
       public List<Role> Roles { get; set; }

        public MainWindowViewModel() 
        {
            RefreshData();
        }

        public void RefreshData()
        {
            var UsersFromDb = App.DbContext.Users.ToList();
            Users = UsersFromDb;
            var LoginsFromDb = App.DbContext.Logins.ToList();
            Logins = LoginsFromDb;
            var RolesFromDb = App.DbContext.Roles.ToList();
            Roles = RolesFromDb;
            OnPropertyChanged(nameof(Users));
            OnPropertyChanged(nameof(Logins));
            OnPropertyChanged(nameof(Roles));
        }

    }
}
