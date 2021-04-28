using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace DefaultBrowserFinder
{
    class BrowserFinder
    {
        private string _browser = string.Empty;
        private RegistryKey regKey = null;

        internal string GetSystemDefaultBrowser()
        {
            try
            {
                //set the registry key we want to open
                regKey = Registry.ClassesRoot.OpenSubKey("HTTP\\shell\\open\\command", false);

                Console.WriteLine(regKey.GetValue(null).ToString().ToLower());

                //get rid of the enclosing quotes
                _browser = regKey.GetValue(null).ToString().ToLower().Replace("\"", "");

                Console.WriteLine(_browser);
                

                //check to see if the value ends with .exe (this way we can remove any command line arguments)
                if(!_browser.EndsWith("exe"))
                {
                    //get rid of all command line arguments (anything after the .exe must go)
                    _browser = _browser.Substring(0, _browser.LastIndexOf(".exe") + 4);

                    _browser = _browser.Substring(_browser.LastIndexOf("\\") + 1);
                }
            }
            catch (Exception exception)
            {
                _browser = string.Format("ERROR: An exception of type: {0} occurred in method: {1} in the following module: {2}", exception.GetType(), exception.TargetSite, this.GetType());
            }
            finally
            {
                //check and see if the key is still open, if so
                //then close it
                if (regKey != null)
                    regKey.Close();
            }
            //return the value
            return _browser;
        }
    }
}
