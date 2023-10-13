using System.Text.Json;

namespace Docker.Helpers
{
    public class JsonHelper<T>
    {
        public IEnumerable<T> ConvertTo(IEnumerable<string> inputArray)
            => JsonSerializer.Deserialize<IList<T>>($"[{string.Join(",", inputArray)}]").ToList();
    }
}
