using System;

namespace DefaultBrowserFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            BrowserFinder browser = new BrowserFinder();
            Console.WriteLine(browser.GetSystemDefaultBrowser());
        }
    }
}
