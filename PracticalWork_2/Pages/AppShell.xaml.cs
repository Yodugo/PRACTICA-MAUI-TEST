using System;
using Microsoft.Maui.Controls;

namespace PracticalWork_2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("LoginPage", typeof(Pages.LoginPage));
            Routing.RegisterRoute("RegisterPage", typeof(Pages.RegisterPage));
            Routing.RegisterRoute("RecoverPasswordPage", typeof(Pages.RecoverPasswordPage));
            Routing.RegisterRoute("MainPage", typeof(Pages.MainPage));
            Routing.RegisterRoute("UserInfoPage", typeof(Pages.UserInfoPage));
        }
    }
}
