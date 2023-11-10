namespace PH.ChangeLogs;

public record Change(Version Version, string? TitleOrDescription, string?[]? Changes)
{
    
}

public record Version(string VersionNumber, DateOnly ReleaseDate , string? Commit = "", string[]? Tags = null);

