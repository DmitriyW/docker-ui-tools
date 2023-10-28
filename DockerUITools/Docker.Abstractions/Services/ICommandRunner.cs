namespace Docker.Abstractions.Services;

public interface ICommandRunner
{
    public string RunCommand(string appName, string args);
}
