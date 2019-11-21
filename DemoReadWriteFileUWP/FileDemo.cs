using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
// library used to read and write to file
using Windows.Storage;

namespace DemoReadWriteFileUWP
{
    class FileDemo
    {

        public async Task<StorageFile> CreateFileAsync(string fileName)
        {
            // Create file; replace if exists.
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await storageFolder.CreateFileAsync(fileName, Windows.Storage.CreationCollisionOption.ReplaceExisting);
            return file;
        }


        /// <summary>
        /// Write the specified message to the specified file. Overwrite content.
        /// 
        /// Task<bool> instead of void to make it possible to await the call to this method
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="message"></param>
        /// <returns>Returns true.</returns>
        public async Task<bool> WriteToFileAsync(string fileName, string message)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await storageFolder.GetFileAsync(fileName);
            await FileIO.WriteTextAsync(file, message);            
            return true;
        }

        /// <summary>
        /// Append specified message to the specified file.
        /// 
        /// Task<bool> instead of void to make it possible to await the call to this method
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="message"></param>
        /// <returns>Returns true.</returns>
        public async Task<bool> AppendToFileAsync(string fileName, string message)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await storageFolder.GetFileAsync(fileName);
            await FileIO.AppendTextAsync(file, message);           
            return true;
        }
        /// <summary>
        /// Read text from the specified file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<string> ReadFromFileAsync(string fileName)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await storageFolder.GetFileAsync(fileName);            
            string text = await Windows.Storage.FileIO.ReadTextAsync(file);
            return text;
        }
    }
}
