using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRChatApp.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }

    }
}