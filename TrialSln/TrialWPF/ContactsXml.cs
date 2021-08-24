using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace TrialWPF
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "contacts")]
    public partial class ContactsXml
    {
        /// <remarks/>
        [XmlElement("contact")]
        public List<Contact> Contacts { get; set; }

    }
}
