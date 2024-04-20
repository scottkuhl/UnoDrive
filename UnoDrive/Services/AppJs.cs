using System.Diagnostics.CodeAnalysis;
using Microsoft.JSInterop;

namespace UnoDrive.Services;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public enum OperatingSystemType
{
    Android, ChromeOS, iOS, iPadOS, Linux, MacOS, Windows, Other
}

public class AppJs(IJSRuntime js)
{
    private async Task<string> OperatingSystemAsync(CancellationToken cancellationToken)
    {
        return await js.InvokeAsync<string>("os", cancellationToken: cancellationToken);
    }
    
    public async Task<string> ThemeAsync(CancellationToken cancellationToken)
    {
        var os = await OperatingSystemAsync(cancellationToken);
        if (Enum.TryParse(os, out OperatingSystemType type))
        {
            return type switch
            {
                OperatingSystemType.Android or OperatingSystemType.ChromeOS or OperatingSystemType.Linux
                    or OperatingSystemType.Other => "material",
                OperatingSystemType.iOS or OperatingSystemType.iPadOS or OperatingSystemType.MacOS => "cupertino",
                OperatingSystemType.Windows => "fluent",
                _ => "material"
            };
        }

        return "material";
    }
}