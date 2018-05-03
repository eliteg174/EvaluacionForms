using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EvaluacionForms.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page3 : ContentPage
	{    
        public Page3(MovieModel moviesP)
        {
            InitializeComponent();

            Title = moviesP.title;

            this.lblName.Text = "";
            this.lblDescripcion.Text = "";
            this.lblCategory.Text = "";
            this.lblRating.Text = "";

            this.lblName.Text = "Title: \n" + moviesP.title;
            this.lblDescripcion.Text = "Description: \n" + moviesP.description;
            this.lblCategory.Text = "Category: \n" + moviesP.category;
            this.lblRating.Text = "Rating: \n" + moviesP.rating;
            this.imgImage.Source = moviesP.image;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            Navigation.PopAsync();
        }
	}
}