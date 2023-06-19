namespace Simple_Chat_ASP.NET_Core_MVC_App.Models
{
    public class ChatViewModel
    {
        public MessageViewModel CurrentMessage { get; set; } = null!;

        public List<MessageViewModel> Messages { get; set; } = new List<MessageViewModel>();
    }
}
