using System.Threading.Tasks;
using PhotoReport.ViewModels.Base;

namespace PhotoReport.AppManage.Navigation
{
    public interface INavigationService
    {
        void SetRoot<TViewModel>() where TViewModel : ViewModelBase;
        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;
        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;
    }
}