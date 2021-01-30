using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class AppSettingTool
    {
        /// <summary>
        /// 获取functionid
        /// </summary>
        /// <returns></returns>
        public static int GetFunctionId()
        {
            var value = ConfigurationSettings.AppSettings["functionid"];
            if (string.IsNullOrEmpty(value))
            {
                value = "0";
            }
            return int.Parse(value);
        }


        /// <summary>
        /// 设置功能的id
        /// </summary>
        /// <param name="value"></param>
        public static void SetFunctionId(int value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["functionid"].Value = value + "";
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
