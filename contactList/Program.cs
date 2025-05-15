using System;
using System.Collections.Generic;
using System.Threading.Channels;

class Contact
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }

    // Constructor to initialize the contact
    public Contact (string name, string phoneNumber)
    {
        Name = name;
        PhoneNumber = phoneNumber;
    }
}

class ContactManager
{
    // List to store Contact objects
    private List<Contact> contacts = new List<Contact>();

    // Method to add a new contact
    public void AddContact()
    {
        /*
        Console.WriteLine("Enter contact name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Enter phone nubmer: ");
        string phoneNumber = Console.ReadLine(); 
        */
        
        string name;
        do
        {
            Console.WriteLine("Enter contact name: ");
            name = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty. Please try again!\n");
            }

        } while (string.IsNullOrEmpty(name));

        string phoneNumber;
        do
        {
            Console.WriteLine("Enter phone number : ");
            phoneNumber = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(phoneNumber))
            {
                Console.WriteLine("Phone Number expected! Please try again!\n ");
            }
        } while (string.IsNullOrEmpty(phoneNumber));

        // Create a new contact object and add it to the list
        Contact newContact = new Contact(name, phoneNumber);
        contacts.Add(newContact);

        Console.WriteLine("\nContact added successfully!\n");

       
    }

    public void DisplayContacts()
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts available.");
            return;
        }

        Console.WriteLine("\nContact List: ");
        Console.WriteLine("---------------------------------");
        foreach (var contact in contacts)
        {
            Console.WriteLine($"Name: {contact.Name}, Phone : {contact.PhoneNumber}");
        }

        Console.WriteLine();
    }

    public void SearchContact()
    {
        Console.WriteLine("Enter the name to search: ");
        string searchName = Console.ReadLine()?.Trim();

        bool found = false;
        foreach (var contact in contacts)
        {
            if(contact.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase)) /*Use 'StringComparison.OrdinalIgnoreCase'?
                                                                                     Makes the search case-insensitive, so "John" and "john" are treated the same.
                                                                                     More user-friendly and practical in real - world scenarios.*/
                            {
                Console.WriteLine($"\nFound: Name: {contact.Name}, Phone: {contact.PhoneNumber}");
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Contact not found!");
        }
        Console.WriteLine();
    }

}//End of ContactManager

class Program
{
    static void Main(string[] args)
    {
        ContactManager manager = new ContactManager();
        manager.AddContact();
        manager.DisplayContacts();
        manager.SearchContact();


    }
}



