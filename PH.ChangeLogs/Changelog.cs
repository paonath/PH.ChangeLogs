using System.Reflection;

namespace PH.ChangeLogs;


/*
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class)]
public class ChangeLogAttribute : Attribute
{
    private Changelog _changelog;

    public ChangeLogAttribute(Changelog current)
    {
        _changelog = current;
    }
    public ChangeLogAttribute(Assembly assembly,Func<Assembly, Changelog> currentChangelog) : this(currentChangelog.Invoke(assembly))
    {
        
    }
}


[ChangeLog(PH.ChangeLogs.CurrentChangelog.)]
*/
public record Changelog(Project Project, Change[]? Changes, Author[]? Authors = null)
{
    
}