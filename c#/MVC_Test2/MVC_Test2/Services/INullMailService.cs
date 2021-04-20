namespace MVC_Test2.Services
{
    public interface INullMailService
    {
        void SendMessage(string to, string subject, string body);
    }
}