using Docker.Helpers;
using Docker.Models;

namespace Docker.Services;

public class ContainerServices
{
    public ContainerServices() { }

    public async Task GetContainersAsync(IProgress<IEnumerable<Container>> progress)
    {
        await Task.Run(() =>
        {
            var result = CommandRunner
                .RunCommand("docker", "ps -a --format json")
                .ToString()
                .SplitToRows();

            var jsonHelper = new JsonHelper<Container>();
            var containers = jsonHelper.ConvertTo(result);
            progress.Report(containers);
        });
    }

    public async Task StartContainerAsync(IProgress<string> progress, string containerId)
        => await Task.Run(() =>
            {
                progress.Report(CommandRunner
                    .RunCommand("docker", $"start {containerId}")
                    .ToString());
            });

    public async Task RestartContainerAsync(IProgress<string> progress, string containerId)
        => await Task.Run(() =>
            {
                progress.Report(CommandRunner
                    .RunCommand("docker", $"restart {containerId}")
                    .ToString());
            });

    public async Task StopContainerAsync(IProgress<string> progress, string containerId)
        => await Task.Run(() =>
            {
                progress.Report(CommandRunner
                        .RunCommand("docker", $"stop {containerId}")
                        .ToString());
            });

    public async Task PauseContainerAsync(IProgress<string> progress, string containerId)
        => await Task.Run(() =>
            {
                progress.Report(CommandRunner
                        .RunCommand("docker", $"pause {containerId}")
                        .ToString());
            });

    public async Task UnpauseContainerAsync(IProgress<string> progress, string containerId)
        => await Task.Run(() =>
            {
                progress.Report(CommandRunner
                        .RunCommand("docker", $"unpause {containerId}")
                        .ToString());
            });

    public async Task DeleteContainerAsync(IProgress<string> progress, string containerId)
        => await Task.Run(() =>
            {
                progress.Report(CommandRunner
                        .RunCommand("docker", $"rm {containerId}")
                        .ToString());
            });
}
