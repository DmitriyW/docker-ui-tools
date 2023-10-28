using Docker.Models;

namespace Docker.Abstractions.Services;

public interface IImageService
{
    public Task GetImagesAsync(IProgress<IEnumerable<DockerImage>> progress);

    public Task DeleteImageAsync(IProgress<string> progress, string imageId);
}
