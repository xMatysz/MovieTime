using MovieTime.Model;
using System.Collections.ObjectModel;
using MovieTime.Services;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;

namespace MovieTime.ViewModel
{
    public partial class MoviesViewModel : BaseViewModel
    {
        private MovieService movieService;
        public ObservableCollection<Movie> Movies { get; } = new();

        public MoviesViewModel(MovieService movieService)
        {
            Tittle = "Movie finder";
            this.movieService = movieService;
        }

        [RelayCommand]
        private async Task GetMovieAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var movieList = await movieService.GetMovies();

                if (Movies.Count != 0)
                    Movies.Clear();

                foreach (var movie in movieList)
                {
                    Movies.Add(movie);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get Movies{ex.Message}", "Ok");
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}