///-----------------------------------------------------------------
///   File:         InnogyWebSocketHandler.cs
///   Author:   	Andre Laskawy           
///   Date:         12.10.2018 19:24:20
///-----------------------------------------------------------------

namespace SmartHome.Innogy.Handler
{
    using Newtonsoft.Json;
    using SmartHome.Innogy.Models;
    using System;
    using System.Collections.Generic;
    using WebSocket4Net;

    /// <summary>
    /// Defines the <see cref="InnogyWebSocketHandler" />
    /// </summary>
    public class InnogyWebSocketHandler
    {
        /// <summary>
        /// The socket URL
        /// </summary>
        private const string socketURL = "wss://api.services-smarthome.de/API/1.0/events";

        /// <summary>
        /// The websocket
        /// </summary>
        private WebSocket websocket;

        /// <summary>
        /// Gets or sets the innogy event.
        /// </summary>
        public Action<EventData> InnogyEvent { get; set; }

        /// <summary>
        /// Opens the socket
        /// </summary>
        /// <param name="token">The token.</param>
        public void Open(string token)
        {
            if (websocket != null)
                websocket.Close();

            websocket = new WebSocket(socketURL + "?token=" + token);
            websocket.MessageReceived += WebSocket_MessageReceived;
            websocket.Open();
        }

        /// <summary>
        /// Handles the MessageReceived event of the webSocket control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="WebSocket4Net.MessageReceivedEventArgs" /> instance containing the event data.</param>
        private void WebSocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            List<EventData> eventList = default(List<EventData>);
            eventList = JsonConvert.DeserializeObject<List<EventData>>(e.Message);

            foreach (var ev in eventList)
            {
                InnogyEvent(ev);
            }
        }
    }
}