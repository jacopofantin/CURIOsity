using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Owin.Hosting;

namespace Hallbridger
{
    internal static class HallbridgerProgram
    {
        private static IDisposable _webServer;

        [STAThread]
        static void Main()
        {
            string apiBaseUrl = "http://localhost:44307"; // default API URL
            string iniPath = Path.Combine(Application.StartupPath, "Configuration", "conf.ini");

            // read API URL from INI file if it exists
            if (File.Exists(iniPath))
            {
                var iniFile = new IniFile(iniPath);
                string savedApiUrl = iniFile.Read("API", "BaseUrl");
                if (!string.IsNullOrWhiteSpace(savedApiUrl))
                {
                    apiBaseUrl = savedApiUrl;
                }
            }

            // start the self-hosted web server
            try 
            {
                _webServer = WebApp.Start<Startup>(apiBaseUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to start the web server: {ex.Message}", "API server error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HallbridgerForm());

            // stop the web server when the application exits
            _webServer.Dispose();
        }
    }
}
