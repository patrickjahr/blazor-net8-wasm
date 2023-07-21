using System.Diagnostics;

namespace Pazor.Client;
public partial class MainLayout
{
    private bool _isInitializing = true;

    protected override void OnAfterRender(bool firstRender)
    {
        if (_isInitializing)
        {
            _isInitializing = false;
            StateHasChanged();
        }
        base.OnAfterRender(firstRender);
    }
}
