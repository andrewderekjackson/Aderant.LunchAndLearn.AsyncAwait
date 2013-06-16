using System;
using System.IO;
using System.Threading;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Massive
{
    public class KittenImage {

        public Uri Uri { get; set; }

        public Byte[] ImageData { get; set; }

        public ImageSource ImageSource {
            get {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(ImageData);
                bi.EndInit();

                return bi;
            }
        }

    }
}