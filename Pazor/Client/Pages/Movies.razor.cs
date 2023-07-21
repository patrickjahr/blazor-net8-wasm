using Microsoft.AspNetCore.Components;
using Pazor.Client.Models;
using Pazor.Client.Services;

namespace Pazor.Client.Pages
{
    public partial class Movies
    {
        [Inject] private NavigationManager _navigationManager { get; set; } = default!;
        [Parameter] public string Topic { get; set; } = string.Empty;

        private void GoBack()
        {
            _navigationManager.NavigateTo("/");
        }
    }
}