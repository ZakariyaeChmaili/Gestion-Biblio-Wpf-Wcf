using FullApp2.Services.Interfaces;

namespace FullApp2.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
