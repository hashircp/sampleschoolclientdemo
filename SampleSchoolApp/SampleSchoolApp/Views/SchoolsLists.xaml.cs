using Microsoft.Practices.ServiceLocation;
using SampleSchoolApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleSchoolApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SchoolsLists : ContentPage
	{
		public SchoolsLists ()
		{
			InitializeComponent ();
            BindingContext = ServiceLocator.Current.GetInstance(typeof(SchoolViewModel));
        }
	}
}