using ChatClient.Net;
using ChatConsole;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;


string name;
Console.WriteLine("Name: ");
name = Console.ReadLine();
Server server = new Server();
server.ConnectToServer(name);
server.SendMessageToServer("aaaa");