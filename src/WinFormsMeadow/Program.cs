using Capsium;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsCapsium
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();

            await CapsiumOS.Start(args);
        }
    }
}