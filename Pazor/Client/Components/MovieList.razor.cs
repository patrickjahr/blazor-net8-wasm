using Microsoft.AspNetCore.Components;
using Pazor.Client.Models;
using Pazor.Client.Services;

namespace Pazor.Client.Components
{
    public partial class MovieList
    {
        [Inject] private TmdbService _tmdbService { get; set; } = default!;

        [Parameter, EditorRequired] public string Topic { get; set; } = TmdbService.NowPlaying;

        private IEnumerable<Movie> _nowPlaying = Enumerable.Empty<Movie>();

        protected override async Task OnInitializedAsync()
        {
            _nowPlaying = await _tmdbService.GetMovies(Topic);
            await base.OnInitializedAsync();
        }
    }
}