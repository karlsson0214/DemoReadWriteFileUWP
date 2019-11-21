using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DemoReadWriteFileUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        FileDemo demo;
        public MainPage()
        {
            this.InitializeComponent();
            demo = new FileDemo();
            // show path in GUI
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            path.Text = storageFolder.Path;
        }

        private async void CreateFile_Click(object sender, RoutedEventArgs e)
        {
            StorageFile storageFile = await demo.CreateFileAsync(GetFileName());
            ReadFromFile();
        }

        private async void OverwriteFile_Click(object sender, RoutedEventArgs e)
        {
            // write to file 
            String message = textToWrite.Text + Environment.NewLine;
            await demo.WriteToFileAsync(GetFileName(), message);

            ReadFromFile();
        }


        private async void AppendFile_Click(object sender, RoutedEventArgs e)
        {
            // append to file
            String message = textToAppend.Text + Environment.NewLine;
            await demo.AppendToFileAsync(GetFileName(), message);
            
            ReadFromFile();
        }
        private async void ReadFromFile()
        {
            textInFile.Text = await demo.ReadFromFileAsync(GetFileName());
        }
        private String GetFileName()
        {
            return fileName.Text + ".txt";
        }
    }
}
