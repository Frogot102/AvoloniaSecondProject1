using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvoloniaSecondProject1.Data;

namespace AvoloniaSecondProject1.ViewModels
{
    public partial class LoginPageViewModel : ViewModelBase
    {
        public List<Login> Logins { get; set; }

        public LoginPageViewModel()
        {
            RefreshData();
        }
        public void RefreshData()
        {
            var LoginsFromDb = App.DbContext.Logins.ToList();
            Logins = LoginsFromDb;
            OnPropertyChanged(nameof(Logins));
        }

    }
}
