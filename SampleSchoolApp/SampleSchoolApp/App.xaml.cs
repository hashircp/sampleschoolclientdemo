using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using SampleSchoolApp.Models;
using SampleSchoolApp.Services;
using SampleSchoolApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SampleSchoolApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

           var firstPage = new NavigationPage(new LoginPage());                    
            //Ioc Dependency Injection Using Unity
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<ISchoolService, SchoolService>();
            unityContainer.RegisterInstance(typeof(SchoolModel));//optional
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(unityContainer));
            MainPage = firstPage;
           
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
