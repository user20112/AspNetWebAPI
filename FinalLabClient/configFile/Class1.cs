using System.Configuration;//all starter code only thing i did was delete some uneeeded usings.

namespace configFile
{
    public class configurationFile
    {
        public static string getSetting(string key)
        {
            ConfigurationManager.AppSettings[key] = "c:\\zing\\authors.txt";
            ConfigurationManager.AppSettings["pubsDBConnectionString"] = "Integrated Security=true;Initial Catalog=pubs;Data Source=(local);";
            ConfigurationManager.AppSettings["masterDBConnectionString"] = "Integrated Security=true;Initial Catalog=master;Data Source=(local);";
            ConfigurationManager.AppSettings["apiRoot"] = "http://64.72.1.255/API/API/";

               // adapted from: 
               // https://msdn.microsoft.com/en-us/library/system.configuration.configurationmanager.appsettings(v=vs.110).aspx
               // see app.config file for how to add the setting

               string setting = "";

            try
            {

                var appSettings = ConfigurationManager.AppSettings;
                setting = appSettings[key] ?? "Not Found"; // if appSettings[key] != null, then appSettings[key], else "Not found"
            }
            catch (ConfigurationErrorsException)
            {
                setting = "ERROR: Not Found";
            }

            return setting;
        }
    }
}
