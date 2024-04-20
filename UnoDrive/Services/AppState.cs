namespace UnoDrive.Services;

public class AppState(AppJs appJs)
{
    private bool _isInitialized;
    
    public event Action? OnChange;
    
    public string Theme { get; private set; } = string.Empty;
    
    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        if (!_isInitialized)
        {
            Theme = await appJs.ThemeAsync(cancellationToken);
            _isInitialized = true;
        }

        OnChange?.Invoke();
    }
}