
using System.Diagnostics;

namespace HPACodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var tst = new ProcessStartInfo(@"C:\Program Files\internet explorer\iexplore.exe");
            tst.Arguments = "http://hpadevtest.azurewebsites.net/";
            Process.Start(tst);
        }
    }
}
