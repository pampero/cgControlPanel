using log4net.Config;
using Topshelf;
using System.Configuration;

namespace Quartz.Server
{
    /// <summary>
    /// The server's main entry point.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            XmlConfigurator.Configure();

            Host host = HostFactory.New(x =>   
            {
                x.Service<IQuartzServer>(s =>               
                {
                    s.SetServiceName("quartz.server");                                
                    s.ConstructUsing(builder =>
                                            {
                                                QuartzServer server = new QuartzServer();
                                                server.Initialize();
                                                return server;
                                            });  
                    s.WhenStarted(server => server.Start());
                    s.WhenPaused(server => server.Pause());
                    s.WhenContinued(server => server.Resume());
                    s.WhenStopped(server => server.Stop());             
                });

                x.RunAsLocalSystem();                            

                x.SetDescription(Configuration.ServiceDescription);        
                x.SetDisplayName(Configuration.ServiceDisplayName);                      
                x.SetServiceName(Configuration.ServiceName);                       
            });

            host.Run();
        }

    }
}
