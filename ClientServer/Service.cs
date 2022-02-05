using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ClientServer
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        List<ClientServer> users = new List<ClientServer> ();
        int nextId = 1;
        public int Connect(string name)
        {
            ClientServer user = new ClientServer()
            {
                Id = nextId,
                Name = name,
                operationContext = OperationContext.Current
            };
            nextId++;
            users.Add(user);
            return user.Id;
            
        }

        public void Disconect(int id)
        {
            var user = users.FirstOrDefault(i => i.Id == id);
            if(user != null)
            {
                users.Remove(user);
            }
            throw new NotImplementedException();
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
            string answer = DateTime.Now.ToShortTimeString();
            string PalOrNot = IsPalindrome(msg);
            var user = users.FirstOrDefault(i => i.Id == id);
            if (user != null)
            {
               answer += ":" + user.Name + " " + PalOrNot;
            }
            user.operationContext.GetCallbackChannel<IServiceCallBack>().CallBackMsg(answer);
        }

    }
}
