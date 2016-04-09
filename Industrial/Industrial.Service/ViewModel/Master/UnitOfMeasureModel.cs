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
    public class UnitOfMeasureModel : ValidatableBindableBase
    {
        private string _name;
        private int _id;
        private DateTime _createdDate;
        private bool _isActive;
        private string _displayName;

        [Required]
        public string DisplayName
        {
            get { return _displayName; }
            set { SetProperty(ref _displayName,value);}
        }

        [Required]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
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
