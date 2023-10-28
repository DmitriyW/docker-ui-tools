using Docker.Abstractions.Services;
using Docker.Constants;
using Docker.Helpers;
using Docker.Models;

namespace Docker.Services;

public class ImageService : IImageService
{
    private readonly ICommandRunner commandRunner;

    public ImageService(ICommandRunner commandRunner)
    {
        this.commandRunner = commandRunner;
    }

    public async Task GetImagesAsync(IProgress<IEnumerable<DockerImage>> progress)
    {
        await Task.Run(() =>
        {
            var result = commandRunner
                .RunCommand(Commands.Docker, $"{Commands.Images} -a --{Commands.Format} json")
                .ToString()
                .SplitToRows();

            var jsonHelper = new JsonHelper<DockerImage>();
            var containers = jsonHelper.ConvertTo(result);
            progress.Report(containers);
        });
    }

    public async Task DeleteImageAsync(IProgress<string> progress, string imageId)
        => await Task.Run(() =>
            {
                progress.Report(commandRunner
                            .RunCommand(Commands.Docker, $"{Commands.RemoveImage} {imageId}")
                            .ToString());
            });
}
