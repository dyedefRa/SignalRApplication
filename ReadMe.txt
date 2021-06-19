--SignalR i tanýtmamýz ve hangi endpointi kullanacaðýmýzý bildirmemiz gerekiyor.

----------------------------
--controllerdan servis mantýgýyla hubý cekebýlýyoruz
--IHubContext ile servis mimarisine uygun SignalR ý kullanabýlýrýz. Dýþardaki bir sýnýftan eriþip kontrolu saglayabýlýryoruz. (MyBusiness.cs)

 services.AddTransient<MyBusiness>();

 ----------------------------

 Manual controller ekledik . 
 Startup.cs >
  endpoints.MapControllers();
  services.AddControllers();

   ----------------------------

Strongly Type Hubs>

Bunun için IMessageClient olusturduk ve kullandýgýmýz , clientta yakalamaya calýstýgýmýz methodlarý ekledik
metodlarý clientta yada serverda yazarken yanlýþ yazýmlarý önlemek için kullanýyoruz.
ilgili Hubta >  '  public class MyHub : Hub<IMessageClient> ' yazarak metodlarýna eriþecegiz


   ----------------------------