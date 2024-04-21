namespace UnoDrive.Services;

public class AppState
{
    private bool _isInitialized;
    
    public event Action? OnChange;
    
    public string PageTitle { get; private set; } = string.Empty;
    
    public void Initialize()
    {
        if (!_isInitialized)
        {
            _isInitialized = true;
        }

        OnChange?.Invoke();
    }

    public void PageTitleSet(string value)
    {
        if (PageTitle == value) return;
        PageTitle = value;
        OnChange?.Invoke();
    }
}