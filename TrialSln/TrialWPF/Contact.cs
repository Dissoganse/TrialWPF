using System.Linq;

namespace TrialWPF
{
    public class Contact : OnPropertyChangedClass
    {
        private string _lastName;
        private string _firstName;
        private string _middleName;
        private string _phone;

        public string LastName { get { return _lastName; } set { Set(ref _lastName, value?.Trim() ?? string.Empty); } }
        public string FirstName { get { return _firstName; } set { Set(ref _firstName, value?.Trim() ?? string.Empty); } }
        public string MiddleName { get { return _middleName; } set { Set(ref _middleName, value?.Trim() ?? string.Empty); } }
        public string Phone { get { return _phone; } set { Set(ref _phone, value?.Trim() ?? string.Empty); } }

        public Contact()
        {
            LastName = string.Empty;
            FirstName = string.Empty;
            MiddleName = string.Empty;
            Phone = string.Empty;
        }
    }
}
