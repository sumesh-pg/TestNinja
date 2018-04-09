using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using TestNinja.Mocking;
using System.Net;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class InstallerHelperTests_DownloadInstaller
    {
        private Mock<IDownLoadHelper> _downloadHelper;
        private InstallerHelper _installHelper;
        [SetUp]
        public void Setup()
        {
            _downloadHelper = new Mock<IDownLoadHelper>();
            _installHelper = new InstallerHelper(_downloadHelper.Object);
        }

        [Test]
        public void WhenDownLoadFails_ReturnsFalse()
        {
            _downloadHelper.Setup(dh => dh.DownLoadFile("http://example.com/customer/installer", null)).Throws(new WebException());

            var result = _installHelper.DownloadInstaller("customer", "installer");

            Assert.IsFalse(result);

        }

        [Test]
        public void WhenDownLoadSucceed_ReturnsTrue()
        {
            _downloadHelper.Setup(dh => dh.DownLoadFile("http://example.com/customer/installer", null));

            var result = _installHelper.DownloadInstaller("customer", "installer");

            Assert.IsTrue(result);

        }

    }
}
