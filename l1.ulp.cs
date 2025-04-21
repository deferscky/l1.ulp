using System;
interface IProtocol
{
    string Protocol();
}
abstract class Message : IProtocol // класс сообщение реализуется интерфейсом 
{
    public abstract string Protocol(); // абстрактный метод для получения протокола
}

class Email : Message // класс email наследуется от massage
{
    public string Sender { get; set; }
    public string Recipient { get; set; }
    public string Subject { get; set; }

    public Email(string sender, string recipient, string subject) // конструктор для инициализации свойств класса email
    {
        Sender = sender;
        Recipient = recipient;
        Subject = subject;
    }
    public override string Protocol() // метод для получения email
    {
        return "Email Protocol";
    }
    ~Email()
    {
        Console.WriteLine("Email объект уничтожен");
    }
}
class SMS : Message
{
    public string PhoneNumber { get; set; } 
    public string Text { get; set; } 

    public SMS(string phoneNumber, string text) // конструктор для инициализации свойств класса sms
    {
        PhoneNumber = phoneNumber;
        Text = text;
    }
    public override string Protocol() // метод для получения протокола sms
    {
        return "SMS Protocol";
    }
    ~SMS()
    {
        Console.WriteLine("SMS объект уничтожен");
    }
}
class Letter : Message
{
    public string SenderAddress { get; set; } 
    public string RecipientAddress { get; set; } 
    public string Content { get; set; }

   
    public Letter(string senderAddress, string recipientAddress, string content) //конструктор для инициализации свойств класса letter
    {
        SenderAddress = senderAddress;
        RecipientAddress = recipientAddress;
        Content = content;
    }
    public override string Protocol() // метод для получения протокола класса letter
    {
        return "Letter Protocol";
    }
    ~Letter()
    {
        Console.WriteLine("Letter объект уничтожен");
    }
}
class ElectronicMessage : Message
{
    public string Content { get; set; }
    public ElectronicMessage(string content) //конструктор
    {
        Content = content;
    }
    public override string Protocol() //метод для получения протокола electronic message
    {
        return "Electronic Message Protocol";
    }
    ~ElectronicMessage()
    {
        Console.WriteLine("ElectronicMessage объект уничтожен");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Message[] messages = new Message[4]; //массив для хранения сообщений 
        // созднание объектов 
        messages[0] = new Email("bobr@mail.ru", "crocodil@mail.ru", "Hello!");
        messages[1] = new SMS("+7900-800-10-10", "Hi!");
        messages[2] = new Letter("Staropupunski 12", "Pushkina 120", "This is a letter.");
        messages[3] = new ElectronicMessage("This is an electronic message.");

        foreach (var message in messages)
        {
            Console.WriteLine($"Protocol: {message.Protocol()}");
            switch (message)
            {
                case Email email:
                    Console.WriteLine($"Sender: {email.Sender}, Recipient: {email.Recipient}, Subject: {email.Subject}");
                    break;
                case SMS sms:
                    Console.WriteLine($"Phone Number: {sms.PhoneNumber}, Text: {sms.Text}");
                    break;
                case Letter letter:

                    Console.WriteLine($"Sender Address: {letter.SenderAddress}, Recipient Address: {letter.RecipientAddress}, Content: {letter.Content}");
                    break;
                case ElectronicMessage electronicMessage:
                    Console.WriteLine($"Content: {electronicMessage.Content}");
                    break;
            }
            Console.WriteLine();
        }
    }
}
