using Docker.Helpers;
using Docker.Models;

namespace Docker.Services;

public class ImageService
{
    public async Task GetImageAsync(IProgress<IEnumerable<DockerImage>> progress)
    {
        await Task.Run(() =>
        {
            var result = CommandRunner
                .RunCommand("docker", "images -a --format json")
                .ToString()
                .SplitToRows();

            var jsonHelper = new JsonHelper<DockerImage>();
            var containers = jsonHelper.ConvertTo(result);
            progress.Report(containers);
        });
    }

    public async Task DeleteContainerAsync(IProgress<string> progress, string imageId)
        => await Task.Run(() =>
            {
                progress.Report(CommandRunner
                            .RunCommand("docker", $"rmi {imageId}")
                            .ToString());
            });
}
