using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace TrialWPF
{
    public class ContactsViewModel : ViewModelBase
    {
        public ObservableCollection<Contact> Contacts { get; } = new ObservableCollection<Contact>();

        private ContactsXml contactsXml;

        private readonly static XmlSerializer contactsSerializer = new XmlSerializer(typeof(ContactsXml));

        public ContactsViewModel()
        {
            if (IsDesignMode)
            {
                // Данные Времени Разрабоки
                // Чтобы при разработки Окна оно не было пустым
                contactsXml = new ContactsXml();
                contactsXml.Contacts = new List<Contact>()
                {
                    new Contact() {LastName="Burov", FirstName="Michael", MiddleName="Vasilyevich", Phone="+4184737463727"},
                    new Contact() {LastName="Chilin", FirstName="Andry", MiddleName="Sergeevich", Phone="+385645373945"}
                };
            }
            else
            {
                // Данные Времени исполнения
                LoadFromXml("contacts.xml");
            }

            foreach (var contact in contactsXml.Contacts)
            {
                Contacts.Add(contact);
            }
        }

        public void LoadFromXml(string fullName)
        {
            using (FileStream file = File.OpenRead(fullName))
                contactsXml = (ContactsXml)contactsSerializer.Deserialize(file);
        }
    }
}
