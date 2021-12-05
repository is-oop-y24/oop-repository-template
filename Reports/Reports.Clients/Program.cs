using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Reports.DAL.Entities;

namespace Reports.Clients
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            CreateEmployee();
            FindEmployeeById("ac8ac3ce-f738-4cd6-b131-1aa0e16eaadc");
            FindEmployeeByName("aboba");
            FindEmployeeByName("kek");
        }

        private static void CreateEmployee()
        {
            // Запрос к серверу
            var request = HttpWebRequest.Create("https://localhost:5001/employees/?name=Aboba");
            request.Method = WebRequestMethods.Http.Post;
            var response = request.GetResponse();

            // Чтение ответа
            var responseStream = response.GetResponseStream();
            using var readStream = new StreamReader(responseStream, Encoding.UTF8);
            var responseString = readStream.ReadToEnd();

            // Десериализация (перевод JSON'a к C# классу)
            var employee = JsonConvert.DeserializeObject<Employee>(responseString);

            Console.WriteLine("Created employee:");
            Console.WriteLine($"Id: {employee.Id}");
            Console.WriteLine($"Name: {employee.Name}");
        }

        private static void FindEmployeeById(string id)
        {
            // Запрос к серверу
            var request = HttpWebRequest.Create($"https://localhost:5001/employees/?id={id}");
            request.Method = WebRequestMethods.Http.Get;

            try
            {
                var response = request.GetResponse();

                // Чтение ответа
                var responseStream = response.GetResponseStream();
                using var readStream = new StreamReader(responseStream, Encoding.UTF8);
                var responseString = readStream.ReadToEnd();

                // Десериализация (перевод JSON'a к C# классу)
                var employee = JsonConvert.DeserializeObject<Employee>(responseString);

                Console.WriteLine("Found employee by id:");
                Console.WriteLine($"Id: {employee.Id}");
                Console.WriteLine($"Name: {employee.Name}");
            }
            catch (WebException e)
            {
                Console.WriteLine("Employee was not found");
                Console.Error.WriteLine(e.Message);
            }
        }

        private static void FindEmployeeByName(string name)
        {
            // Запрос к серверу
            var request = HttpWebRequest.Create($"https://localhost:5001/employees/?name={name}");
            request.Method = WebRequestMethods.Http.Get;
            try
            {
                var response = request.GetResponse();

                // Чтение ответа
                var responseStream = response.GetResponseStream();
                using var readStream = new StreamReader(responseStream, Encoding.UTF8);
                var responseString = readStream.ReadToEnd();

                // Десериализация (перевод JSON'a к C# классу)
                var employee = JsonConvert.DeserializeObject<Employee>(responseString);

                Console.WriteLine("Found employee by name:");
                Console.WriteLine($"Id: {employee.Id}");
                Console.WriteLine($"Name: {employee.Name}");
            }
            catch (WebException e)
            {
                Console.WriteLine("Employee was not found");
                Console.Error.WriteLine(e.Message);
            }
        }
    }
}