using Microsoft.AspNetCore.SignalR;
using SignalRApplication.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApplication.Hubs
{
    public class MyHub : Hub<IMessageClient>
    {

        static List<string> hubClients = new List<string>();
        //Merhaba yazdın gönderdin.

        //ilk yazılan method bu .
        //clinetta mesaj yazılıp entera tıklandıgın.
        //alttakı methodu cagıracagız.
        //alttakı method ıse clienttaki receiveMessageOnClient methodu cagıracak
        //receıve meyhodu da degısıklıklerı clıenttan clıentalara verecek.
        //public async Task SendMessageAsync(string message)
        //{
        //    //Clienttaki hangi methodu tetikleyecegim
        //    await Clients.All.SendAsync("receiveMessageOnClient", message);
        //    //receive metodu append yapıyor
        //}

        //Bağlantı olayları 
        //bir client bağlandığında burayı tetikler.
        public override async Task OnConnectedAsync()
        {
            hubClients.Add(Context.ConnectionId);
            //Buraları yorum satırı yaptık cunku artık methodları elle yazmıyoruz interfacelerden alıyoruz

            //await Clients.All.SendAsync("getHubClients", hubClients);
            //await Clients.All.SendAsync("userJoined", Context.ConnectionId);
            await Clients.All.GetHubClients(hubClients);
            await Clients.All.UserJoined(Context.ConnectionId);
        }
        //bir clientın bağlantısı koptuğunda burayı tetikler.
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            hubClients.Remove(Context.ConnectionId);
            //await Clients.All.SendAsync("getHubClients", hubClients);
            //await Clients.All.SendAsync("userLeaved", Context.ConnectionId);
            await Clients.All.GetHubClients(hubClients);
            await Clients.All.GetHubClients(hubClients);
            await Clients.All.UserLeaved(Context.ConnectionId);
        }
    }
}
