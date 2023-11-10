using System.Text;

namespace PH.ChangeLogs;

public static class ChangelogExtensions
{
    public static string ToMarkdown(this Changelog c)
    {
        if (null == c)
        {
            return String.Empty;
        }

        StringBuilder md = new StringBuilder();
        md.AppendFormat("# {0}{1}", c.Project.Name, Environment.NewLine);
        if (!string.IsNullOrWhiteSpace(c.Project.Description))
        {
            md.AppendLine("");
            md.AppendFormat("{0}{1}", c.Project.Description, Environment.NewLine);
        }

        md.AppendLine("");

        foreach (var change in c.Changes)
        {
            md.AppendFormat("## {0}{1}", change.Version.VersionNumber, Environment.NewLine);
            md.AppendLine("");
            md.AppendFormat("Release: **{0:yyyy-MM-dd}** ", change.Version.ReleaseDate);
            if(!string.IsNullOrWhiteSpace(change.Version.Commit))
            {
                md.AppendFormat(" - *Commit: **{0}***", change.Version.Short);
            }
            md.AppendLine("");
            
            if(null != change.Changes)
            {
                md.AppendLine("");
                foreach (var stringChange in change.Changes)
                {
                    if(!string.IsNullOrWhiteSpace(stringChange))
                    {
                        md.AppendFormat("- {0}{1}", stringChange.Replace("\n","").Replace("\r",""), Environment.NewLine);
                    }
                }
            }
        }
        
        return md.ToString();
    }
}