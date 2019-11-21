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
            StorageFile file = null;
            try
            {
                file = await storageFolder.CreateFileAsync(fileName, Windows.Storage.CreationCollisionOption.ReplaceExisting);
            }
            catch(FileNotFoundException e)
            {
                // The file name contains invalid characters, or the format of the filename is incorrect.Check the value of desiredName.
                return null;
            }
            catch(UnauthorizedAccessException e)
            {
                // You don't have permission to create a file in the current folder.
                return null;
            }
            return file;
        }


        /// <summary>
        /// Write the specified message to the specified file. Overwrite content.
        /// 
        /// Task<bool> instead of void to make it possible to await the call to this method
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="message"></param>
        /// <returns>Returns true if successful, otherwise false.</returns>
        public async Task<bool> WriteToFileAsync(string fileName, string message)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

            // TODO identical try catch block in two places and almost the same in a third place
            StorageFile file;
            try
            {
                file = await storageFolder.GetFileAsync(fileName);
            }
            catch (FileNotFoundException e)
            {
                // The specified file does not exist. 
                return false;
            }
            catch (UnauthorizedAccessException e)
            {
                // You don't have permission to access the specified file.
                return false;
            }
            catch (ArgumentException e)
            {
                // The path cannot be in Uri format (for example, /image.jpg).
                return false;
            }

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
        /// <returns>Returns true if successful, otherwise false.</returns>
        public async Task<bool> AppendToFileAsync(string fileName, string message)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile file;
            try
            {
                file = await storageFolder.GetFileAsync(fileName);
            }
            catch (FileNotFoundException e)
            {
                // The specified file does not exist. 
                return false;
            }
            catch (UnauthorizedAccessException e)
            {
                // You don't have permission to access the specified file.
                return false;
            }
            catch (ArgumentException e)
            {
                // The path cannot be in Uri format (for example, /image.jpg).
                return false;
            }
            await FileIO.AppendTextAsync(file, message);           
            return true;
        }
        /// <summary>
        /// Read text from the specified file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Text in file if successful, otherwise null.</returns>
        public async Task<string> ReadFromFileAsync(string fileName)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile file;
            try
            {
                file = await storageFolder.GetFileAsync(fileName);
            }
            catch (FileNotFoundException e)
            {
                // The specified file does not exist. 
                return null;
            }
            catch (UnauthorizedAccessException e)
            {
                // You don't have permission to access the specified file.
                return null;
            }
            catch (ArgumentException e)
            {
                // The path cannot be in Uri format (for example, /image.jpg).
                return null;
            }
            string text = await Windows.Storage.FileIO.ReadTextAsync(file);
            return text;
        }

        
    }
}
