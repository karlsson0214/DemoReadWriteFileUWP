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
    /// <summary>
    /// Util class, used to handle files.
    /// </summary>
    class FileDemo
    {
        /// <summary>
        /// Create a file with the specified fileName. 
        /// Existing file with the same name will be replaced.
        /// </summary>
        /// <param name="fileName">The name of the file including extension. 
        /// For exampel: "textfilename.txt"</param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException">
        /// The file name contains invalid characters, 
        /// or the format of the filename is incorrect. 
        /// Check the value of fileName.</exception>
        public async Task<StorageFile> CreateFileAsync(string fileName)
        {
            // Create file; replace if exists.
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await storageFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            return file;
        }


        /// <summary>
        /// Write the specified message to the specified file. Overwrite content.
        /// 
        /// Task<bool> instead of void to make it possible to await the call to this method
        /// </summary>
        /// 
        /// <param name="fileName">Name of file.</param>
        /// <param name="message">The text to write to file.</param>
        /// 
        /// <returns>Returns true.</returns>
        /// 
        /// <exception cref="FileNotFoundException">
        /// The specified file does not exist.Check the value of name.</exception>
        /// 
        /// <exception cref="UnauthorizedAccessException">
        /// You don't have permission to access the specified file. 
        /// For more information, see <see cref="File access permissions"/>.</exception>
        /// 
        /// <exception cref="ArgumentException">
        /// The path cannot be in Uri format(for example, /image.jpg). 
        /// Check the value of name.</exception>
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
        /// <param name="fileName">Name of file.</param>
        /// <param name="message">The text to append to the end of the specified file.</param>
        /// <returns>Returns true.</returns>
        /// 
        /// <exception cref="FileNotFoundException">
        /// The specified file does not exist.Check the value of name.</exception>
        /// 
        /// <exception cref="UnauthorizedAccessException">
        /// You don't have permission to access the specified file. 
        /// For more information, see <see cref="File access permissions"/>.</exception>
        /// 
        /// <exception cref="ArgumentException">
        /// The path cannot be in Uri format(for example, /image.jpg). 
        /// Check the value of name.</exception>
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
        /// <returns>Returns text in file as a string.</returns>
        ///          
        /// <exception cref="FileNotFoundException">
        /// The specified file does not exist.Check the value of name.</exception>
        /// 
        /// <exception cref="UnauthorizedAccessException">
        /// You don't have permission to access the specified file. 
        /// For more information, see <see cref="File access permissions"/>.</exception>
        /// 
        /// <exception cref="ArgumentException">
        /// The path cannot be in Uri format(for example, /image.jpg). 
        /// Check the value of name.</exception>
        public async Task<string> ReadFromFileAsync(string fileName)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await storageFolder.GetFileAsync(fileName);            
            string text = await FileIO.ReadTextAsync(file);
            return text;
        }
    }
}
