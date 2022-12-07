using MovieTime.Services;

namespace MovieTime.ViewModel
{
    public partial class MoviesViewModel : BaseViewModel
    {
        MovieService _movieService;
        public ObservableCollection<Movie> Movies { get; set; } = new();
        public MoviesViewModel(MovieService movieService)
        {
            Title = "MovieTime";
            _movieService = movieService;
        } 

        [RelayCommand]
        async Task GetMoviesAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                var movies = await _movieService.GetMovies();

                if (Movies.Count != 0)
                    Movies.Clear();

                foreach (var movie in movies)
                {
                    Movies.Add(movie);
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error", $"Unable to get movies: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}