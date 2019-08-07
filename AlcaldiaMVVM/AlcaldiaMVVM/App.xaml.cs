using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//IMPORTAMOS 
using AlcaldiaMVVM.View;
namespace AlcaldiaMVVM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new GuardarContribuyente());
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
