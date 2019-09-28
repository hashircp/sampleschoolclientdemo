using System;
using FluentValidation;
using SampleSchoolApp.Helpers;
using SampleSchoolApp.Models;
using SampleSchoolApp.Services;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleSchoolApp.ViewModels
{
   public class SchoolViewModel :ViewModelBase
    {
        string _schoolName;
        string _phoneNumber;
        string _email;
        string _address;
        string _medium;
        readonly IValidator _validator;
        private readonly ISchoolService _schoolService;

        #region "Constructor"
        public SchoolViewModel(ISchoolService schoolService)
        {
            _validator = new ValidationPage();
            RegisterCommand = new Command(RegisterValidation);
            _schoolService = schoolService;// new SchoolService();
            GetSchoolsDetails();
        }
        #endregion

        #region "Interfaces"
        public ICommand RegisterCommand { get; set; }
        public IEnumerable School { get; set; }
        #endregion

        #region "Methods"
        void ValidateSchoolInfo()
        {
            var schoolObj = new SchoolModel
            {
                SchoolName = SchoolName,
                Address = Address,
                PhoneNumber = PhoneNumber,             
                Email = Email,               
            };
            var validationResults = _validator.Validate(schoolObj);

            if (validationResults.IsValid)
            {
                App.Current.MainPage.DisplayAlert("FluentValidation", "Validation Success..!!", "Ok");
            }
            else
            {
                App.Current.MainPage.DisplayAlert("FluentValidation", validationResults.Errors[0].ErrorMessage, "Ok");
            }
        }

        public void GetSchoolsDetails()
        {
            School = _schoolService.GetSchools();
        }

        void RegisterValidation()
        {
            var schoolObj = new SchoolModel
            {
                SchoolName = SchoolName,
                Address = Address,
                PhoneNumber = PhoneNumber,               
                Email = Email          
            };
            var validationResults = _validator.Validate(schoolObj);

            if (validationResults.IsValid)
            {
                App.Current.MainPage.DisplayAlert("FluentValidation", "Validation Success..!!", "Ok");
            }
            else
            {
                App.Current.MainPage.DisplayAlert("FluentValidation", validationResults.Errors[0].ErrorMessage, "Ok");
            }
        }
#endregion

        #region "Properties"
        public string SchoolName
        {
            get { return _schoolName; }
            set { SetProperty(ref _schoolName, value); }
        }

        
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetProperty(ref _phoneNumber, value); }
        }

        
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        
        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }

        public string Medium
        {
            get { return _medium; }
            set { SetProperty(ref _medium, value); }
        }
        
        

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
            {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;
            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
            }
            }
    #endregion
}

