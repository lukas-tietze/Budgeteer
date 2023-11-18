namespace Budgeteer.App.Config;

/// <summary>
/// Stellt die Anwendungskonfiguration dar.
/// </summary>
public class AppConfig
{
    /// <summary>
    /// Holt oder setzt die Konfiguration der Anwendungspfade.
    /// </summary>
    public PathConfig Paths { get; set; } = new();
}
