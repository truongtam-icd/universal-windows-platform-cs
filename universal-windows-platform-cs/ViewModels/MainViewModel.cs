﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using PassportLogin.AuthService;
using PassportLogin.Utils;
using universal_windows_platform_cs.Core.Services;
using universal_windows_platform_cs.Services;
using universal_windows_platform_cs.Views;

namespace universal_windows_platform_cs.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private UserAccount _account;
        private bool _isExistingAccount;
        public ICommand MainViewCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        private string _errorMessage = "";
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                SetProperty(ref _errorMessage, value);
            }
        }

        public MainViewModel()
        {
            MainViewCommand = new RelayCommand(DebugCommand);
            LoginCommand = new RelayCommand(LoginAsync);
            LogoutCommand = new RelayCommand(Logout);
        }

        public async Task LoadDataAsync()
        {
            await DataSourceService.TestConnection();
        }

        private void DebugCommand()
        {
            Debug.WriteLine($"DebugCommand");
        }

        private async void LoginAsync()
        {
            List<UserAccount> accounts = AuthService.Instance.GetUserAccountsForDevice(AuthHelper.GetDeviceId());

            if (!accounts.Any())
            {
                AuthService.Instance.Register("admin", "admin");
                if (AuthService.Instance.ValidateCredentials("admin", "admin"))
                {
                    Guid userId = AuthService.Instance.GetUserId("admin");

                    if (userId != Guid.Empty)
                    {
                        //Now that the account exists on server try and create the necessary passport details and add them to the account
                        bool isSuccessful = await MicrosoftPassportHelper.CreatePassportKeyAsync(userId, "admin");
                        if (isSuccessful)
                        {
                            Debug.WriteLine("Successfully signed in with Windows Hello!");
                            //Navigate to the Welcome Screen. 
                            _account = AuthService.Instance.GetUserAccount(userId);
                            NavigationService.Navigate<CompanyListPage>();
                        }
                        else
                        {
                            //The passport account creation failed.
                            //Remove the account from the server as passport details were not configured
                            AuthService.Instance.PassportRemoveUser(userId);

                            ErrorMessage = "Account Creation Failed";
                        }
                    }
                }
                else
                {
                    ErrorMessage = "Invalid Credentials";
                }
            }
            else
            {
                NavigationService.Navigate<CompanyListPage>();
            }
        }

        private void Logout()
        {
            List<UserAccount> accounts = AuthService.Instance.GetUserAccountsForDevice(AuthHelper.GetDeviceId());

            if (accounts.Any())
            {
                try
                {
                    AuthService.Instance.PassportRemoveUser(accounts.First().UserId);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"{ex.Message}");
                }
            }
        }
    }
}
