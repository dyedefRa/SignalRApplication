using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApplication.Hubs
{
    public class MyHub : Hub
    {
        //Merhaba yazan herhangi bir clientin methodu
        public async Task SendMessageAsync(string message)
        {

        }
    }
}
