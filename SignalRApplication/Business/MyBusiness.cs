using Microsoft.AspNetCore.SignalR;
using SignalRApplication.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApplication.Business
{
    //Servis mantığında çalışırken normal sınıflarda ulaşabılmemız ıcın IHubContext sınıfından yararlanıyoruz.Dışarıdan daha rahat erişebilmemiz için
    public class MyBusiness
    {
        //Hubtayız ama dolaylı yoldan hubtayız.
        //Herhangi bir conttollerdan çagırabılıyoruz.
        readonly IHubContext<MyHub> _hubContext;

        public MyBusiness(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageAsync(string message)
        {
            //Clienttaki hangi methodu tetikleyecegim
            await _hubContext.Clients.All.SendAsync("receiveMessageOnClient", message);
            //receive metodu append yapıyor
        }
    }
}
