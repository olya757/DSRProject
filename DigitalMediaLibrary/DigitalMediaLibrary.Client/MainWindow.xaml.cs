using DigitalMediaLibrary.Client.ViewModel;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace DigitalMediaLibrary.Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string DIR_TEMP_PATH = @"TEMP_FILES";

        public MainWindow()
        {
            InitializeComponent();
            ((MainWindowViewModel)DataContext).IndexMediaFilesViewModel.PropertyChanged += MediaSourceChanged;
            MediaPlayer.Loaded += MediaPlayer_MediaOpened;
        }

        private void MediaSourceChanged(object sender, PropertyChangedEventArgs eventArgs)
        {
            if (eventArgs.PropertyName == "SelectedMediaFile")
            {
                var mediaFile = ((IndexMediaFilesViewModel)sender).SelectedMediaFile;
                if (!(mediaFile is null))
                {
                    var source = MediaPlayer.Source;
                    this.MediaPlayer.Stop();
                    string tempPath = DIR_TEMP_PATH+"/"+ mediaFile.Name;
                    if (!File.Exists(tempPath))
                    {
                        try
                        {
                            File.WriteAllBytes(tempPath, mediaFile.Content);
                        }
                        catch (Exception e)
                        {
                            tempPath = source.OriginalString;
                        }
                    }
                    MediaPlayer.Clock = null;
                    this.MediaPlayer.Source = new Uri(tempPath, UriKind.Relative);
                }
            }
        }

        private void TreeView_Expanded(object sender, RoutedEventArgs e)
        {
            ((MainWindowViewModel)DataContext).DirectoryTreeViewModel.ExpandNode(sender, e);
        }

        private void DirectoriesTreeView_Selected(object sender, RoutedEventArgs e)
        {
            ((MainWindowViewModel)DataContext).DirectoryTreeViewModel.SelectNode(sender, e);
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedEventArgs e)
        {
            ((MainWindowViewModel)DataContext).CategoryTreeViewModel.SelectNode(sender, e);
        }
        private DispatcherTimer timer;

        private void MediaPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            if(((MainWindowViewModel)DataContext).IndexMediaFilesViewModel.SelectedMediaFile is null)
                return;
            ((MainWindowViewModel)DataContext).IndexMediaFilesViewModel.SelectedMediaFile.IsMediaOpened = true;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(300);
            timer.Tick += new EventHandler(timer_Tick);
            this.MediaPlayer.Position = TimeSpan.FromMilliseconds(0);
            if (MediaPlayer.NaturalDuration.HasTimeSpan)
                this.SliderMedia.Maximum = MediaPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            SliderMedia.Value = MediaPlayer.Position.TotalMilliseconds;
        }
        
        private void TreeView_Loaded(object sender, RoutedEventArgs e)
        {
            var curr = ((MainWindowViewModel)DataContext).CategoryTreeViewModel.CurrentNode;
            TreeViewItem tvi = CategoryTreeView.ItemContainerGenerator.ContainerFromItem(curr) as TreeViewItem;
            if (tvi != null) tvi.IsSelected = true;
        }
        
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            foreach(var file in Directory.GetFiles(DIR_TEMP_PATH))
            {
                File.Delete(file);
            }
            foreach(var dir in Directory.GetDirectories(DIR_TEMP_PATH))
            {
                Directory.Delete(dir);
            }
        }

        private void MediaPlayer_Loaded(object sender, RoutedEventArgs e)
        {
            if(!Directory.Exists(DIR_TEMP_PATH))
                Directory.CreateDirectory(DIR_TEMP_PATH);
        }

        private void MediaPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Position=TimeSpan.FromSeconds(0);
            MediaPlayer.Play();
        }
    }
}
