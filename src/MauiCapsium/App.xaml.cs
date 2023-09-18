using Capsium;
using Capsium.Foundation.Displays;
using Capsium.Foundation.Graphics;
using Capsium.Foundation.ICs.IOExpanders;
using Capsium.UI;

namespace MauiCapsium
{
    public partial class App : MauiCapsiumApplication<Capsium.Windows>
    {
        public App()
        {
            InitializeComponent();
            LoadCapsiumOS();

            CapsiumInitialize();

            MainPage = new AppShell();
        }

        protected Task CapsiumInitialize() 
        {
            var expander = new Ft232h();

            var display = new Gc9a01
            (
                spiBus: expander.CreateSpiBus(),
                chipSelectPin: expander.Pins.C0,
                dcPin: expander.Pins.C1,
                resetPin: expander.Pins.C2
            );

            Resolver.Services.Add<IGraphicsDisplay>(display);

            return Task.CompletedTask;
        }
    }
}