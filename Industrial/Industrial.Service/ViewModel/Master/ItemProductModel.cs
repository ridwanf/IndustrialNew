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
    public class ItemProductModel : ValidatableBindableBase
    {
        private int _id;
        private string _name;
        private decimal _price;
        private string _description;
        private int _quantity;
        private DateTime _createdDate;
        private bool _isActive;

        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id,value); }
        }

        [Required]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        
        public Decimal Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }

        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { SetProperty(ref _quantity, value); }
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
