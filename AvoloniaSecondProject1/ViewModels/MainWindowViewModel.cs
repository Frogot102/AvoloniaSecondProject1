using System.Collections.Generic;
using System.Linq;
using AvoloniaSecondProject1.Data;

namespace AvoloniaSecondProject1.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
       public List<User> Users { get; set; }

       public MainWindowViewModel() 
        {
            RefreshData();
        }

        public void RefreshData()
        {
            var UsersFromDb = App.DbContext.Users.ToList();
            Users = UsersFromDb;
            OnPropertyChanged(nameof(Users));
        }

    }
}
