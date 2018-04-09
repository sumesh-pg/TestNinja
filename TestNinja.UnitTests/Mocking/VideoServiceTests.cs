using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class VideoServiceTests_GetUnprocessedVideosAsCsv
    {

        private Mock<IVideoRepository> _videoRepository;
        private VideoService _videoService; 

        [SetUp]
        public void Setup()
        {
            _videoRepository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_videoRepository.Object);
        }

        [Test]
        public void WhenVideoListEmpty_ReturnsEmptyString()
        {
            var videos = new List<Video>();

            _videoRepository.Setup(vs => vs.GetUnprocessedVideos()).Returns(videos);

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
            
        }

        [Test]
        public void WhenVideoListContainsOneItem_ReturnItemID()
        {
            var videos = new List<Video>();
            videos.Add(new Video() { Id = 1, IsProcessed = true, Title = "First" });

            _videoRepository.Setup(vs => vs.GetUnprocessedVideos()).Returns(videos);

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1"));

        }

        [Test]
        public void WhenVideoListContainsMoreThanOneItem_ReturnIDListAsCsv()
        {
            var videos = new List<Video>();
            videos.Add(new Video() { Id = 1, IsProcessed = false, Title = "First" });
            videos.Add(new Video() { Id = 2, IsProcessed = false, Title = "Second" });
            videos.Add(new Video() { Id = 3, IsProcessed = false, Title = "Third" });

            _videoRepository.Setup(vs => vs.GetUnprocessedVideos()).Returns(videos);

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));

        }

    }
}
