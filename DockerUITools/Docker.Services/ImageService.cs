using Docker.Abstractions.Services;
using Docker.Constants;
using Docker.Helpers;
using Docker.Models;

namespace Docker.Services;

public class ImageService : IImageService
{
    public async Task GetImageAsync(IProgress<IEnumerable<DockerImage>> progress)
    {
        await Task.Run(() =>
        {
            var result = CommandRunner
                .RunCommand(Commands.Docker, $"{Commands.Images} -a --{Commands.Format} json")
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
                            .RunCommand(Commands.Docker, $"{Commands.RemoveImage} {imageId}")
                            .ToString());
            });
}
