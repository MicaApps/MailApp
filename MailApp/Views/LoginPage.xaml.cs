﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using MailApp.Services;
using MailApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MailApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        private readonly NavigationService _navigationService;

        public LoginPage()
        {
            var services = App.Host.Services;
            _navigationService = services.GetRequiredService<NavigationService>();

            DataContext = this;
            ViewModel = services.GetRequiredService<LoginPageViewModel>();

            this.InitializeComponent();

        }

        public LoginPageViewModel ViewModel { get; }

        public void OnLoginCompleted()
        {
            _navigationService.NavigateToMainPage();
        }
    }
}
