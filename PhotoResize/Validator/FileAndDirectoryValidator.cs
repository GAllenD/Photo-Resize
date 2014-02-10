using System;
using System.IO;
using System.Linq;

namespace PhotoResize.Validator
{
    public static class FileAndDirectoryValidator
    {
        public const string FileExtentionIsMissing = "File Extention is missing";
        public const string DirectoryIsMissing = "Directory is missing";

        public static ValidatorResult IsValid(string directoryPath)
        {
            var result = new ValidatorResult();

            var fileName = Path.GetFileName(directoryPath);

            if (!Path.HasExtension(directoryPath))
            {
                result.Errors.Add(FileExtentionIsMissing);
            }

            var directoryName = directoryPath.Replace(fileName, "");

            if (!Directory.Exists(directoryName))
            {
                result.Errors.Add(DirectoryIsMissing);
            }

            result.Valid = !result.Errors.Any();
            return result;

        }
    }
}
