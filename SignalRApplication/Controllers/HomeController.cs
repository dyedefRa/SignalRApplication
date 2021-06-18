using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRApplication.Business;
using SignalRApplication.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        //burada mybusiness i dependency injection ile talep edecegım

        readonly MyBusiness _myBusiness;
        //eğer ekstra bir methodlara gerek yoksa usttekı gıbı myBusiness ile Ihub yapmaya gerek yok alttaki yorum satırı gıbı de ulasabılırsın.

        //readonly IHubContext<MyHub> _hubContext;
        //ctorda ayarla yukarıyı.
        public HomeController(MyBusiness myBusiness)
        {
            _myBusiness = myBusiness;
        }

        [HttpGet("{message}")]
        public async Task<IActionResult> Index(string message)
        {
            await _myBusiness.SendMessageAsync(message);
            return Ok();
        }
    }
}
