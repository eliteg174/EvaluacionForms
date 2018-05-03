using EvaluacionForms.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EvaluacionForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public String Token;

        public Page2(String token)
        {
            InitializeComponent();

            Token = token;

            this.lvLista.ItemTapped += (object sender, ItemTappedEventArgs e) =>
            {
                MovieModel movieP = e.Item as MovieModel;
                Navigation.PushAsync(new Page3(movieP));
            };
        }

        void ItemTapped()
        {
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var adapter = new ObservableCollection<MovieModel>();

            MoviesService.GetMovies((movies) =>
            {
                foreach (MovieModel movie in movies)
                {
                    adapter.Add(new MovieModel(movie.title, movie.category, movie.description, movie.rating, movie.image));

                    this.lvLista.ItemsSource = adapter;

                    this.lvLista.RowHeight = 55;
                }
            },
                () =>
                {
                    DisplayAlert("Error", "Ocurrió un error al consumir el servicio Web", "Ok");
                },
                Token
            );
        }
    }
}