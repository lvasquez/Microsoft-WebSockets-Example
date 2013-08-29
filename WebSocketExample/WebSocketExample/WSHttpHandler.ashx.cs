﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Web.WebSockets;

namespace WebSocketExample
{
    /// <summary>
    /// Summary description for WSHttpHandler
    /// </summary>
    public class WSHttpHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
                context.AcceptWebSocketRequest(new MySocketHandler());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}