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

namespace TrialWPF
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Contact inputContact;
        private readonly CollectionViewSource contactsView;

        public MainWindow()
        {
            InitializeComponent();
            contactsView = (CollectionViewSource)Resources["contacts"];
            inputContact = (Contact)Resources["inputContact"];

        }

        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            contactsView.View.Refresh();
        }

        public bool ContactSearch(Contact contact, Contact template)
        {
            return template == null ||
                   (
                       (template.LastName == string.Empty || contact.LastName.ToUpper().Contains(template.LastName.ToUpper())) &&
                       (template.FirstName == string.Empty || contact.FirstName.ToUpper().Contains(template.FirstName.ToUpper())) &&
                       (template.MiddleName == string.Empty || contact.MiddleName.ToUpper().Contains(template.MiddleName.ToUpper())) &&
                       (template.Phone == string.Empty || contact.Phone.ToUpper().Contains(template.Phone.ToUpper()))
                   );
        }

        private void OnContactsFilter(object sender, FilterEventArgs e)
        {
            Contact contact = (Contact)e.Item;
            e.Accepted = ContactSearch(contact, inputContact);
        }
    }
}
