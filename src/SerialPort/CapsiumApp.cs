using Capsium;

public class CapsiumApp : App<Windows>
{
    public static async Task Main(string[] args)
    {
        await CapsiumOS.Start(args);
    }

    public override Task Initialize()
    {
        var names = Device.PlatformOS.GetSerialPortNames();

        // use the first one - adjust to your needs
        var port = Device.CreateSerialPort(names.First());
        port.Open();


        return Task.CompletedTask;
    }

    public override async Task Run()
    {
    }
}