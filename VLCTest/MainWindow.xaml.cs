using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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
using System.Windows.Forms;

namespace VLCTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            VLCControl.MediaPlayer.VlcLibDirectoryNeeded += MediaPlayer_VlcLibDirectoryNeeded;
        }

        void MediaPlayer_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            if (currentDirectory == null)
                return;
            if (AssemblyName.GetAssemblyName(currentAssembly.Location).ProcessorArchitecture == ProcessorArchitecture.X86)
                e.VlcLibDirectory = new DirectoryInfo(currentDirectory);
            else
                e.VlcLibDirectory = new DirectoryInfo(currentDirectory);
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            VLCControl.MediaPlayer.BeginInit();
            var d = new Microsoft.Win32.OpenFileDialog();
            d.Multiselect = false;
            if (d.ShowDialog() == true)
            {
                Uri src = new Uri(d.FileName);
                VLCControl.MediaPlayer.Play(src); //Exception here
            }
        }
    }
}
