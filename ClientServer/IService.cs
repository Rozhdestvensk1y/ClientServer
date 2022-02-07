using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Wcf
{
    [ServiceContract(CallbackContract = typeof(IServiceCallBack))]
    public interface IService
    {
        [OperationContract]
        int Connect(string name);
        [OperationContract]
        void Disconect(int id);

        [OperationContract]
        string IsPalindrome(string msg);

        [OperationContract(IsOneWay = true)]
        void SendMsg(string msg, int id);

    }
    public interface IServiceCallBack
    {
        [OperationContract(IsOneWay = true)]
        void CallBackMsg(String msg);

    }
}
