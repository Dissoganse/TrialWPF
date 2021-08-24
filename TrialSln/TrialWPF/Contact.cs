using System;

namespace TrialWPF
{
    public class Contact : OnPropertyChangedClass
    {
        private String _last_name;
        private String _first_name;
        private String _middle_name;
        private String _phone;

        public String last_name { get { return _last_name; } set { Set(ref _last_name, value); } }
        public String first_name { get { return _first_name; } set { Set(ref _first_name, value); } }
        public String middle_name { get { return _middle_name; } set { Set(ref _middle_name, value); } }
        public String phone { get { return _phone; } set { Set(ref _phone, value); } }

        protected override void OnPropertyChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnPropertyChanged(propertyName, oldValue, newValue);
        }
    }
}
