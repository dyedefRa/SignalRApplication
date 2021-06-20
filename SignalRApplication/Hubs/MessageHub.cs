using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApplication.Hubs
{
    public class MessageHub : Hub
    {
        //clienttan tetiklenen methodumuz bu.
        //Aynı zamanda bu method clienttaki methodu tetikler.
        //public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
        //{
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

        //await Clients.AllExcept(connectionIds).SendAsync("receiveMessageOnClient", message);
        #endregion
        #region Client**
        //Sadece ConnectionId ile Belirtilen clienta bildirim gönderir.
        //Whatsapptaki bir kişiye mesaj atmak bununla yapılır.

        //await Clients.Client(connectionIds.FirstOrDefault()).SendAsync("receiveMessageOnClient", message);
        #endregion
        #region Clients
        //Sadece ConnectionId ile Belirtilen clientlara bildirim gönderir.
        //Whatsapptaki toplu mesaj atmak bununla yapılır.

        //await Clients.Clients(connectionIds).SendAsync("receiveMessageOnClient", message);
        #endregion
        #region Group**
        //Belirtilen gruptaki tüm clientlara bildirimde bulunur.
        //Tabiki ilgili grupu oluşturmamız gerekıyor (addGroup methodunu olusturduk)
        //öncesinde ilgili clienta group sectırdık. ve butona bastıgında addGroup fonk calıstı.Ardından alttaki method Group.SendAsync
        //methodu ile grouptaki clientlara mesaj gonderdık.
        //Group name lazım old. için. 
        //public async Task SendMessageAsync(string message, string groupName)
        //{
        //    await Clients.Group(groupName).SendAsync("receiveMessageOnClient", message);
        #endregion
        #region GroupExcept
        //Belirtilen gruptaki belirtilen clientlar dışındaki tüm clientlara bildirimde bulunur.

        //Alttaki methodu kullan.Clienttada bu methoda özel fonk yazdık.
        //public async Task SendMessageAsync(string message, string groupName,IEnumerable<string> connectionIds)
        //{
        //    await Clients.GroupExcept(groupName, connectionIds).SendAsync("receiveMessageOnClient", message);
        #endregion
        #region Groups**
        //Birden çok gruptaki clientalra bildirimde bulunduran methoddur.

        //public async Task SendMessageAsync(string message, IEnumerable<string> groupNames)
        //{
        //    await Clients.Groups(groupNames).SendAsync("receiveMessageOnClient", message);
        #endregion
        #region OthersInGroup
        //Bildiride bulunan client haricinde grupta bulunan tüm clientlara bildirim yapan fonksiyondur.

        public async Task SendMessageAsync(string message, string groupName)
        {
            await Clients.OthersInGroup(groupName).SendAsync("receiveMessageOnClient", message);
            #endregion
            #endregion
        }

        //Client bağlandığında connectionId yazdıralım.
        public async override Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("receiveConnectionId", Context.ConnectionId);
        }

        //Clientın radioButon ile seçtigi Grubu bu method ile serverda yakalıyoruz.İlgili clienti o gruba ekliyoruz.

        public async Task addGroup(string connectionId, string groupName)
        {
            await Groups.AddToGroupAsync(connectionId, groupName);
        }
    }
}
