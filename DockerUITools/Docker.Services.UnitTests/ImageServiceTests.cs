using Docker.Abstractions.Services;
using Docker.Constants;
using Docker.Models;
using Moq;

namespace Docker.Services.UnitTests
{
    [TestFixture]
    public class ImageServiceTests
    {
        private readonly ImageService service;
        private readonly Mock<ICommandRunner> mockCommandRunner;

        public ImageServiceTests()
        {
            mockCommandRunner = new Mock<ICommandRunner>();
            service = new ImageService(mockCommandRunner.Object);
        }

        [SetUp]
        public void Setup()
        {
            mockCommandRunner.Reset();

            mockCommandRunner.Setup(x =>
                x.RunCommand(Commands.Docker, $"{Commands.RemoveImage} imageId"))
                .Returns(string.Empty);
        }

        [Test]
        public async Task GetImagesShouldReturnTheListOfImagesWhenImagesAreExist()
        {
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(GetImages())
                .Replace("[", string.Empty)
                .Replace("]", string.Empty);

            mockCommandRunner.Reset();

            mockCommandRunner.Setup(x =>
                x.RunCommand(Commands.Docker, $"{Commands.Images} -a --{Commands.Format} json"))
                .Returns(result);
            var serviceResult = new Action<IEnumerable<DockerImage>>(x =>
            {
                Assert.NotNull(x);
                Assert.That(x, Is.EqualTo(GetImages()));
            });

            await this.service.GetImagesAsync(new Progress<IEnumerable<DockerImage>>(serviceResult));
        }

        [Test]
        public async Task GetImagesShouldReturnEmptyListWhenImagesAreNotExist()
        {
            mockCommandRunner.Reset();
            mockCommandRunner.Setup(x =>
                x.RunCommand(Commands.Docker, $"{Commands.Images} -a --{Commands.Format} json"))
                .Returns(string.Empty);

            var serviceResult = new Action<IEnumerable<DockerImage>>(x =>
            {
                Assert.NotNull(x);
                Assert.That(x, Is.EqualTo(new List<DockerImage>()));
            });

            await this.service.GetImagesAsync(new Progress<IEnumerable<DockerImage>>(serviceResult));
        }

        [Test]
        public async Task DeleteImageShouldReturnEmptyImageIsDeleted()
        {
            var serviceResult = new Action<string>(x =>
            {
                Assert.NotNull(x);
                Assert.That(x, Is.EqualTo(string.Empty));
            });

            await this.service.DeleteImageAsync(new Progress<string>(serviceResult), "imageId");
        }

        private List<DockerImage> GetImages()
            => new List<DockerImage>()
            {
                new DockerImage {
                    Containers = "N/A",
                    CreatedAt = "2023-10-15 13:51:22 +0300 EEST",
                    CreatedSince = "13 days ago",
                    Digest = "none",
                    ID = "5c9c734eaf8f",
                    Repository = "jdit.auth.api",
                    SharedSize = "N/A",
                    Size = "229MB",
                    Tag = "latest",
                    UniqueSize = "N/A",
                    VirtualSize = "229.4MB"
                },
                new DockerImage {
                    Containers = "N/A",
                    CreatedAt = "2023-10-13 07:46:49 +0300 EEST",
                    CreatedSince = "2 weeks ago",
                    Digest = "none",
                    ID = "ee3b4d1239f1",
                    Repository = "mongo",
                    SharedSize = "N/A",
                    Size = "748MB",
                    Tag = "latest",
                    UniqueSize = "N/A",
                    VirtualSize = "748MB"
                },
                new DockerImage {
                    Containers = "N/A",
                    CreatedAt = "2023-10-12 21:44:42 +0300 EEST",
                    CreatedSince = "2 weeks ago",
                    Digest = "none",
                    ID = "8131a7111780",
                    Repository = "rabbitmq",
                    SharedSize = "N/A",
                    Size = "217MB",
                    Tag = "latest",
                    UniqueSize = "N/A",
                    VirtualSize = "216.6MB"
                }
            };
    }
}
