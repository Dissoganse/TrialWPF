using System.Collections.ObjectModel;
using System.Xml;

namespace TrialWPF
{
    public class ContactsViewModel : ViewModelBase
    {
        public ObservableCollection<Contact> Contacts { get; } = new ObservableCollection<Contact>();

        private XmlDocument main_doc = new XmlDocument();
        private XmlElement main_root;

        public ContactsViewModel()
        {
            if (IsDesignMode)
            {
                // Данные Времени Разрабоки
                // Чтобы при разработки Окна оно не было пустым
                main_doc.LoadXml
(@"<?xml version='1.0' encoding='utf-8' ?> 
<contacts>
    <last_name>Burov</last_name>
    <first_name>Michael</first_name>
    <middle_name>Vasilyevich</middle_name>
    <phone>+4184737463727</phone>
    <last_name>Chilin</last_name>
    <first_name>Andry</first_name>
    <middle_name>Sergeevich</middle_name>
    <phone>+385645373945</phone>
</contacts>");

            }
            else
            {
                // Данные Времени исполнения
                main_doc.Load("contacts.xml");
            }
            main_root = main_doc.DocumentElement;

            for (int i = 0; i < main_root.ChildNodes.Count; i += 4)
            {
                Contact contact = new Contact
                {
                    LastName = main_root.ChildNodes.Item(i).InnerText,
                    FirstName = main_root.ChildNodes.Item(i + 1).InnerText,
                    MiddleName = main_root.ChildNodes.Item(i + 2).InnerText,
                    Phone = main_root.ChildNodes.Item(i + 3).InnerText
                };
                Contacts.Add(contact);
            }
        }
    }
}
