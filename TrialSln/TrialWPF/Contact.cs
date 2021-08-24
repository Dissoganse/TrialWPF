using System;

namespace TrialWPF
{
    public class Contact : OnPropertyChangedClass
    {
        private string _lastName;
        private string _firstName;
        private string _middleName;
        private string _phone;

        public string LastName { get { return _lastName; } set { Set(ref _lastName, value); } }
        public string FirstName { get { return _firstName; } set { Set(ref _firstName, value); } }
        public string MiddleName { get { return _middleName; } set { Set(ref _middleName, value); } }
        public string Phone { get { return _phone; } set { Set(ref _phone, value); } }

        protected override void OnPropertyChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnPropertyChanged(propertyName, oldValue, newValue);
        }
    }
}
