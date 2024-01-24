using DangerousObjectsCommon.Enums;

namespace DangerousObjectsBLL.Extensions;

public static class StringExtensions
{
    public static ObjType ConvertToObjType(this string source)
    {
        bool parsed = Enum.TryParse(source, out ObjType objType);
        if (!parsed)
            throw new Exception("Type not found");
        return objType;
    }
    
    public static Importance ConvertToImportance(this string source)
    {
        bool parsed = Enum.TryParse(source, out Importance importance);
        if (!parsed)
            throw new Exception("Importance not found");
        return importance;
    }
}