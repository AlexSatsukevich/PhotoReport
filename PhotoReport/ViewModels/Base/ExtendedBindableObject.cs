using Xamarin.Forms;

namespace PhotoReport.ViewModels.Base
{
    public abstract class ExtendedBindableObject : BindableObject
    {
        // ReSharper disable once RedundantAssignment
        protected void Set<T>(string propName, ref T propValue, T newValue)
        {
            propValue = newValue;
            OnPropertyChanged(propName);
        }
    }
}