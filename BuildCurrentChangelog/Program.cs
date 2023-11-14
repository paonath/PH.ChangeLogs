// See https://aka.ms/new-console-template for more information

using PH.ChangeLogs;

var md = PH.ChangeLogs.CurrentChangelog.Changelog.ToMarkdown();
await System.IO.File.WriteAllTextAsync(@"../../../../PH.ChangeLogs/changelog.md", md);
