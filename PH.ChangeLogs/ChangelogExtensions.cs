using System.Reflection;
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

                    if (change.Version.Tags != null && change.Version.Tags.Any())
                    {
                        md.AppendLine("");
                        md.Append("Tags: ");

                        var tggs = string.Join(" | ", change.Version.Tags.Select(x => $"***{x}***").ToArray());
                        md.AppendFormat("{0}{1}", tggs, Environment.NewLine);
                    }
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

        md.AppendLine("#### Disclaimer");
        md.AppendLine();
        md.AppendFormat("> This document was automatically generated on `{0:u}` using PH.ChangeLogs [https://github.com/paonath/PH.ChangeLogs](https://github.com/paonath/PH.ChangeLogs){1}"
                        , DateTime.UtcNow, Environment.NewLine);
        md.AppendLine("> ");
        md.AppendLine("> The SourceRevisionId of the current assembly may differ from the version written by the authors in the changelog.");

        

        md.AppendLine();

        return md.ToString().TrimEnd();
    }

    public static string ToMarkdownWithAssemblyInfo(this Changelog changelog, Assembly assembly) =>
        ToMarkdownWithAssemblyInfoPrivate(changelog, assembly);

    public static string ToMarkdownWithAssemblyInfo(this Assembly assembly, Changelog changelogForAssembly) =>
        ToMarkdownWithAssemblyInfoPrivate(changelogForAssembly, assembly);



    internal static string ToMarkdownWithAssemblyInfoPrivate(Changelog changelog, Assembly assembly)
    {
        var           md0 = changelog.ToMarkdown();
        StringBuilder md = new StringBuilder();
        md.AppendLine(md0);
        
        md.AppendLine("");
        md.AppendLine("# Assembly Info");
        md.AppendLine("");
        md.AppendLine("| Property | Value |");
        md.AppendLine("| ---- | ---- |");

        md.AppendFormat("| {0} | {1} |{2}"
                        , nameof(assembly.FullName), assembly.FullName, Environment.NewLine);

        md.AppendFormat("| {0} | {1} |{2}"
                        , "Assembly Name Version", assembly.GetName().Version, Environment.NewLine);

        var informationalVersion = assembly
           .GetCustomAttribute<AssemblyInformationalVersionAttribute>();
        if (informationalVersion != null)
        {
            md.AppendFormat("| {0} | {1} |{2}"
                            , nameof(AssemblyInformationalVersionAttribute.InformationalVersion),
                            informationalVersion.InformationalVersion, Environment.NewLine);
        }

        md.AppendFormat("| {0} | {1} |{2}"
                        , "Environment Version", Environment.Version, Environment.NewLine);

        bool debug = false;
        #if DEBUG
        debug = true;
        #endif

        md.AppendFormat("| {0} | {1} |{2}"
                        , "Debug", debug, Environment.NewLine);



        return md.ToString();
    }
}