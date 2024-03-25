#region

using Semver;

#endregion

namespace PH.ChangeLogs
{
    public static class CurrentChangelog
    {
        public static Changelog Changelog
            => new(
                   new Project("PH.ChangeLogs",
                               "c-sharp utility for tracking changes and releases of a project. Useful for generate changelogs on markdown")
                   , new Change[]
                   {
                       new(new Version(SemVersion.Parse("0.0.4", SemVersionStyles.Any),
                                       new DateOnly(2024, 3, 25), "",
                                       new[] { "v.0.0.4" })
                           , "Fix Format changes on md", new[]
                           {
                               "tags should be not empty string",
                               """
                               fix newLine problems and indentation:
                               
                               ```
                                  this line should be indented correctly
                               ```
                               """
                               
                           }),
                       
                       new(new Version(SemVersion.Parse("0.0.3", SemVersionStyles.Any),
                                       new DateOnly(2023, 11, 14) , "5d7d6c74cb94be3d4f61c0108916b34919f3f791" , new []{ "v.0.0.3" }) 
                           , "Fix Missing Data on Markdown", new[]
                           {
                               "tags are now visible on changelog.md",
                               "fix some text issue"
                           }),
                       
                       new(new Version(SemVersion.Parse("0.0.2", SemVersionStyles.Any),
                                       new DateOnly(2023, 11, 14) , "d3fdee189bbdc696ee6ecc9f26ded03d83101b7e" , new []{ "v.0.0.2" }) 
                           , "Add Assembly Info", new[]
                           {
                               "some info on generating changelog.md"
                           }),
                       new(new Version(SemVersion.Parse("0.0.2-alpha2", SemVersionStyles.Strict),
                                       new DateOnly(2023, 11, 14), "c39c3a03baf950eda9ad692deff9dea9fe6348bb",
                                       new[] { "v.0.0.2-alpha2" })
                           , "Introduced SemVer", new[]
                           {
                               "added Author array to Changelog",
                               "reformat MarkDown generated",
                               "add package 'SemVer' from Nuget (https://github.com/maxhauser/semver)"
                           }),
                       new(new Version(SemVersion.Parse("0.0.1", SemVersionStyles.Any), new DateOnly(2023, 11, 10), "4b60c2976f7b1b5a5a2867e4ce0f5bf01ec81d88", new[] { "v.0.0.1" }),
                           "Publish Package", new[]
                           {
                               "publish package 0.0.1",
                               "added source link to github"
                           }),
                       new(new Version(SemVersion.Parse("0.0.1-beta", SemVersionStyles.Any), new DateOnly(2023, 11, 10)),
                           "Prepare package for nuget"
                           , new[]
                           {
                               "preparing package structure (cfr. .csproj file)"
                           }),
                       new(new Version(SemVersion.Parse("0.0.1-alpha", SemVersionStyles.Any),
                                       new DateOnly(2023, 11, 10),
                                       "85b313f75c5c8a9bbcc70d87a1c888c19c36da41")
                           , "First draft"
                           , new[]
                           {
                               "preparing c# records",
                               "adding some documentation on file README.md",
                               "fix some warning on generated md"
                           })
                   }, new[] { new Author("Paolo Innocenti", "paonath@gmail.com") });
    }
}