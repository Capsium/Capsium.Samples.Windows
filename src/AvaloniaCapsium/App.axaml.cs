using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaCapsium.ViewModels;
using AvaloniaCapsium.Views;
using Capsium;
using Capsium.Foundation.Displays;
using Capsium.Foundation.Graphics;
using Capsium.Foundation.ICs.IOExpanders;
using Capsium.Peripherals.Displays;
using Capsium.UI;
using System.Threading.Tasks;

namespace AvaloniaCapsium
{
    public partial class App : AvaloniaCapsiumApplication<Windows>
    {
        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);

            LoadCapsiumOS();
        }

        public override Task CapsiumInitialize()
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