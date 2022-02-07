using System.ServiceModel;
using Wcf;

    public class ServerUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public OperationContext operationContext { get; set; }
    }

