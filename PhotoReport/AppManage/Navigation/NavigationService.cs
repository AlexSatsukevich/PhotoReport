using System;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using PhotoReport.ViewModels.Base;
using Xamarin.Forms;

namespace PhotoReport.AppManage.Navigation
{
    public class NavigationService : INavigationService
    {
        public void SetRoot<TViewModel>() where TViewModel : ViewModelBase
        {
            var page = CreatePage(typeof(TViewModel), null);

            Application.Current.MainPage = new NavigationPage(page);
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        private static async Task InternalNavigateToAsync(Type vmType, object parameter)
        {
            var page = CreatePage(vmType, parameter);

            var mainPage = Application.Current.MainPage;
            await mainPage.Navigation.PushAsync(page);            
        }

        private static Page CreatePage(Type vmType, object parameter)
        {
            var pageType = GetPageTypeForViewModel(vmType);
            if (pageType == null)
                throw new Exception($"Cannot locate page type for {vmType}");

            var page = Activator.CreateInstance(pageType) as Page;
            return page;
        }

        private static Type GetPageTypeForViewModel(Type vmType)
        {
            var viewName = vmType.FullName?.Replace("Model", string.Empty);
            var viewModelAssemblyName = vmType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }        
    }
}