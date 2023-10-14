using Docker.Helpers;
using Docker.Models;

namespace Docker.Services;

public class ContainerServices
{
    public ContainerServices() { }

    public IEnumerable<Container> GetContainers()
    {
        var result = CommandRunner
            .RunCommand("docker", "ps -a --format json")
            .ToString()
            .SplitToRows();

        var jsonHelper = new JsonHelper<Container>();

        var containers = jsonHelper.ConvertTo(result);

        return containers;
    }

    public string StartContainer(string containerId)
        => CommandRunner
            .RunCommand("docker", $"start {containerId}")
            .ToString();

    public string RestartContainer(string containerId)
        => CommandRunner
            .RunCommand("docker", $"restart {containerId}")
            .ToString();

    public string StopContainer(string containerId)
        => CommandRunner
            .RunCommand("docker", $"stop {containerId}")
            .ToString();

    public string PauseContainer(string containerId)
        => CommandRunner
            .RunCommand("docker", $"pause {containerId}")
            .ToString();

    public string UnpauseContainer(string containerId)
        => CommandRunner
            .RunCommand("docker", $"unpause {containerId}")
            .ToString();

    public string DeleteContainer(string containerId)
    => CommandRunner
        .RunCommand("docker", $"rm {containerId}")
        .ToString();
}
