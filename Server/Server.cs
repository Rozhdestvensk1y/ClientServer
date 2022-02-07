using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Server
{
    internal class Server
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(Wcf.Service)))
            {
                try
                {
                    host.Open();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Сервер запущен!");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    throw new Exception("Не удалось открыть хост", ex);
                }

            }
        }
    }
}
