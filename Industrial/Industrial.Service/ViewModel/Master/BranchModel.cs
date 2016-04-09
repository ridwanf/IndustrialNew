using System;
using System.Collections.Generic;
using Core.Common.UI;
using Core.Common.UI.BaseClass;
using Industrial.Data.Domain;
using Industrial.Infrastructure.BaseClasses;

namespace Industrial.Service.ViewModel.Master
{
    public class BranchModel : ValidatableBindableBase
    {
        private int _id;
        private string _name;
        private DateTime _createdDate;
        private bool _isActive;
        private int? _parentBranchId;
        //private IEnumerable<BranchModel> _children;
        private string _parentBranchName;


        public string ParentBranchName
        {
            get { return _parentBranchName; }
            set { SetProperty(ref _parentBranchName,value); }
        }

        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
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

        public int? ParentBranchId
        {
            get { return _parentBranchId; }
            set { SetProperty(ref _parentBranchId, value); }
        }

    

        //public virtual IEnumerable<BranchModel> Children
        //{
        //    get { return _children; }
        //    set { SetProperty(ref _children, value); }
        //}
    }
}