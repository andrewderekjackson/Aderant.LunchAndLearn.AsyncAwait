using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Massive {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public ObservableCollection<KittenImage> Kittens { get; set; }
        public ObservableCollection<string> Messages { get; set; }
        
        public MainWindow() {
            Kittens = new ObservableCollection<KittenImage>();
            Messages = new ObservableCollection<string>() {
                "Kitten Finder v1.0 - No kittens were harmed in the making of this software."
            };

            InitializeComponent();
            DataContext = this;
        }

        private async void Button_Click(object sender, RoutedEventArgs e) {

            Downloader downloader = new Downloader();

            int numberOfKittens = int.Parse(kittenTextBox.Text);

            // reset the UI
            ProgressBar.Maximum = numberOfKittens;
            ProgressBar.Minimum = 0;
            ProgressBar.Value = 0;
            Messages.Clear();
            Kittens.Clear();

            LogMessage(string.Format("Starting download of {0} kitten(s)...", numberOfKittens));

            for (int i = 0; i < numberOfKittens; i++) {

                try {
                    LogMessage(string.Format("Downloading kitten {0}...", i + 1));

                    var kitten = await downloader.DownloadKittenFileAsync();
                    await Task.Factory.StartNew(() => ProcessKittenFile(kitten));
                    
                    Kittens.Add(kitten);

                    LogMessage(string.Format("Download of kitten {0} finished.", i + 1));

                    // update the progress bar
                    ProgressBar.Value = i + 1;


                } catch (Exception ex) {
                    LogMessage(string.Format("Could not download kitten {0} - sorry.", i + 1));
                } finally {
                    LogMessage("Sfsfsdf");
                }

            }
            
            LogMessage("Download of kittens finished.");
        }

        private void ProcessKittenFile(KittenImage kitten) {
            
            // simulate some heavy processing!
            Thread.Sleep(1000);
        }

        private void LogMessage(string message) {
            Messages.Add(message);
        }
    }
}
