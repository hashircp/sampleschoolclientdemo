using SampleSchoolApp.Controllers;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleSchoolApp.ViewModels
{
  public class LoginPageViewModel :ViewModelBase
    {
        private readonly Helpers.Interfaces.ICustomNavigationService _navigationService = null;

        #region "Constructor"
        public LoginPageViewModel(SampleSchoolApp.Services.NavigationService navigationService)
        {
            _navigationService = navigationService;
            IsErrorMsgDisplay = false;
            DisplayErrorContentValue = 0;
            IsLoginBtnEnable = false;
            IsRememberMe = false;
        }
        #endregion

        #region "Properties"


        public bool IsErrorMsgDisplay
        {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }
      
        public bool IsLoginBtnEnable
        {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }

        public bool IsLoading
        {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }
        public string ConnectivityLabel
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string UserName
        {
            get { return GetValue<string>(); }
            set
            {
                if (IsErrorMsgDisplay)
                    DisplayErrorContentValue = 0;
                IsErrorMsgDisplay = false;
                SetValue(value);
                IsLoginBtnEnable = false;

                if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(Password))
                {
                    IsLoginBtnEnable = true;
                }
            }
        }

        public string Password
        {
            get { return GetValue<string>(); }
            set
            {
                if (IsErrorMsgDisplay)
                    DisplayErrorContentValue = 0;
                IsErrorMsgDisplay = false;
                SetValue(value);
                IsLoginBtnEnable = false;
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(UserName))
                {
                    IsLoginBtnEnable = true;
                }
            }
        }
       
        public double DisplayErrorContentValue
        {
            get { return GetValue<double>(); }
            set { SetValue(value); }
        }
        public bool IsRememberMe
        {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }
        
        public string Error
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(UserLogin);
            }
        }

        #endregion

        #region "Methods"
        public async void UserLogin()
        {
            try
            {
                LoginController loginController = new LoginController();
                IsErrorMsgDisplay = false;
                IsLoginBtnEnable = false;

                   if (string.IsNullOrEmpty(UserName))
                    {
                       IsErrorMsgDisplay = true;
                        Error = "Check your Username!!";
                    }
                    else if (string.IsNullOrEmpty(Password))
                    {
                        IsErrorMsgDisplay = true;
                        Error = "Check your Password!!";
                    }


                    if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
                    {

                        if (await loginController.CheckLoginDetails(UserName, Password, IsRememberMe))
                        {
                            if (IsRememberMe == true)
                            {
                                UserName = UserName;
                            }
                        IsErrorMsgDisplay = false;

                        var registrationpage = new Views.SchoolRegistrationPage();
                        registrationpage.Title = "RegistrationPage";
                        await _navigationService.NavigateToAsync(registrationpage);

                    }
                        else
                        {

                            IsRememberMe = false;
                            IsErrorMsgDisplay = true;
                            Error = "Please enter valid data!!";
                            DisplayErrorContentValue = 1;
                        }
                    }

                
            }
            catch (Exception ex)
            {
                

                IsErrorMsgDisplay = true;
                Error = "Username & Password are Not Matching!!";
                DisplayErrorContentValue = 1;
            }
            finally
            {
                IsLoginBtnEnable = true;
            }
        }

       

        #endregion
    }
}
