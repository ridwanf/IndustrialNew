using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Core.Common.UI.BaseClass
{
    public class BindableBase : INotifyPropertyChanged
    {
        private bool _isBusy;

        public virtual string ViewTitle
        {
            get { return String.Empty; }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        /// <summary>
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        ///     call from set block from each property
        ///     and encapsulate property if value actully changed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="member"></param>
        /// <param name="val"></param>
        /// <param name="propertyName"></param>
        protected virtual void SetProperty<T>(ref T member, T val,
            [CallerMemberName] string propertyName = null)
        {
            if (Equals(member, val))
                return;

            member = val;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}