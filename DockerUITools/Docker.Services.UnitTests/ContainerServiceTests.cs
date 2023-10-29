using Docker.Abstractions.Services;
using Docker.Constants;
using Docker.Models;
using Moq;

namespace Docker.Services.UnitTests
{
    [TestFixture]
    public class ContainerServiceTests
    {
        private readonly ContainerService service;
        private readonly Mock<ICommandRunner> mockCommandRunner;

        public ContainerServiceTests()
        {
            mockCommandRunner = new Mock<ICommandRunner>();
            service = new ContainerService(mockCommandRunner.Object);
        }

        [SetUp]
        public void Setup()
        {
            mockCommandRunner.Reset();

            mockCommandRunner.Setup(x =>
                x.RunCommand(Commands.Docker, $"{Commands.ContainerList} -a --{Commands.Format} json"))
                .Returns(string.Empty);
        }

        [Test]
        public async Task GetContainersShouldReturnTheListOfContainersWhenVolumesAreExist()
        {
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(GetContainers())
                .Replace("[", string.Empty)
                .Replace("]", string.Empty);

            mockCommandRunner.Reset();

            mockCommandRunner.Setup(x =>
                x.RunCommand(Commands.Docker, $"{Commands.ContainerList} -a --{Commands.Format} json"))
                .Returns(result);

            var serviceResult = new Action<IEnumerable<Container>>(x =>
            {
                Assert.NotNull(x);
                Assert.That(x, Is.EqualTo(GetContainers()));
            });

            await this.service.GetContainersAsync(new Progress<IEnumerable<Container>>(serviceResult));
        }

        [Test]
        public async Task GetContainersShouldReturnEmptyListWhenContainersAreNotExist()
        {
            var serviceResult = new Action<IEnumerable<Container>>(x =>
            {
                Assert.NotNull(x);
                Assert.That(x, Is.EqualTo(new List<Container>()));
            });

            await this.service.GetContainersAsync(new Progress<IEnumerable<Container>>(serviceResult));
        }

        private List<Container> GetContainers()
           => new List<Container>()
           {
                new Container {
                    Command = "\"dotnet DemoApp.dll\"",
                    CreatedAt = "2023-10-14 04:22:19 +0300 EEST",
                    ID = "e5c6f25719a1",
                    Image = "web-app:v1",
                    Labels = "",
                    LocalVolumes = "0",
                    Mounts = "",
                    Names = "strange_neumann",
                    Networks = "bridge",
                    Ports = "",
                    RunningFor = "2 weeks ago",
                    Size = "0B",
                    State = "exited",
                    Status = "Exited (0) 25 hours ago"
                },
                new Container {
                    Command = "\"dotnet DemoApp.dll\"",
                    CreatedAt = "2023-10-15 03:07:04 +0300 EEST",
                    ID = "0de1d81472cd",
                    Image = "web-app:v1",
                    Labels = "",
                    LocalVolumes = "0",
                    Mounts = "",
                    Names = "heuristic_ellis",
                    Networks = "bridge",
                    Ports = "",
                    RunningFor = "2 weeks ago",
                    Size = "0B",
                    State = "exited",
                    Status = "Exited (0) 25 hours ago"
                },
                new Container {
                    Command = "\"/bin/tini -- /usr/l…\"",
                    CreatedAt = "2023-10-27 22:34:41 +0300 EEST",
                    ID = "c6e0ce26823b",
                    Image = "jenkins:2.60.3",
                    Labels = "",
                    LocalVolumes = "1",
                    Mounts = "1e666cfc8d137d…",
                    Names = "234234234",
                    Networks = "bridge",
                    Ports = "",
                    RunningFor = "46 hours ago",
                    Size = "0B",
                    State = "exited",
                    Status = "Exited (143) 25 hours ago"
                }
           };
    }
}
