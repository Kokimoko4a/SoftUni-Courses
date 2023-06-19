using Microsoft.AspNetCore.Mvc;
using Simple_Chat_ASP.NET_Core_MVC_App.Models;

namespace Simple_Chat_ASP.NET_Core_MVC_App.Controllers
{
    public class ChatController : Controller
    {
        private static List<KeyValuePair<string, string>> messages = new List<KeyValuePair<string, string>>();

        public IActionResult Show()
        {
            if (messages.Count < 1)
            {
                return View(new ChatViewModel());
            }

            var chat = new ChatViewModel()
            {
                Messages = messages.Select(x => new MessageViewModel() { Sender = x.Key, Message = x.Value }).ToList()
            };

            return View(chat);
        }

        [HttpPost]
        public IActionResult Send(ChatViewModel chat)
        {
            var newMessage = chat.CurrentMessage;

            messages.Add(new KeyValuePair<string, string>(newMessage.Sender, newMessage.Message));

            return Redirect("Show");
        }
    }
}
