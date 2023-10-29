using Docker.Abstractions.Services;
using Docker.Constants;
using Docker.Models;
using Moq;

namespace Docker.Services.UnitTests
{
    [TestFixture]
    public class VolumeServiceTests
    {
        private readonly VolumeService service;
        private readonly Mock<ICommandRunner> mockCommandRunner;

        public VolumeServiceTests()
        {
            mockCommandRunner = new Mock<ICommandRunner>();
            service = new VolumeService(mockCommandRunner.Object);
        }

        [SetUp]
        public void Setup()
        {
            mockCommandRunner.Reset();

            mockCommandRunner.Setup(x =>
                x.RunCommand(Commands.Docker, $"{Commands.Volume} {Commands.Delete} volumeId"))
                .Returns(string.Empty);

            mockCommandRunner.Setup(x =>
                x.RunCommand(Commands.Docker, $"{Commands.Volume} {Commands.List} --{Commands.Format} json"))
                .Returns(string.Empty);
        }

        [Test]
        public async Task GetVolumesShouldReturnTheListOfVolumesWhenVolumesAreExist()
        {
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(GetVolumes())
                .Replace("[", string.Empty)
                .Replace("]", string.Empty);

            mockCommandRunner.Reset();

            mockCommandRunner.Setup(x =>
                x.RunCommand(Commands.Docker, $"{Commands.Volume} {Commands.List} --{Commands.Format} json"))
                .Returns(result);
            var serviceResult = new Action<IEnumerable<Volume>>(x =>
            {
                Assert.NotNull(x);
                Assert.That(x, Is.EqualTo(GetVolumes()));
            });

            await this.service.GetVolumesAsync(new Progress<IEnumerable<Volume>>(serviceResult));
        }

        [Test]
        public async Task GetVolumesShouldReturnEmptyListWhenVolumesAreNotExist()
        {
            mockCommandRunner.Reset();
            mockCommandRunner.Setup(x =>
                x.RunCommand(Commands.Docker, $"{Commands.Volume} {Commands.List} --{Commands.Format} json"))
                .Returns(string.Empty);

            var serviceResult = new Action<IEnumerable<Volume>>(x =>
            {
                Assert.NotNull(x);
                Assert.That(x, Is.EqualTo(new List<Volume>()));
            });

            await this.service.GetVolumesAsync(new Progress<IEnumerable<Volume>>(serviceResult));
        }

        [Test]
        public async Task DeleteVolumeShouldReturnEmptyVolumeIsDeleted()
        {
            var serviceResult = new Action<string>(x =>
            {
                Assert.NotNull(x);
                Assert.That(x, Is.EqualTo(string.Empty));
            });

            await this.service.DeleteVolumeAsync(new Progress<string>(serviceResult), "volumeId");
        }

        private List<Volume> GetVolumes()
            => new List<Volume>()
            {
                new Volume {
                    Availability =  "N/A",
                    Driver =  "local",
                    Group =  "N/A",
                    Labels =  "com.docker.volume.anonymous=",
                    Links =  "N/A",
                    Mountpoint =  "/var/lib/docker/volumes/1e666cfc8d137d24d8bfd2404497e26e091f039f28f5ddaab7c299e84a11a640/_data",
                    Name =  "1e666cfc8d137d24d8bfd2404497e26e091f039f28f5ddaab7c299e84a11a640",
                    Scope =  "local",
                    Size =  "N/A",
                    Status =  "N/A"
                },
                new Volume {
                    Availability =  "N/A",
                    Driver =  "local",
                    Group =  "N/A",
                    Labels =  "com.docker.volume.anonymous=",
                    Links =  "N/A",
                    Mountpoint =  "/var/lib/docker/volumes/168eec55255e985d76c0a4c35c0f3b7bd8bd80b9e3c79bf546c351ab801f79e6/_data",
                    Name =  "168eec55255e985d76c0a4c35c0f3b7bd8bd80b9e3c79bf546c351ab801f79e6",
                    Scope =  "local",
                    Size =  "N/A",
                    Status =  "N/A"
                },
                new Volume {
                    Availability =  "N/A",
                    Driver =  "local",
                    Group =  "N/A",
                    Labels =  "com.docker.volume.anonymous=",
                    Links =  "N/A",
                    Mountpoint =  "/var/lib/docker/volumes/8905e8543500394ea5f520ec4abdbcb58d343657fa2c48844adff46152f4c623/_data",
                    Name =  "8905e8543500394ea5f520ec4abdbcb58d343657fa2c48844adff46152f4c623",
                    Scope =  "local",
                    Size =  "N/A",
                    Status =  "N/A"
                }
            };
    }
}
