using System.Text;

namespace PH.ChangeLogs;

public static class ChangelogExtensions
{
    public static string BuildSourceRevisionId(this Changelog changelog)
    {
        var last = changelog.Changes?.OrderByDescending(x => x.Version.ReleaseDate)
                            .ThenByDescending(c => c.Version.SemanticVersion).FirstOrDefault();
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

       

        if (null != changelog.Changes)
        {
            foreach (var change in changelog.Changes)
            {
                md.AppendLine("");
                md.AppendFormat("## {0}{1}", change.Version.SemanticVersion, Environment.NewLine);
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

        if (null != changelog.Authors)
        {
            md.AppendLine("");
            md.AppendLine("### Authors ");
            md.AppendLine("");
            foreach (var author in changelog.Authors)
            {
                md.AppendFormat("- {0}", author.FullName);
                if (!string.IsNullOrWhiteSpace(author.Email))
                {
                    md.AppendFormat(" [{0}]", author.Email);
                }

                md.AppendFormat("{0}", Environment.NewLine);
            }

            md.AppendLine("");
        }

        
        /*
         This document was automatically generated on 11/12/2019 using PH.ChangeLogs (www.google.com).
           
           The SourceRevisionId of the current assembly may differ from the version written by the authors in the changelog.
         */
        md.AppendLine("#### Disclaimer");
        md.AppendLine();
        md.AppendFormat("> This document was automatically generated on `{0:u}` using PH.ChangeLogs [https://github.com/paonath/PH.ChangeLogs](https://github.com/paonath/PH.ChangeLogs){1}"
                        , DateTime.UtcNow, Environment.NewLine);
        md.AppendLine("> ");
        md.AppendLine("> The SourceRevisionId of the current assembly may differ from the version written by the authors in the changelog.");
        md.AppendLine();

        return md.ToString().TrimEnd();
    }
}