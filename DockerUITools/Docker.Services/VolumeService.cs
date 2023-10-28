using Docker.Abstractions.Services;
using Docker.Constants;
using Docker.Helpers;
using Docker.Models;

namespace Docker.Services;

public class VolumeService : IVolumeService
{
    public async Task GetVolumesAsync(IProgress<IEnumerable<Volume>> progress)
    {
        await Task.Run(() =>
        {
            var result = CommandRunner
                .RunCommand(Commands.Docker, $"{Commands.Volume} {Commands.List} --{Commands.Format} json")
                .ToString()
                .SplitToRows();

            var jsonHelper = new JsonHelper<Volume>();
            var volumes = jsonHelper.ConvertTo(result);
            progress.Report(volumes);
        });
    }
    public async Task DeleteVolumeAsync(IProgress<string> progress, string volumeName)
        => await Task.Run(() =>
        {
            progress.Report(CommandRunner
                        .RunCommand(Commands.Docker, $"{Commands.Volume} {Commands.Delete} {volumeName}")
                        .ToString());
        });
}
