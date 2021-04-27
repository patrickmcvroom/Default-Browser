using System;

namespace DefaultBrowserFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Press the SPACE BAR to find your default browser");

            BrowserFinder browser = new BrowserFinder();
            Console.WriteLine(browser.GetSystemDefaultBrowser());
        }
    }
}
