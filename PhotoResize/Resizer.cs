using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using PhotoResize.Validator;

namespace PhotoResize
{
    public static class Resizer
    {
        public static void Resize(ResizeRequest request)
        {
            ValidateRequest(request);

            using (var imgToResize = Image.FromFile(request.OriginalImageFilePath))
            {
                var sourceWidth = imgToResize.Width;
                var sourceHeight = imgToResize.Height;

                var nPercentW = (request.NewImageSize.Width/(float) sourceWidth);
                var nPercentH = (request.NewImageSize.Height/(float) sourceHeight);
                var nPercent = nPercentH < nPercentW ? nPercentH : nPercentW;

                var destWidth = (int) (sourceWidth*nPercent);
                var destHeight = (int) (sourceHeight*nPercent);

                using (var b = new Bitmap(destWidth, destHeight))
                using (var g = Graphics.FromImage(b))
                {
                    g.SmoothingMode = SmoothingMode.HighSpeed;
                    g.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                    g.CompositingQuality = CompositingQuality.HighSpeed;

                    g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);

                    b.Save(request.NewImageFilePath);
                    imgToResize.Dispose();
                }
            }
        }

        private static void ValidateRequest(ResizeRequest request)
        {
            var validation = FileAndDirectoryValidator.IsValid(request.NewImageFilePath);

            if(validation.Valid) return;

            throw new Exception(validation.Errors.First());
        }
        
    }

}
