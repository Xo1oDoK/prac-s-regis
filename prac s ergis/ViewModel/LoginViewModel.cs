using prac_s_ergis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using prac_s_ergis.Repositories;
using System.Net;
using System.Threading;
using System.Security.Principal;

namespace prac_s_ergis.ViewModel
{
   public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;


        private IUserRepository userRepository;

        public string Username
        { 
            get 
            { 
                return _username;           
            } 
            set 
            { 
                _username = value;
                OnPropertyChanged(nameof(Username));
            }  
        }
        public SecureString Password 
        {
            get 
            { 
                return _password; 
            }


            set 
            { 
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        
        }
        public string ErrorMessage 
        { 
            get 
            { 
                return _errorMessage; 
            }

            set 
            { 
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisible
        {
            get 
            { 
                return _isViewVisible; 
            }
            set 
            { 
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RecoverPasswordCommand { get; }



        public LoginViewModel()
        {
            userRepository=new UserRepository();

            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, canexecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("", ""));
        }

        private void ExecuteRecoverPassCommand(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        private bool canexecuteLoginCommand(object obj)
        {
            bool vailedData;
            if (string.IsNullOrWhiteSpace(Username)|| Username.Length <3 || Password == null || Password.Length < 3)
                vailedData = false;            
            else
                vailedData = true;

            return vailedData;
        }

        private void ExecuteLoginCommand(object obj)
        {
           var isValidUser = userRepository.AuntheticateUser(new NetworkCredential(Username, Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "* Неверные данные UserName или  Password";
            }
        }
    }
}
