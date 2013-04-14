using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SignalR.Client.Hubs;
using SignalRConsole.SignalR.MessengerHub;
using SignalR.Hosting.Self;
using SignalR;
using System.Threading.Tasks;

namespace SignalRConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new HubConnection("http://localhost:9616/");
            SignalRConsole.SignalR.MessengerHub.Message message = new SignalR.MessengerHub.Message();
            message.Content = "Moo";
            message.Duration = 500;
            message.Title = "Hello Title";
            var myHub = connection.CreateProxy("messenger");
            connection.Start().Wait();
            Object[] myData = { (Object)message, "sourcing" };
            myHub.Invoke("broadCastMessage", myData);
        }

        
    }
}
