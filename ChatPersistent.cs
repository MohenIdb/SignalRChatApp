using Microsoft.AspNet.SignalR;
using SignalRChatApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SignalRChatApp
{
    public class ChatPersistent : PersistentConnection
    {
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            return Connection.Send(connectionId, "Welcome!");
        }

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            ChatMessage chatMessage = new ChatMessage();
            chatMessage.UserName = "PChating";
            chatMessage.Message = data;
            //chatMessage.CurrentDate = DateTime.Now;

            ChatContext db = new ChatContext();
            db.ChatMessages.Add(chatMessage);
            db.SaveChanges();

            return Connection.Broadcast(data);
            
        }
    }
}