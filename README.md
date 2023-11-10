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
        new Change(new Version("0.0.1-alpha", new DateOnly(2023,11,10),"")
        , "First draft"
        , new []
        {
            "Preparing c# records"
        }),


    });
}
```