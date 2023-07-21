using Microsoft.AspNetCore.Components;

namespace Pazor.Client.Pages;
public partial class Dashboard
{
    [Inject] private NavigationManager _navigationManager { get; set; } = default!;

    private void NavigateTo(string topic)
    {
        _navigationManager.NavigateTo($"/movies/{topic}");
    }
}
