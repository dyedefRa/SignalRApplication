npm i jquery @microsoft/signalr indirdik

----------------EVENTS----------------

 //Yeniden bağlantı talebi yapılmadan önce tetiklenir.
        connection.onreconnecting

//Yeniden bağlantı gerçekleştiğinde tetiklenir.
        connection.onreconnected

//Yeniden bağlantı girişiminin sonuçsuz kaldığı durumlarda tetiklenir.
connection.onclose

---------------------------

ConnectionId nedir?
Hub'a bağlantı gerçektiren clientlara sistem tarafından verilen unique bir değerdir.
Amaç clientları birbirinden ayırmaktır.