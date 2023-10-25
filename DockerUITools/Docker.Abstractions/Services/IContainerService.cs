using Docker.Models;

namespace Docker.Abstractions.Services;

public interface IContainerService
{
    public Task GetContainersAsync(IProgress<IEnumerable<Container>> progress);

    public Task StartContainerAsync(IProgress<CommandResult> progress, string containerId);

    public Task RestartContainerAsync(IProgress<CommandResult> progress, string containerId);

    public Task StopContainerAsync(IProgress<CommandResult> progress, string containerId);

    public Task PauseContainerAsync(IProgress<CommandResult> progress, string containerId);

    public Task UnPauseContainerAsync(IProgress<CommandResult> progress, string containerId);

    public Task DeleteContainerAsync(IProgress<CommandResult> progress, string containerId);

    public Task GetContainerLogsAsync(IProgress<string> progress, string containerId);
}
