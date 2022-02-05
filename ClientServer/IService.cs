using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ClientServer
{
    [ServiceContract(CallbackContract = typeof(IServiceCallBack))]
    public interface IService
    {
        [OperationContract]
        int Connect(string name);
        [OperationContract]
        void Disconect(int id);

        bool IsPalindrome(string msg);

    }
    public interface IServiceCallBack
    {
        [OperationContract]
        void CallBackMsg(String msg);

    }
}
