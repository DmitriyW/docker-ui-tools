namespace Docker.Models;

public class CommandResult
{
    public CommandResult(string id, string message)
    {
        this.ElementId = id;
        this.Message = message;
    }

    public string ElementId { get; }
    public string Message { get; }
}
