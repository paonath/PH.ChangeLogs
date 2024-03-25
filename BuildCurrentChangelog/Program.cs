// See https://aka.ms/new-console-template for more information

using PH.ChangeLogs;

var md    = PH.ChangeLogs.CurrentChangelog.Changelog.ToMarkdown();
var fPath = @".\changelog.md";
if (System.IO.File.Exists(fPath))
{
    System.IO.File.Delete(fPath);
}

await System.IO.File.WriteAllTextAsync(fPath, md);
Console.WriteLine("changelog write to {0}", fPath);
Console.WriteLine("Press a key to exit");
Console.ReadKey();
