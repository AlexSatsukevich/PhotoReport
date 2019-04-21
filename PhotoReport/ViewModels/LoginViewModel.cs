using Xamarin.Forms;
using PhotoReport.ViewModels.Base;
using System.Windows.Input;

namespace PhotoReport.ViewModels
{
    public class LoginViewModel:ViewModelBase
    {
        public LoginViewModel()
        {
        }

        public ICommand LoginCommand => new Command(() =>
        {
            NavigationService.SetRoot<PhotoListViewModel>();            
        });
    }
}
