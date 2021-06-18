using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApplication.Interface
{
    public interface IMessageClient
    {
        //Serverdaki methodların aynı ısmıyle bir method olusuturoyurz.
        //Bunla direk erişebilecegiz.
        //public class MyHub : Hub<IMessageClient> ekledik.
        //Hubtan methodlara dırek erişim yaptık

        Task GetHubClients(List<string> getHubClients);
        Task UserJoined(string connectionId);
        Task UserLeaved(string connectionId);
    }
}
