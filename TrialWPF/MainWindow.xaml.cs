﻿using System;
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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml;

namespace TrialWPF
{
    public abstract class OnPropertyChangedClass : INotifyPropertyChanged
    {
        /// <summary>Событие для извещения об изменения свойства</summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>Метод для вызова события извещения об изменении свойства</summary>
        /// <param name="propertyName">Изменившееся свойство. 
        /// По умолчанию используется имя вызвавшего метода</param>
        public void RaisePropertyChanged([CallerMemberName]String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void Set<T>(ref T propertyFiled, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!object.Equals(propertyFiled, newValue))
            {
                T oldValue = propertyFiled;
                propertyFiled = newValue;
                RaisePropertyChanged(propertyName);

                OnPropertyChanged(propertyName, oldValue, newValue);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName, object oldValue, object newValue) { }
    }

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

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private XmlDocument main_doc = new XmlDocument();
        private XmlElement main_root;

        public ObservableCollection<Contact> cont_col { get; set; }

        public MainWindow()
        {
            cont_col = new ObservableCollection<Contact>();

            InitializeComponent();

            main_doc.Load("contacts.xml");
            main_root = main_doc.DocumentElement;

        }

        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            String[] con_string = new String[4]; byte hit_limit = 0; int grid_count = 0;

            cont_col.Clear();
            
            con_string[0] = last_name_init.Text.Trim();
            con_string[1] = first_name_init.Text.Trim();
            con_string[2] = middle_name_init.Text.Trim();
            con_string[3] = phone_init.Text.Trim();

            for(int i = 0; i < 4; i++)
                if(con_string[i].Length != 0) 
                {
                    hit_limit++;
                }

            
            for (int i = 0; i < main_root.ChildNodes.Count; i += 4)
            {
                byte count_t = 0;

                for (int j = 0; j < 4; j++)
                {
                    if ((con_string[j].CompareTo(main_root.ChildNodes.Item(i + j).InnerText) == 0) && (con_string[j].Length > 0))
                    {
                        count_t++;
                    }
                }

                if (count_t == hit_limit)
                {
                    cont_col.Add(new Contact
                    {
                        last_name = main_root.ChildNodes.Item(i).InnerText,
                        first_name = main_root.ChildNodes.Item(i + 1).InnerText,
                        middle_name = main_root.ChildNodes.Item(i + 2).InnerText,
                        phone = main_root.ChildNodes.Item(i + 3).InnerText
                    });

                    grid_count++;
                }

                
            }

        }


    }
}
