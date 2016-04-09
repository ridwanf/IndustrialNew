using System;
using Core.Common.UI;
using Core.Common.UI.BaseClass;
using Industrial.Infrastructure.BaseClasses;

namespace Industrial.Service.ViewModel.Master
{
    public class RoleModel : ValidatableBindableBase
    {
        private Guid _id;
        private bool _isActive;
        private DateTime _createdDate;
        private string _name;

        public Guid Id
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

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
    }
}