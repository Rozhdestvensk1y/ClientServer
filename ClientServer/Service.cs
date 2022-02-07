using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Wcf
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        List<ServerUser> users = new List<ServerUser> ();
        int nextId = 1;
        public int maxRequests = Help.ReadInt64("Введите максимальное количество запросов к серверу:");
        public int Connect(string name)
        {
            ServerUser user = new ServerUser()
            {
                Id = nextId,
                Name = name,
                operationContext = OperationContext.Current
            };
            nextId++;
            users.Add(user);
            Console.WriteLine($"Подключен клиент {user.Name} id{user.Id}");
            return user.Id;
            
        }

        public void Disconect(int id)
        {
            var user = users.FirstOrDefault(i => i.Id == id);
            if(user != null)
            {
                users.Remove(user);
            }
            Console.WriteLine($"Отключен клиент id{user.Id} с именем {user.Name}");
        }

        public void DoWork()
        {
        }

        public string IsPalindrome(string msg)
        {
            int i = 0, j = msg.Length - 1;
            while (i < j)
            {
                if (char.IsWhiteSpace(msg[i]) || char.IsPunctuation(msg[i]))
                    i++;
                else if (char.IsWhiteSpace(msg[j]) || char.IsPunctuation(msg[j]))
                    j--;
                else if (char.ToLowerInvariant(msg[i++]) != char.ToLowerInvariant(msg[j--]))
                    return "Не является палиндромом";
            }
            return "Является палиндромом";
        }

        public void SendMsg(string msg, int id)
        {
            foreach (var item in users)
            {
                if (item.Id == id)
                {
                    Console.WriteLine($"Клиент id{id} отправил сообщение {msg}");
                    string answer = DateTime.Now.ToShortTimeString();
                    string PalOrNot = IsPalindrome(msg);
                    var user = users.FirstOrDefault(i => i.Id == id);
                    if (user != null)
                    {
                        answer += ":" + user.Name + " " + PalOrNot;
                    }
                    item.operationContext.GetCallbackChannel<IServiceCallBack>().CallBackMsg(answer);
                    break;
                }
            }
        }
    }
}
