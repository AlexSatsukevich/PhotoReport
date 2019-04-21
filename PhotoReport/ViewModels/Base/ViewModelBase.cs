using PhotoReport.AppManage.IoC;
using PhotoReport.AppManage.Navigation;

namespace PhotoReport.ViewModels.Base
{
    public class ViewModelBase : ExtendedBindableObject
    {
        protected readonly INavigationService NavigationService;

        protected ViewModelBase()
        {
            NavigationService = AppIocResolver.Resolve<INavigationService>();
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => Set(nameof(IsBusy), ref _isBusy, value);
        }        
    }
}