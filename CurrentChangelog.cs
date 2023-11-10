namespace PH.ChangeLogs;


public static class CurrentChangelog
{
    public static Changelog Changelog
        => new Changelog(new Project("PH.ChangeLogs","c-sharp utility for tracking changes and releases of a project")
            , new Change[]
            {
                new Change(new Version("0.0.1-alpha", new DateOnly(2023,11,10),"b8b9e9714d8d7fb1be68226210de76b08f9f59c5")
                    , "First draft"
                    , new []
                    {
                        "preparing c# records" ,
                        "adding some documentation on file README.md",
                        "fix some warning on generated md"
                    })
                
                
            });
}