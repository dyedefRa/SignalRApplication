using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApplication.Hubs
{
    public class MyHub : Hub
    {
        //Merhaba yazdın gönderdin.
        
        //ilk yazılan method bu .
        //clinetta mesaj yazılıp entera tıklandıgın.
        //alttakı methodu cagıracagız.
        //alttakı method ıse clienttaki receive methodu cagıracak
        //receıve meyhodu da degısıklıklerı clıenttan clıentalara verecek.
        public async Task SendMessageAsync(string message)
        {
            //Clienttaki hangi methodu tetikleyecegim
            await Clients.All.SendAsync("receiveMessageOnClient", message);
        }
    }
}
