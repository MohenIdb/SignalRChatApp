using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SignalRChatApp.Models;
using System.Data.Entity;


namespace SignalRChatApp.Models
{
    public class ChatContext : DbContext
    {
        public ChatContext() : base("DbCon")
        {

        }
        public DbSet<ChatMessage> ChatMessages { get; set; }
    }
}