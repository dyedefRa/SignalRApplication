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