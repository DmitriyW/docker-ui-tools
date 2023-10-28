using Docker.Models;

namespace Docker.Abstractions.Services;

public interface IVolumeService
{
    public Task GetVolumesAsync(IProgress<IEnumerable<Volume>> progress);

    public Task DeleteVolumeAsync(IProgress<string> progress, string volumeName);
}
