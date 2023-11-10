using System.Text;

namespace PH.ChangeLogs;

public static class ChangelogExtensions
{
    public static string BuildSourceRevisionId(this Changelog changelog)
    {
        var last = changelog.Changes?.LastOrDefault();
        if (null == last)
        {
            throw new ArgumentNullException(nameof(changelog), "Missing last change from changelog!");
        }

        return last.BuildSourceRevisionId();
    }

    public static string ToMarkdown(this Changelog changelog)
    {

        StringBuilder md = new StringBuilder();
        md.AppendFormat("# {0}{1}", changelog.Project.Name, Environment.NewLine);
        if (!string.IsNullOrWhiteSpace(changelog.Project.Description))
        {
            md.AppendLine("");
            md.AppendFormat("{0}{1}", changelog.Project.Description, Environment.NewLine);
        }

        md.AppendLine("");

        if (null != changelog.Changes)
        {
            foreach (var change in changelog.Changes)
            {
                
                md.AppendFormat("## {0}{1}", change.Version.VersionNumber, Environment.NewLine);
                md.AppendLine("");
                md.AppendFormat("Release: **{0:yyyy-MM-dd}** ", change.Version.ReleaseDate);
                if (!string.IsNullOrWhiteSpace(change.Version.Commit))
                {
                    md.AppendFormat(" - *Commit: **{0}***", change.Version.Short);
                }

                md.AppendLine("");

                if (null != change.Changes)
                {
                    md.AppendLine("");
                    foreach (var stringChange in change.Changes)
                    {
                        if (!string.IsNullOrWhiteSpace(stringChange))
                        {
                            md.AppendFormat("- {0}{1}", stringChange.Replace("\n", "").Replace("\r", ""),
                                            Environment.NewLine);
                        }
                    }
                }
            }
        }
        
        
        return md.ToString();
    }
}