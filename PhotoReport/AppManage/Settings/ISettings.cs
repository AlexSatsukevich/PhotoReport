namespace PhotoReport.AppManage.Settings
{
    public interface ISettings
    {
        string UserName { get; }
        string Pass { get; }
        string BaseUrl { get; }
    }
}
