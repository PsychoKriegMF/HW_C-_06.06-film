using HW_C__06._06_film;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_C__06._06_film
{
    public class ProgramContact
    {
        public void Start()
        {
            var contactManager = new ContactManager();
            while (true)
            {
                Console.WriteLine("Меню");
                Console.WriteLine("1. Добавить контакт");
                Console.WriteLine("2. Удалить контакт");
                Console.WriteLine("3. Найти контакт по имени");
                Console.WriteLine("4. Найти контакт по номеру");
                Console.WriteLine("5. Сохранить контакты (JSON)");
                Console.WriteLine("6. Загрузить контакты (JSON)");
                Console.WriteLine("7. Сохранить контакты (XML)");
                Console.WriteLine("8. Загрузить контакты (XML)");
                Console.WriteLine("9. Выход");
                Console.Write("Ваш выбор: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите имя: ");
                        string name = Console.ReadLine();
                        Console.Write("Введите номер: ");
                        string phoneNumber = Console.ReadLine();
                        contactManager.AddContact(name, phoneNumber);
                        Console.WriteLine("Контакт добавлен.");
                        break;
                    case "2":
                        Console.Write("Введите имя для удаления: ");
                        string nameToRemove = Console.ReadLine();
                        try
                        {
                            contactManager.RemoveContact(nameToRemove);
                            Console.WriteLine("Контакт удален.");
                        }
                        catch (KeyNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "3":
                        Console.Write("Введите имя для поиска: ");
                        string nameToFind = Console.ReadLine();
                        try
                        {
                            var contact = contactManager.FindContactByName(nameToFind);
                            Console.WriteLine($"Контакт найден: {contact.Name}, {contact.PhoneNumber}");
                        }
                        catch (KeyNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "4":
                        Console.Write("Введите номер для поиска: ");
                        string phoneNumberToFind = Console.ReadLine();
                        try
                        {
                            var contact = contactManager.FindContactByPhoneNumber(phoneNumberToFind);
                            Console.WriteLine($"Контакт найден: {contact.Name}, {contact.PhoneNumber}");
                        }
                        catch (KeyNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "5":
                        Console.Write("Сохранить контакты (JSON): ");
                        string jsonFilePath = Console.ReadLine();
                        contactManager.SaveToJson(jsonFilePath);
                        Console.WriteLine("Контакты сохранены.");
                        break;
                    case "6":
                        Console.Write("Загрузить контакты (JSON): ");
                        string jsonFilePathToLoad = Console.ReadLine();
                        contactManager.LoadFromJson(jsonFilePathToLoad);
                        Console.WriteLine("Контакты загружены.");
                        break;
                    case "7":
                        Console.Write("Сохранить контакты (XML): ");
                        string xmlFilePath = Console.ReadLine();
                        contactManager.SaveToXml(xmlFilePath);
                        Console.WriteLine("Контакты сохранены.");
                        break;
                    case "8":
                        Console.Write("Загрузить контакты (XML): ");
                        string xmlFilePathToLoad = Console.ReadLine();
                        contactManager.LoadFromXml(xmlFilePathToLoad);
                        Console.WriteLine("Контакты загружены.");
                        break;
                    case "9":
                        return;
                    default:
                        Console.WriteLine("Не корректный ввод. Попробуйте снова.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
