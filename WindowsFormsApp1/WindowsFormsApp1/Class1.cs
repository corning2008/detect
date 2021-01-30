using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Class1
    {
        public void Test1()
        {
            var  value = System.Configuration.ConfigurationSettings.AppSettings["functionid"];
            Console.WriteLine(value);

            System.Configuration.ConfigurationSettings.AppSettings["functionid"] = "1";

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["functionid"].Value = "1";
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
