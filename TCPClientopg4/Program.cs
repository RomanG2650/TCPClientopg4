using System;
using System.IO;
using System.Net.Sockets;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            
            using (TcpClient client = new TcpClient("127.0.0.1", 7))
            using (NetworkStream ns = client.GetStream())
            using (StreamReader reader = new StreamReader(ns))
            using (StreamWriter writer = new StreamWriter(ns) { AutoFlush = true })
            {
                Console.WriteLine("Connected to server.");

                
                while (true)
                {
                    Console.WriteLine("Enter a command (Random, Add, Subtract) or type 'exit' to quit:");
                    string? command = Console.ReadLine();

                  
                    if (command.ToLower() == "exit")
                    {
                        break;
                    }

                  
                    writer.WriteLine(command);

                   
                    string? serverResponse = reader.ReadLine();
                    Console.WriteLine("Server: " + serverResponse);

                    
                    if (serverResponse == "Input numbers")
                    {
                        Console.WriteLine("Please enter two numbers separated by a space:");
                        string? numbers = Console.ReadLine();
                        writer.WriteLine(numbers);

                        
                        string result = reader.ReadLine();
                        Console.WriteLine("Server: " + result);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error has occurred: " + ex.Message);
        }
    }
}
