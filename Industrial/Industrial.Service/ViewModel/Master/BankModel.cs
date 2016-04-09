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
    public class BankModel : ValidatableBindableBase
    {
        private string _name;
        private string _code;
        private int _id;
        private DateTime _createdDate;
        private bool _isActive;


        [Required]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        [Required]
        [MaxLength(3)]
        public string Code
        {
            get { return _code; }
            set { SetProperty(ref _code, value); }
        }

        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { SetProperty(ref _createdDate, value); }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value); }
        }
    }
}
