using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace RecoDigit
{
    static  class ImageUtilities
    {
        public static Bitmap Resize(Bitmap original, int width, int height, System.Drawing.Drawing2D.InterpolationMode interpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default)
        {
            Bitmap result = new Bitmap(width, height);

            using (Graphics gResult = Graphics.FromImage(result))
            {
                gResult.InterpolationMode = interpolationMode;
                gResult.DrawImage(original, 0, 0, width, height);
            }

            return result;
        }

        public static byte[] BitmapToArray(Bitmap bitmap)
        {
            byte[] result = new byte[bitmap.Width * bitmap.Height];

            for (int y = 0; y < bitmap.Height; ++y)
            {
                for (int x = 0; x < bitmap.Width; ++x)
                {
                    Color pixel = bitmap.GetPixel(x, y);

                    // Convert pixel to a gray value
                    // Formula from: https://support.ptc.com/help/mathcad/r9.0/en/index.html#page/PTC_Mathcad_Help/example_grayscale_and_color_in_images.html
                    byte gray = (byte)(int)(pixel.R * 0.299 + pixel.G * 0.587 + pixel.B * 0.114);
                    result[y * bitmap.Height + x] = gray; // This indexing feels a bit unnatural but it has to be like this for it to work
                }
            }

            return result;
        }
        
    }
}
