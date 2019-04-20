namespace PhotoReport.AppManage.Settings
{
    public interface ISettings
    {
        string AuthAccessToken { get; }
        string BaseUrl { get; }

        void TryAuthenticateUser();
    }
}
