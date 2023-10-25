using Docker.Models;

namespace Docker.Abstractions.Services;

public interface IImageService
{
    public Task GetImageAsync(IProgress<IEnumerable<DockerImage>> progress);

    public Task DeleteContainerAsync(IProgress<string> progress, string imageId);
}
