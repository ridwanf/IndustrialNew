using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.UI;
using Core.Common.UI.BaseClass;
using Industrial.Infrastructure.BaseClasses;

namespace Industrial.Service.ViewModel.Master
{
    public class SupplierModel : ValidatableBindableBase
    {
        private int _id;
        private bool _isActive;
        private DateTime _createdDate;
        private string _name;
        private DateTime _registerDate;
        private DateTime _contractDate;
        private string _picName;
        private string _address;
        private string _phoneNumber;
        private string _phoneNumber2;
        private string _faxNumber;
        private string _faxNumber2;
        private string _email;
        private string _email2;

        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value); }
        }

        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { SetProperty(ref _createdDate, value); }
        }

       [Required]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

       [Required]
        public DateTime RegisterDate
        {
            get { return _registerDate; }
            set { SetProperty(ref  _registerDate, value); }
        }

        [Required]
        public DateTime ContractDate
        {
            get { return _contractDate; }
            set { SetProperty(ref _contractDate, value); }
        }

        [Required]
        public string PicName
        {
            get { return _picName; }
            set { SetProperty(ref _picName, value); }
        }

        [Required]
        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }

        [Phone]
       [Required]
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetProperty(ref _phoneNumber, value); }
        }

        [Phone]
        public string PhoneNumber2
        {
            get { return _phoneNumber2; }
            set { SetProperty(ref _phoneNumber2, value); }
        }

        [Phone]
        public string FaxNumber
        {
            get { return _faxNumber; }
            set { SetProperty(ref _faxNumber, value); }
        }

        [Phone]
        public string FaxNumber2
        {
            get { return _faxNumber2; }
            set { SetProperty(ref _faxNumber2, value); }
        }

        [EmailAddress]
        [Required]
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        [EmailAddress]
        public string Email2
        {
            get { return _email2; }
            set { SetProperty(ref _email2, value); }
        }
    }
}
