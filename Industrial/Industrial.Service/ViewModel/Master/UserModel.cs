using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Common.UI.BaseClass;
using Industrial.Infrastructure.BaseClasses;

namespace Industrial.Service.ViewModel.Master
{
    public class UserModel : ValidatableBindableBase
    {
        private Guid _id;
        private DateTime _createdDate;
        private bool _isActive;
        private string _passwordHash;
        private string _userName;
        private IEnumerable<RoleModel> _roles;

        public Guid Id
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

        public string PasswordHash
        {
            get { return _passwordHash; }
            set { SetProperty(ref _passwordHash, value); }
        }


        [Required]
        [StringLength(256)]
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        public IEnumerable<RoleModel> Roles
        {
            get { return _roles; }
            set { SetProperty(ref _roles, value);}
        }
    }
}
