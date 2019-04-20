using PhotoReport.AppManage.IoC;
using PhotoReport.AppManage.Navigation;
using PhotoReport.AppManage.Settings;
using PhotoReport.ViewModels;
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
            var navigation = AppIocResolver.Resolve<INavigationService>();

            settings.TryAuthenticateUser();

            if (string.IsNullOrEmpty(settings.AuthAccessToken))
                navigation.NavigateToAsync<LoginViewModel>();
            else
                navigation.NavigateToAsync<PhotoListViewModel>();                      
        }
    }
}
