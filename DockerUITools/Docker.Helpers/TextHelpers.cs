namespace Docker.Helpers;

public static class TextHelpers
{
    public static IEnumerable<string> SplitToRows(this string inputText) 
        => inputText.Split('\n').Where(x => !string.IsNullOrEmpty(x));
}
