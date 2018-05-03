using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EvaluacionForms
{
	public partial class MainPage : ContentPage
	{
        public MainPage()
		{
            InitializeComponent();

            this.btnLogin.Clicked += (sender, e) =>
            {
                LoginService.Login(user =>
                {
                    var rootPage = Navigation.NavigationStack.FirstOrDefault();

                    if (rootPage != null)
                    {
                        App.isLoged = true;

                        Navigation.InsertPageBefore(new Page2(user._Kmd.authtoken), Navigation.NavigationStack.First());

                        Navigation.PopToRootAsync();
                    }
                },
                async () =>
                {
                    await DisplayAlert("Error", "Username or Password are not correct", "OK");
                    this.entAcc.Text = string.Empty;
                    this.entPass.Text = string.Empty;
                },
                this.entAcc.Text, this.entPass.Text 
              );
            };

            this.btnRegister.Clicked += async (sender, e) =>
            {
                await this.Navigation.PushAsync(new Page1());
            };
		}
	}
}
