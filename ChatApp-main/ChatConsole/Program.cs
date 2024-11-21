using ChatApp.Net.IO;
using ChatConsole;
using ChatApp;
using System.Collections.ObjectModel;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;
using ChatConsole.ViewModel;
using ChatConsole.Model;

class Program
{
    static void Main()
    {
        string name = Environment.GetEnvironmentVariable("USERNAME");

        if (string.IsNullOrEmpty(name))
        {
            // If the environment variable is not set, ask the user to input the username
            Console.Write("Enter your username: ");
            name = Console.ReadLine();
        }

        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Username cannot be empty. Exiting...");
            return;
        }

        var server = new Server();

        // Attempt to connect to the server
        if (!server.ConnectToServer(name))  // Connect with the dynamic username
        {
            Console.WriteLine("Connection failed. Ensure the server is running.");
            return;
        }

        Console.WriteLine($"Connected as {name}. You can now start sending messages.");

        var input = new MainViewModel(name);

        // Allow the user to send messages
        while (true)
        {
            Console.Write("Enter message: ");
            var message = Console.ReadLine();
            if (!string.IsNullOrEmpty(message))
            {
                input.SendMessage(message);
                server.SendMessageToServer(message);
            }
            else
            {
                Console.WriteLine("Please enter a message.");
            }
        }
    }
}