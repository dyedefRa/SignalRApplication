--SignalR i tan�tmam�z ve hangi endpointi kullanaca��m�z� bildirmemiz gerekiyor.

----------------------------
--controllerdan servis mant�g�yla hub� cekeb�l�yoruz
--IHubContext ile servis mimarisine uygun SignalR � kullanab�l�r�z. D��ardaki bir s�n�ftan eri�ip kontrolu saglayab�l�ryoruz. (MyBusiness.cs)

 services.AddTransient<MyBusiness>();

 ----------------------------

 Manual controller ekledik . 
 Startup.cs >
  endpoints.MapControllers();
  services.AddControllers();

   ----------------------------

Strongly Type Hubs>

Bunun i�in IMessageClient olusturduk ve kulland�g�m�z , clientta yakalamaya cal�st�g�m�z methodlar� ekledik
metodlar� clientta yada serverda yazarken yanl�� yaz�mlar� �nlemek i�in kullan�yoruz.
ilgili Hubta >  '  public class MyHub : Hub<IMessageClient> ' yazarak metodlar�na eri�ecegiz


   ----------------------------