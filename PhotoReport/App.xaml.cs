using PhotoReport.AppManage.IoC;
using PhotoReport.AppManage.Settings;
using PhotoReport.Views;
using Xamarin.Forms;

namespace PhotoReport
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitApp();            
        }

        private void InitApp()
        {
            var settings = AppIocResolver.Resolve<ISettings>();            

            settings.TryAuthenticateUser();

            if (string.IsNullOrEmpty(settings.AuthAccessToken))
                MainPage = new NavigationPage(new LoginView());
            else
                MainPage = new NavigationPage(new PhotoListView());
        }                
    }
}
