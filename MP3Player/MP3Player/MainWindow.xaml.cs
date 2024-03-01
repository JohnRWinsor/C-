using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TagLib;

namespace MP3Player
{
    public partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer; // Create a new MediaPlayer instance

        public MainWindow()
        {
            InitializeComponent();
            mediaPlayer = new MediaPlayer(); // Initialize the MediaPlayer instance
            VolumeSlider.Value = 50; // Set the default volume to 50%
        }

        // Volume Slider Value Changed Event Handler
        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Adjust the volume based on the slider value
            double volume = VolumeSlider.Value / 100.0; 

            mediaPlayer.Volume = volume;

        }

        // Play MP3 file
        private void Play_Click(object sender, RoutedEventArgs e)
        {       
            mediaPlayer.Play();
        }

        // Pause playing
        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        // Stop playing
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        // Exit application
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ToggleDisplay_Click(object sender, RoutedEventArgs e)
        {
            // Check if the current tab is the "Now Playing" tab
            if (TabControlMain.SelectedItem == NowPlayingTabItem)
            {
                // If the current tab is "Now Playing", switch to the "Tag Editing" tab
                TabControlMain.SelectedItem = TagEditingTabItem;
            }
            else
            {
                // If the current tab is "Tag Editing", switch to the "Now Playing" tab
                TabControlMain.SelectedItem = NowPlayingTabItem;
            }
        }


        private void DisplayNowPlaying(string fileName)
        {
            TagLib.File mp3File = TagLib.File.Create(fileName);
            if (mp3File != null)
            {
                TitleText.Text = mp3File.Tag.Title;
                ArtistText.Text = mp3File.Tag.FirstPerformer;
                AlbumText.Text = mp3File.Tag.Album;
                YearText.Text = "Year: " + mp3File.Tag.Year;

                // Load and display album image
                if (mp3File.Tag.Pictures.Length > 0)
                {
                    var picture = mp3File.Tag.Pictures[0];
                    using (MemoryStream albumArtworkStream = new MemoryStream(picture.Data.Data))
                    {
                        BitmapImage bitmapImage = new BitmapImage();
                        bitmapImage.BeginInit();
                        bitmapImage.StreamSource = albumArtworkStream;
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.EndInit();
                        AlbumImage.Source = bitmapImage; // AlbumImage is the name of your Image control
                    }
                }
            }
            else
            {
                MessageBox.Show("Failed to read metadata from the selected MP3 file.");
            }
        }

        // Select MP3 file
        private void SelectMp3File_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".mp3";
            dlg.Filter = "MP3 Files (*.mp3)|*.mp3";

            // Set the initial directory to your desired folder path
            dlg.InitialDirectory = @"C:\Users\johnw\OneDrive\Desktop\SEM2\C#\A02\MP3Player\MP3Player\Music";

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                try
                {
                    DisposeMediaPlayer(); // Close the MediaPlayer if it's already open

                    mediaPlayer = new MediaPlayer(); // Create a new MediaPlayer instance
                    mediaPlayer.Open(new Uri(dlg.FileName)); // Open the selected MP3 file
                    mediaPlayer.Play(); // Start playing the MP3 file

                    DisplayNowPlaying(dlg.FileName); // Update UI with the selected MP3 file details
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}. The file may be in use by another process.", "File Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (mediaPlayer != null && mediaPlayer.Source != null)
            {
                SaveMetadataChanges(mediaPlayer.Source.AbsolutePath);
            }
            else
            {
                MessageBox.Show("No MP3 file is currently loaded.");
            }
        }

        private void SaveMetadataChanges(string filePath)
        {
            try
            {
                TagLib.File file = TagLib.File.Create(filePath);
                var tag = file.GetTag(TagLib.TagTypes.Id3v2);

                // Update metadata with new values
                tag.Title = TitleText.Text;
                tag.Performers = new[] { ArtistText.Text };
                tag.Album = AlbumText.Text;
                if (int.TryParse(YearText.Text, out int year))
                {
                    tag.Year = (uint)year;
                }

                // Save changes
                file.Save();
                MessageBox.Show("Metadata saved successfully.");
            }
            catch (Exception ex)
            {
                // Handle exception
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void DisposeMediaPlayer()
        {
            if (mediaPlayer != null)
            {
                mediaPlayer.Close();
                mediaPlayer = null;
            }
        }
    }
}
