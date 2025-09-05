using System.Collections.Generic;
using AvoloniaSecondProject1.Data;

namespace AvoloniaSecondProject1.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
       public List<User> Users { get; set; }

       public MainWindowViewModel() 
        {
            
        }
    }
}
