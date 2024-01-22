using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DangerousObjects.MVC.Helpers.Extensions;

public static class StringExtensions
{
    public static bool IsJson(this string str)
    {
        try
        {
            JToken.Parse(str);
            return true;
        }
        catch (JsonReaderException)
        {
            return false;
        }
    }
}