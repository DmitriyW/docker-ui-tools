using Docker.Helpers;
using Docker.Models;
using Docker.Abstractions.Services;
using Docker.Constants;

namespace Docker.Services;

public class ContainerService : IContainerService
{
    private readonly ICommandRunner commandRunner;

    public ContainerService(ICommandRunner commandRunner)
    {
        this.commandRunner = commandRunner;
    }

    public async Task GetContainersAsync(IProgress<IEnumerable<Container>> progress)
    {
        await Task.Run(() =>
        {
            var result = commandRunner
                .RunCommand(Commands.Docker, $"{Commands.ContainerList} -a --{Commands.Format} json")
                .ToString()
                .SplitToRows();

            var jsonHelper = new JsonHelper<Container>();
            var containers = jsonHelper.ConvertTo(result);

            foreach (var container in containers)
            {
                var label = container.Labels.Split(',').FirstOrDefault(x => x.Contains(Commands.TagProject));
                if (label != null)
                {
                    container.ComposeProject = label.Replace(Commands.TagProject, string.Empty);
                }
            }
            containers = containers.OrderBy(x => x.ComposeProject).OrderBy(x => x.Names);

            progress.Report(containers);
        });
    }

    public async Task StartContainerAsync(IProgress<CommandResult> progress, string containerId)
        => await Task.Run(() =>
            {
                progress.Report(new CommandResult(containerId, commandRunner
                    .RunCommand(Commands.Docker, $"{Commands.Start} {containerId}")
                    .ToString()));
            });

    public async Task RestartContainerAsync(IProgress<CommandResult> progress, string containerId)
        => await Task.Run(() =>
            {
                progress.Report(new CommandResult(containerId, commandRunner
                    .RunCommand(Commands.Docker, $"{Commands.Restart} {containerId}")
                    .ToString()));
            });

    public async Task StopContainerAsync(IProgress<CommandResult> progress, string containerId)
        => await Task.Run(() =>
            {
                progress.Report(new CommandResult(containerId, commandRunner
                        .RunCommand(Commands.Docker, $"{Commands.Stop} {containerId}")
                        .ToString()));
            });

    public async Task PauseContainerAsync(IProgress<CommandResult> progress, string containerId)
        => await Task.Run(() =>
            {
                progress.Report(new CommandResult(containerId, commandRunner
                        .RunCommand(Commands.Docker, $"{Commands.Pause} {containerId}")
                        .ToString()));
            });

    public async Task UnPauseContainerAsync(IProgress<CommandResult> progress, string containerId)
        => await Task.Run(() =>
            {
                progress.Report(new CommandResult(containerId, commandRunner
                        .RunCommand(Commands.Docker, $"{Commands.Unpause} {containerId}")
                        .ToString()));
            });

    public async Task DeleteContainerAsync(IProgress<CommandResult> progress, string containerId)
        => await Task.Run(() =>
            {
                progress.Report(new CommandResult(containerId, commandRunner
                        .RunCommand(Commands.Docker, $"{Commands.Delete} {containerId}")
                        .ToString()));
            });

    public async Task GetContainerLogsAsync(IProgress<string> progress, string containerId)
        => await Task.Run(() =>
            {
                progress.Report(commandRunner
                        .RunCommand(Commands.Docker, $"{Commands.Logs} {containerId}")
                        .ToString());
            });
}
