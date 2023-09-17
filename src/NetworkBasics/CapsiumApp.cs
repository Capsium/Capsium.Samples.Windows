using Capsium;
using System.Threading.Tasks;

namespace WiFi_Basics
{
    public class CapsiumApp : App<Windows>
    {
        public static async Task Main(string[] args)
        {
            await CapsiumOS.Start(args);
        }

        public override Task Run()
        {
            Resolver.Log.Info($"Capsium.Windows Network Sample");

            Resolver.Log.Info($"{Device.NetworkAdapters.Count} network adapters detected");
            Resolver.Log.Info($"----------------------------");

            foreach (var adapter in Device.NetworkAdapters)
            {
                Resolver.Log.Info($"  {adapter.Name}  {adapter.IpAddress}");
            }

            return Task.CompletedTask;
        }
    }
}
