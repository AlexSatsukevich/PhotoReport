using System;
namespace PhotoReport.AppManage.Settings
{
    public class AppSettings: ISettings
    {
        public AppSettings()
        {
        }

        public string AuthAccessToken { get; private set; }

        public string BaseUrl { get; private set; }

        public void TryAuthenticateUser()
        {
            AuthAccessToken = null;
        }
    }
}
