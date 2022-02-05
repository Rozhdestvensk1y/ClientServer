using System.ServiceModel;

namespace ClientServer
{
    public class ClientServer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public OperationContext operationContext { get; set; }
    }
}
