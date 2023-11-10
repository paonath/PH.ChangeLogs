namespace PH.ChangeLogs;

public record Change(Version Version, string? TitleOrDescription, string?[]? Changes)
{
    
}

public record Version(string VersionNumber, DateOnly ReleaseDate , string? Commit = "", string[]? Tags = null)
{
    private string? GetShort()
    {
        if(string.IsNullOrWhiteSpace(Commit))
        {
            return String.Empty;
        }

        if(Commit.Length > 7)
        {
            return Commit.Substring(0,7);
        }

        return Commit;
    }
    public string? Short => GetShort();
}

