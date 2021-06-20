using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApplication.Hubs
{
    public class MessageHub : Hub
    {
        public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
        {
            #region CLIENT TURLERI

            #region All
            // Tüm clientlara gönderir.
            //await Clients.All.SendAsync("receiveMessageOnClient", message);
            #endregion
            #region Caller
            // Sadece servera bildirim gönderen clientla etkileşime geçer.
            //await Clients.Caller.SendAsync("receiveMessageOnClient", message);
            #endregion
            #region Other
            //  Bildirim gönderen client dışındaki tüm bağlı olan clientlara bildirim gönderir.
            //await Clients.Other.SendAsync("receiveMessageOnClient", message);
            #endregion

            #endregion

            #region HUB CLIENT METHODLARI

            #region AllExcept
            //Belirtilen clientlar hariç tüm clientlara bildirimde bulunur.

            await Clients.AllExcept(connectionIds).SendAsync("receiveMessageOnClient", message);

            #endregion

            #endregion
        }

        //Client bağlandığında connectionId yazdıralım.
        public async override Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("receiveConnectionId", Context.ConnectionId);
        }
    }
}
