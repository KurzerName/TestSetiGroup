using System.Text;
using System.Text.Json;

namespace TestSetiGroup.JsonOptions;

public class JsonPascalCaseNamingPolicy: JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        if (string.IsNullOrEmpty(name) || !char.IsUpper(name[0]))
        {
            return name;
        }
        
        var strList = name.Split('_');
        
        return strList.Select(r => char.ToUpper(r[0]) + r.Substring(1)).Aggregate((a, b) => a + b);
    }
}