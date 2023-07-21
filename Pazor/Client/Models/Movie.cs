using System.Text.Json.Serialization;

namespace Pazor.Client.Models
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public record Dates(
        [property: JsonPropertyName("maximum")] string Maximum,
        [property: JsonPropertyName("minimum")] string Minimum
    );

    public record Movie(
        [property: JsonPropertyName("adult")] bool Adult,
        [property: JsonPropertyName("backdrop_path")] string BackdropPath,
        [property: JsonPropertyName("genre_ids")] IReadOnlyList<int> GenreIds,
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("original_language")] string OriginalLanguage,
        [property: JsonPropertyName("original_title")] string OriginalTitle,
        [property: JsonPropertyName("overview")] string Overview,
        [property: JsonPropertyName("popularity")] double Popularity,
        [property: JsonPropertyName("poster_path")] string PosterPath,
        [property: JsonPropertyName("release_date")] string ReleaseDate,
        [property: JsonPropertyName("title")] string Title,
        [property: JsonPropertyName("video")] bool Video,
        [property: JsonPropertyName("vote_average")] double VoteAverage,
        [property: JsonPropertyName("vote_count")] int VoteCount
    );

    public record Root(
        [property: JsonPropertyName("dates")] Dates Dates,
        [property: JsonPropertyName("page")] int Page,
        [property: JsonPropertyName("results")] IReadOnlyList<Movie> Results,
        [property: JsonPropertyName("total_pages")] int TotalPages,
        [property: JsonPropertyName("total_results")] int TotalResults
    );
}
