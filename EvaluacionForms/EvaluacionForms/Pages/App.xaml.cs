using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace EvaluacionForms
{
	public partial class App : Application
	{
        public static bool isLoged = false;
        string Token;

        public App()
        {
            InitializeComponent();

            Token = LoginService.GetToken();

            if(isLoged)
                MainPage = new NavigationPage(new Page2(Token));
            else
                MainPage = new NavigationPage(new MainPage());
        }      

        /*public App(string databaseLocation)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            DatabaseLocation = databaseLocation;
        }*/

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
