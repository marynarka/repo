using System;

class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string JobTitle { get; set; }
    public string Company { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public Person(string firstName, string lastName, string jobTitle = null, string company = null, string email = null, string phoneNumber = null)
    {
        FirstName = firstName;
        LastName = lastName;
        JobTitle = jobTitle;
        Company = company;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public void DisplayShortInfo()
    {
        if (!string.IsNullOrEmpty(JobTitle) && !string.IsNullOrEmpty(Company))
        {
            Console.WriteLine($"{FirstName} {LastName} ({JobTitle} at {Company})");
        }
        else if (!string.IsNullOrEmpty(JobTitle) && string.IsNullOrEmpty(Company))
        {
            Console.WriteLine($"{FirstName} {LastName} ({JobTitle})");
        }
        else
        {
            Console.WriteLine($"{FirstName} {LastName}");
        }
    }

    public void DisplayFullInfo()
    {
        int maxLength = FirstName.Length + LastName.Length + 1;
        if (JobTitle != null) {
            maxLength = Math.Max(maxLength, JobTitle.Length);
        }
        if (Company != null) {
            maxLength = Math.Max(maxLength, Company.Length);
        }
        if (Email != null && Email.Contains("@")){ 
            maxLength = Math.Max(maxLength, Email.Length + 8); 
        }
        if (PhoneNumber != null){
            maxLength = Math.Max(maxLength, PhoneNumber.Length + 7); 
        }

        string separator = new string('=', maxLength);
        string separator1 = new string('-', maxLength);

        Console.WriteLine(separator);
        Console.WriteLine(FirstName + " " + LastName);

        if (!string.IsNullOrEmpty(JobTitle) || !string.IsNullOrEmpty(Company))
        {
            Console.WriteLine(separator1);
        }
        if (!string.IsNullOrEmpty(JobTitle))
        {
            Console.WriteLine(JobTitle);
        }
        if (!string.IsNullOrEmpty(Company))
        {
            Console.WriteLine(Company);
        }
        if (!string.IsNullOrEmpty(Email) && Email.Contains("@"))
        {
            Console.WriteLine(separator1);
            Console.WriteLine("E-mail: " + Email);
        }
        if (!string.IsNullOrEmpty(PhoneNumber) && (string.IsNullOrEmpty(Email) || !Email.Contains("@")))
        {
            Console.WriteLine(separator1);
            Console.WriteLine("Phone: " + PhoneNumber);
        }
        if (!string.IsNullOrEmpty(PhoneNumber) && !string.IsNullOrEmpty(Email) && Email.Contains("@"))
        {
            Console.WriteLine("Phone: " + PhoneNumber);
        }
        Console.WriteLine(separator);
    }
}

class Program
{
    static void Main()
    {
        var person1 = new Person("Jan", "Kowalski", "Senior Developer", "TechCorp Solutions", "jan.kowalski@example.com", "+48 123 456 789");
        var person2 = new Person("Anna", "Lis", "Manager", null, "anna.lis@company.com");
        var person3 = new Person("Piotr", "Nowak", null, null, null, "987-654-321");
        var person4 = new Person("Robert", "Lewandowski");
        var person5 = new Person("Jan", "Żiżka", "Długi tekst do sprawdzenia");
        var person6 = new Person("Kazimierz", "Wielki", "Król Polski", "Kolejny długi tekst do sprawdzenia");

        person1.DisplayFullInfo();

        person2.DisplayFullInfo();

        person3.DisplayFullInfo();

        Console.WriteLine("Wprowadź dane nowej osoby:");
        Console.Write("Imię: ");
        string firstName = Console.ReadLine();
        while(string.IsNullOrWhiteSpace(firstName))
        {
            Console.WriteLine("Imię nie może być puste!");
            Console.Write("Proszę wprowadzić imię: ");
            firstName = Console.ReadLine();
        }
        Console.Write("Nazwisko: ");
        string lastName = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(lastName))
        {
            Console.WriteLine("Nazwisko nie może być puste!");
            Console.Write("Proszę wprowadzić nazwisko: ");
            lastName = Console.ReadLine();
        }
        Console.Write("Stanowisko (opcjonalne): ");
        string jobTitle = Console.ReadLine();
        Console.Write("Firma (opcjonalne): ");
        string company = Console.ReadLine();
        Console.Write("E-mail (opcjonalne): ");
        string email = Console.ReadLine();
        Console.Write("Telefon (opcjonalne): ");
        string phoneNumber = Console.ReadLine();

        var newPerson = new Person(firstName, lastName, jobTitle, company, email, phoneNumber);

        newPerson.DisplayShortInfo();
        newPerson.DisplayFullInfo();
    }
}
