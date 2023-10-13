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
}
