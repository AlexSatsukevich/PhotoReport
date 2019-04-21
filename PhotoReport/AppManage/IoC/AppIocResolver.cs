using System;
using System.Globalization;
using System.Reflection;
using Autofac;
using PhotoReport.AppManage.Navigation;
using PhotoReport.AppManage.Settings;
using PhotoReport.ViewModels;
using Xamarin.Forms;

namespace PhotoReport.AppManage.IoC
{
    public static class AppIocResolver
    {
        private static readonly IContainer Container;

        static AppIocResolver()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<PhotoListViewModel>();

            builder.RegisterType<AppSettings>().As<ISettings>();
            builder.RegisterType<NavigationService>().As<INavigationService>();

            Container = builder.Build();
        }
        
        public static T Resolve<T>() where T : class
        {
            return Container.Resolve<T>();
        }

        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(AppIocResolver), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(AutoWireViewModelProperty, value);
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is Element view)) return;

            var viewType = view.GetType();

            var viewName = viewType.FullName?.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null) return;

            var viewModel = Container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}
