using System.Drawing;

namespace PhotoResize
{
    public class ResizeRequest
    {
        public ResizeRequest()
        {
            CreateNewDirectoryIfAbsent = true;
        }

        /// <summary>
        /// Full path and file name of the file to be resized
        /// </summary>
        public string OriginalImageFilePath { get; set; }

        /// <summary>
        /// Full path and file name of the file to be created
        /// </summary>
        public string NewImageFilePath { get; set; }

        /// <summary>
        /// Size of the new image file
        /// </summary>
        public Size NewImageSize { get; set; }

        /// <summary>
        /// Create Missing directory structure in NewImageFilePath. Default is true.  
        /// </summary>
        public bool CreateNewDirectoryIfAbsent { get; set; }
    }
}
