using System.ComponentModel.DataAnnotations;
using Core.Common.UI;
using Core.Common.UI.BaseClass;
using Industrial.Infrastructure.BaseClasses;

namespace Industrial.Service.ViewModel.Master
{
    public class LoginModel:ValidatableBindableBase
    {
        private string _userName;
        private string _password;

        [Required]
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        [Required]
        [MinLength(6)]
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
    }
}
