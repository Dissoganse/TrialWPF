using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Xml;

namespace TrialWPF
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private XmlDocument main_doc = new XmlDocument();
        private XmlElement main_root;
        private readonly Contact inputContact;
        public ObservableCollection<Contact> cont_col { get; set; }

        public MainWindow()
        {
            cont_col = new ObservableCollection<Contact>();

            InitializeComponent();
            inputContact = (Contact)Resources["inputContact"];

            main_doc.Load("contacts.xml");
            main_root = main_doc.DocumentElement;

        }

        private void search_button_Click(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < main_root.ChildNodes.Count; i += 4)
            {
                Contact contact = new Contact
                {
                    LastName = main_root.ChildNodes.Item(i).InnerText,
                    FirstName = main_root.ChildNodes.Item(i + 1).InnerText,
                    MiddleName = main_root.ChildNodes.Item(i + 2).InnerText,
                    Phone = main_root.ChildNodes.Item(i + 3).InnerText
                };
                if (ContactSearch(contact, inputContact))
                    cont_col.Add(contact);
            }

        }

        public bool ContactSearch(Contact contact, Contact template)
        {
            return (template.LastName == string.Empty || contact.LastName.ToUpper().Contains(template.LastName.ToUpper())) &&
                   (template.FirstName == string.Empty || contact.FirstName.ToUpper().Contains(template.FirstName.ToUpper())) &&
                   (template.MiddleName == string.Empty || contact.MiddleName.ToUpper().Contains(template.MiddleName.ToUpper())) &&
                   (template.Phone == string.Empty || contact.Phone.ToUpper().Contains(template.Phone.ToUpper()));
        }

    }
}
