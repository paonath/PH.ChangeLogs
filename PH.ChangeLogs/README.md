# PH.ChangeLogs

c-sharp utility for tracking changes and releases of a project

## Code samples

```csharp
public static class CurrentChangelog
{
    public static Changelog Changelog
    => new Changelog(new Project("PH.ChangeLogs","c-sharp utility for tracking changes and releases of a project")
    , new Change[]
    {
        new(new Version(SemVersion.Parse("0.0.2", SemVersionStyles.Any),
           new DateOnly(2023, 11, 14) , "d3fdee189bbdc696ee6ecc9f26ded03d83101b7e" , new []{ "v.0.0.2" }) 
        , "Add Assembly Info", new[]
        {
            "some info on generating changelog.md"
        }),
        new Change(new Version("0.0.1-alpha", new DateOnly(2023,11,10),"")
        , "First draft"
        , new []
        {
            "Preparing c# records"
        }),


    });
}
```