using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using FontAwesome.Sharp;
using prac_s_ergis.Model;
using prac_s_ergis.Repositories;

namespace prac_s_ergis.ViewModel
{
    public class MainWindowModel : ViewModelBase
    {
        private UserAccountModel _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;





        private IUserRepository userRepository;

        public UserAccountModel CurrentuserAccount
        {
            get
            {
                return _currentUserAccount;
            }
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentuserAccount));
            }
        }

        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public string Caption
        {
            get
            {
                return _caption;

            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get
            {
                return _icon;
            }
            set 
            { 
                _icon = value; 
                OnPropertyChanged(nameof(Icon));
            }
        }

        public ICommand ShowProductViewCommand { get; }


        public MainWindowModel()
        {
            userRepository = new UserRepository();
            CurrentuserAccount = new UserAccountModel();
            ShowProductViewCommand = new ViewModelCommand(ExecuteShowProductViewCommand);


            LoadCurrentUserData();
            
        }

        private void ExecuteShowProductViewCommand(object obj)
        {
            CurrentChildView = new ProductViewModel();
            Caption = "Товар";
            Icon = IconChar.CartShopping;
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentuserAccount.UserName = user.UserName;
                CurrentuserAccount.DispalyName = $"Welcome {user.UserName} ;)";
                CurrentuserAccount.ProfilePicture = null;
            }
            else
            {
                CurrentuserAccount.DispalyName = "Invalid user, not logged in";
            }
            

        }
    }
}
