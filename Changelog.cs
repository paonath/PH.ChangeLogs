namespace PH.ChangeLogs;

public record Changelog(Project Project, Change[]? Changes, Author[]? Authors = null)
{
    
}