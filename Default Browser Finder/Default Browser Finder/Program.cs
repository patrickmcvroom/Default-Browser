using System;
using Microsoft.Win32;

namespace DefaultBrowserFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            const string userChoice = @"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice";
            string progId;
            string browser;

            using RegistryKey userChoiceKey = Registry.CurrentUser.OpenSubKey(userChoice);
            if (userChoiceKey == null)
            {
                browser = "Unknown";
                //break;
            }
            object progIdValue = userChoiceKey.GetValue("Progid");
            if (progIdValue == null)
            {
                browser = "Unknown";
                //break;
            }
            progId = progIdValue.ToString();
            switch (progId)
            {
                case "IE.HTTP":
                    browser = "Internet Explorer";
                    break;
                case "FirefoxURL":
                    browser = "Mozilla Firefox";
                    break;
                case "ChromeHTML":
                    browser = "Google Chrome";
                    break;
                case "OperaStable":
                    browser = "Opera";
                    break;
                case "SafariHTML":
                    browser = "Safari";
                    break;
                case "AppXq0fevzme2pys62n3e0fbqa7peapykr8v":
                    browser = "Microsoft Edge";
                    break;
                default:
                    browser = "Unknown";
                    break;
            }
            Console.WriteLine("Your default browser is: " + browser);
        }
    }
}
