using Semver;

namespace PH.ChangeLogs;

public record Change(Version Version, string? TitleOrDescription, string?[]? Changes)
{
    internal string BuildSourceRevisionId()
    {
        var r = $"{Version.SemanticVersion}_{Version.ReleaseDate:yyyy-MM-dd}";
        if (!string.IsNullOrWhiteSpace(Version.Commit))
        {
            r = $"{r}_{Version.Short}";
        }

        return r;
    }
}

public record Version(SemVersion SemanticVersion, DateOnly ReleaseDate , string? Commit = "", string[]? Tags = null)
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

