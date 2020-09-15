using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using tillsammans.mobile.Services;
using tillsammans.mobile.Views;
using System.Runtime.CompilerServices;
using tillsammans.Mocks;

namespace tillsammans.mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            registerServices();
            setRootPage();
        }

        private void setRootPage()
        {
            MainPage = new NavigationPage(new SignInPage());
        }

        
        private static bool MockServices { get => false; }

        private void registerServices()
        {
            
            if (MockServices)
            {
                DependencyService.Register<AppServiceMock>();
                DependencyService.Register<AuthServiceMock>();  
            }
            else
            {
                DependencyService.Register<AppService>();
                DependencyService.Register<AuthService>();
            }

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
