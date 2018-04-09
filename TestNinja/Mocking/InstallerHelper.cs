using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private string _setupDestinationFile ;
        private IDownLoadHelper _downLoadHelper;

        public InstallerHelper(IDownLoadHelper downLoadHelper = null)
        {
            _downLoadHelper = downLoadHelper ?? new DownLoadHelper();
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {

            try
            {
                _downLoadHelper.DownLoadFile(
                    string.Format("http://example.com/{0}/{1}",
                        customerName,
                        installerName),
                    _setupDestinationFile);

                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }

    public class DownLoadHelper : IDownLoadHelper
    {
        public void DownLoadFile(string url, string path)
        {
            var client = new WebClient();
            client.DownloadFile(url, path);
        }
    }

    public interface IDownLoadHelper
    {
        void DownLoadFile(string url, string path);
    }

}