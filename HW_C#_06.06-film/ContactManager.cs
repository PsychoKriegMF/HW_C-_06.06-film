using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace HW_C__06._06_film
{
    public class ContactManager
    {
        private List<Contact> contacts = new List<Contact>();
        public void AddContact(string name, string phoneNumber)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phoneNumber))
            {
                throw new Exception("Не верный формат");
            }
            contacts.Add( new Contact (name,phoneNumber));
        }
        public void RemoveContact(string name)
        {
            var contact = contacts.FirstOrDefault(c => c.Name == name);
            if (contact != null)
            {
                contacts.Remove(contact);
            }
            else
            {
                throw new Exception("Такого контакта нет");
            }
        }
        public Contact FindContactByName(string name)
        {
            var contact = contacts.FirstOrDefault(c => c.Name == name);
            return contact;
        }
        public Contact FindContactByPhoneNumber(string phoneNumber)
        {
            var contact = contacts.FirstOrDefault(c => c.PhoneNumber == phoneNumber);
            if (contact != null) return contact;
            else throw new Exception("Нет контакта такого.");
        }
        public void SaveToJson(string filePath)
        {
            var json = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            File.WriteAllText(filePath,json);
        }
        public void LoadFromJson(string filePath)
        {
            var json = File.ReadAllText(filePath);
            contacts = JsonConvert.DeserializeObject<List<Contact>>(json);
        }
        public void SaveToXml(string filePath)
        {
            XElement xml = new XElement("Contacts",
                from contact in contacts
                select new XElement("Contact",
                new XAttribute("Name", contact.Name),
                new XAttribute("PhoneNumber", contact.PhoneNumber)));
                xml.Save(filePath);
        }
        public void LoadFromXml(string filePath)
        {
            var serializer = new XmlSerializer(typeof(List<Contact>));
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                contacts = (List<Contact>)serializer.Deserialize(stream);
            }
        }

    }
}
