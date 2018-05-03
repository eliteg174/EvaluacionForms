using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EvaluacionForms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1 ()
		{
			InitializeComponent ();

            this.btnClear.Clicked += (sender, e) =>
            {
                entName.Text = string.Empty;
                entAccName.Text = string.Empty;
                entPhone.Text = string.Empty;
                entMail.Text = string.Empty;
                entPassword.Text = string.Empty;
            };

            this.btnContinue.Clicked += async (sender, e) =>
            {
                if (string.IsNullOrEmpty(this.entName.Text))
                    displayalert();
                else if (string.IsNullOrEmpty(this.entAccName.Text))
                    displayalert();
                else if (string.IsNullOrEmpty(this.entPhone.Text))
                    displayalert();
                else if (string.IsNullOrEmpty(this.entMail.Text))
                    displayalert();
                else if (string.IsNullOrEmpty(this.entPassword.Text))
                    displayalert();
                else if (this.entConfirmPassword.Text == this.entPassword.Text)
                {
                    RegisterService.Register(async user =>
                    {
                        {
                            var rootPage = Navigation.NavigationStack.FirstOrDefault();
                            if (rootPage != null)
                            {
                                //App.isLoged = true;

                                Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());

                                await Navigation.PopToRootAsync();
                            }
                        }                   
                    },
                () =>
                {
                    DisplayAlert("Error", "Some fields contain invalid data", "OK");
                },
                this.entAccName.Text,
                this.entPassword.Text,
                this.entName.Text,
                this.entPhone.Text,
                this.entMail.Text
                    );
                }
                else
                {
                    await DisplayAlert("Error", "Confirmation Password is different from Password", "OK");
                    this.entConfirmPassword.Text = string.Empty;
                }
            };

            async void displayalert()
            {
                await DisplayAlert("Error", "All fields must be filled", "OK");
            }
		}
	}
}