using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Foods.Class
{
    public static class AppSettingManager
    {
        private const string AppSettingLoc = "Setting\\AppSetting.json";
        private const string AppSettingRootKey = "Root";

        private static AppSetting _rootSetting;
        public static AppSetting RootSetting
        {
            get
            {
                if (_rootSetting == null || _rootSetting == new AppSetting())
                {
                    Init();
                }
                return _rootSetting;
            }
            set { _rootSetting = value; }
        }

        private static async void Init()
        {
            var path = Path.Combine(PathUtility.GetRootPath(), AppSettingLoc);

            if(!File.Exists(path)) return;
            var appSettings = JsonUtility.Deserialize<List<AppSetting>>(path);
            RootSetting = appSettings.FirstOrDefault(p => p.Key == AppSettingRootKey);
        }
    }
}
