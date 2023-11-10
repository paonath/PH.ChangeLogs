namespace PH.ChangeLogs;


public static class CurrentChangelog
{
    public static Changelog Changelog
        => new Changelog(new Project("PH.ChangeLogs","c-sharp utility for tracking changes and releases of a project")
            , new Change[]
            {
                new Change(new Version("0.0.1", new DateOnly(2023,11,10),"4b60c2976f7b1b5a5a2867e4ce0f5bf01ec81d88", new []{"v.0.0.1"}),
                           "Publish Package", new []
                           {
                               "publish package 0.0.1",
                               "added source link to github"
                           }),
                new Change(new Version("0.0.1-beta", new DateOnly(2023,11,10),""), 
                           "Prepare package for nuget"
                           , new []
                           {
                               "preparing package structure (cfr. .csproj file)"
                           }),
                new Change(new Version("0.0.1-alpha", new DateOnly(2023,11,10),"85b313f75c5c8a9bbcc70d87a1c888c19c36da41")
                    , "First draft"
                    , new []
                    {
                        "preparing c# records" ,
                        "adding some documentation on file README.md",
                        "fix some warning on generated md"
                    })
                
                
            });
}