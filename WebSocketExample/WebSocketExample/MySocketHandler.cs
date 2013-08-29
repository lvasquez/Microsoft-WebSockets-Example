using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Web.WebSockets;

namespace WebSocketExample
{
    public class MySocketHandler : WebSocketHandler
    {
        private static WebSocketCollection clients = new WebSocketCollection();
        private string name;

        public override void OnOpen()
        {
            this.name = this.WebSocketContext.QueryString["name"];
            clients.Add(this);
            clients.Broadcast(name + " has connected.");
        }

        public override void OnMessage(string message)
        {
            clients.Broadcast(string.Format("{0} said: {1}", name, message));
        }


        public override void OnClose()
        {
            clients.Remove(this);
            clients.Broadcast(string.Format("{0} has gone away", name));
        }
    }
}
