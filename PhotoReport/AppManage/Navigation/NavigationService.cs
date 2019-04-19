using System.Threading.Tasks;
using PhotoReport.ViewModels.Base;

namespace PhotoReport.AppManage.Navigation
{
    public class NavigationService : INavigationService
    {
        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            throw new System.NotImplementedException();
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            throw new System.NotImplementedException();
        }
    }
}