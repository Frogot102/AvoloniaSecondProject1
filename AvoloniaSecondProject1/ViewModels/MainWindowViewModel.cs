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
       public List<Item> Items {  get; set; }
       public List<Bascket> Basckets { get; set; }

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
            var ItemsFromDb = App.DbContext.Items.ToList();
            Items = ItemsFromDb;
            var BasketsFromDb = App.DbContext.Basckets.ToList();
            Basckets = BasketsFromDb;

            OnPropertyChanged(nameof(Users));
            OnPropertyChanged(nameof(Logins));
            OnPropertyChanged(nameof(Roles));
            OnPropertyChanged(nameof(Items));
            OnPropertyChanged(nameof(Basckets));
        }

    }
}
