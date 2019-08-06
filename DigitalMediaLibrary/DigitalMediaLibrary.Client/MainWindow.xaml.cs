using DigitalMediaLibrary.Client.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DigitalMediaLibrary.Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ((MainWindowViewModel)DataContext).IndexMediaFilesViewModel.PropertyChanged += MediaSourceChanged;
        }

        private void MediaSourceChanged(object sender, PropertyChangedEventArgs eventArgs)
        {
            if (eventArgs.PropertyName == "SelectedMediaFile")
            {

                this.MediaPlayer.Position = TimeSpan.FromMilliseconds(0);
                if (MediaPlayer.NaturalDuration.HasTimeSpan)
                    this.SliderMedia.Maximum = MediaPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;
                var mediaFile = ((IndexMediaFilesViewModel)sender).SelectedMediaFile;
                if (!(mediaFile is null))
                {
                    this.MediaPlayer.Play();
                    string tempPath = mediaFile.Name;
                    File.WriteAllBytes(@tempPath, mediaFile.Content);
                    MediaPlayer.Clock = null;
                    this.MediaPlayer.Source = new Uri(@tempPath, UriKind.Relative);
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
            ((MainWindowViewModel)DataContext).IndexMediaFilesViewModel.SelectedMediaFile.IsMediaOpened = true;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(300);
            timer.Tick += new EventHandler(timer_Tick);
            this.MediaPlayer.Position = TimeSpan.FromMilliseconds(0);
            if (MediaPlayer.NaturalDuration.HasTimeSpan)
                this.SliderMedia.Maximum = MediaPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;
            this.MediaPlayer.Pause();
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            SliderMedia.Value = MediaPlayer.Position.TotalMilliseconds;
        }

        private void MediaPlayer_Loaded(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Play();
            MediaPlayer.Pause();
            /*timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(50);
            timer.Tick += new EventHandler(timer_Tick);
            this.MediaPlayer.Position = TimeSpan.FromMilliseconds(0);
            if (MediaPlayer.NaturalDuration.HasTimeSpan)
                this.SliderMedia.Maximum = MediaPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;
            this.MediaPlayer.Stop();
            timer.Start();*/
        }

        

        private void DirectoriesTreeView_Loaded(object sender, RoutedEventArgs e)
        {
            /*
            var path = ((MainWindowViewModel)DataContext).DirectoryTreeViewModel.DirectoryTree.PathToStart;
            TreeViewItem tvi= DirectoriesTreeView.ItemContainerGenerator.ContainerFromItem(path[0]) as TreeViewItem;
            for(int i=1;i<path.Count();i++)
            {
                tvi.Focus();
                tvi.IsSelected = true;
                tvi = tvi.ItemContainerGenerator.ContainerFromItem(path[i]) as TreeViewItem;
            }
            var curr = ((MainWindowViewModel)DataContext).DirectoryTreeViewModel.CurrentNode;
            TreeViewItem tvi = DirectoriesTreeView.ItemContainerGenerator.ContainerFromItem(curr) as TreeViewItem;
            if (tvi != null) tvi.IsSelected = true;*/
        }

        private void TreeView_Loaded(object sender, RoutedEventArgs e)
        {
            var curr = ((MainWindowViewModel)DataContext).CategoryTreeViewModel.CurrentNode;

            TreeViewItem tvi = CategoryTreeView.ItemContainerGenerator.ContainerFromItem(curr) as TreeViewItem;
            if (tvi != null) tvi.IsSelected = true;
        }
    }
}
