using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Massive {
    public class Downloader {

        public KittenImage DownloadKittenFile() {

            Uri uri = new Uri(string.Format("http://lorempixel.com/800/600/cats/"));
            WebClient client = new WebClient();
            

            byte[] data = client.DownloadData(uri);

            //throw new InvalidOperationException("NO!");

            return new KittenImage() {
                Uri = uri,
                ImageData = data
            };

            
        }

        #region Async version

        public Task<KittenImage> DownloadKittenFileAsync() {

            return Task.Factory.StartNew(() => DownloadKittenFile());
        }

        #endregion

    }
}
