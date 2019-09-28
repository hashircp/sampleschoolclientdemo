using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleSchoolApp.Helpers.Interfaces
{
   public interface ICustomNavigationService
    {
        Task GoBack();
        Task NavigateToAsync(Page page);
        Task NavigateTo(Page pageKey, object parameter);
        Task PushModayAsync(Page pageKey);
        Page GetCurrentPage();
        void Configure(Page pageKey, Type pageType);
        void Initialize(NavigationPage page);
        void PushAsync(NavigationPage navigationPage);
    }
}
