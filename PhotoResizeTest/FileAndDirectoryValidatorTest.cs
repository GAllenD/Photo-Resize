using System;
using PhotoResize.Validator;
using Xunit;

namespace PhotoResizeTest
{
    public class FileAndDirectoryValidatorTest
    {
        [Fact]
        public void ShouldVerifyAndFindErrors()
        {
            var result = FileAndDirectoryValidator.IsValid(@"C:\DirectoryMissing\FileNobodyHas");

            Assert.False(result.Valid);
            Assert.Equal(2,result.Errors.Count);
            Assert.Contains(FileAndDirectoryValidator.DirectoryIsMissing,result.Errors);
            Assert.Contains(FileAndDirectoryValidator.FileExtentionIsMissing,result.Errors);
        }

        [Fact]
        public void ShouldVerifyClean()
        {
            var currentDir = Environment.CurrentDirectory;

            var result = FileAndDirectoryValidator.IsValid(currentDir + @"\TestDirectory\test.jpg");

            Assert.True(result.Valid);
            Assert.Empty(result.Errors);
        }
    }
}
