using SampleSchoolApp.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleSchoolApp.Services
{
    public class NavigationService : ICustomNavigationService
    {
        public void Configure(Page pageKey, Type pageType)
        {
            throw new NotImplementedException();
        }

        public Page GetCurrentPage()
        {
            return Application.Current.MainPage;
        }

        public async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public void Initialize(NavigationPage page)
        {
            throw new NotImplementedException();
        }

        public Task NavigateTo(Page pageKey, object parameter)
        {
            throw new NotImplementedException();
        }

        public async Task NavigateToAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public void PushAsync(NavigationPage navigationPage)
        {
            throw new NotImplementedException();
        }

        public async Task PushModayAsync(Page pageKey)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(pageKey);
        }
    }
}
