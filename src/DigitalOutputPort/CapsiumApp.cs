using Capsium;
using Capsium.Foundation.ICs.IOExpanders;
using Capsium.Hardware;

public class CapsiumApp : App<Windows>
{
    private Ft232h _expander = new Ft232h();
    private IDigitalOutputPort _c0;

    public static async Task Main(string[] args)
    {
        await CapsiumOS.Start(args);
    }

    public override Task Initialize()
    {
        Console.WriteLine("Creating Outputs");

        _c0 = _expander.CreateDigitalOutputPort(_expander.Pins.C0);

        while (true)
        {
            _c0.State = !_c0.State;
            Thread.Sleep(1);
        }

        return Task.CompletedTask;
    }

    public override async Task Run()
    {
    }
}