﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RecoDigit
{
    /*! @brief A utility class for working with images.
     * The main focus is on System.Drawing.Bitmap class.
     * The purpose of this class is to bend Bitmap's functionalities to the needs of the rest of the aplication.
     */

    static class ImageUtilities
    {
        /*! @brief A method to create a resized copy of a bitmap.
         * 
         * @param[in] original The bitmap to be copied and resized.
         * @param[in] width The desired width of the output bitmap.
         * @param[in] height The desired height of the output bitmap.
         * @param[in] interpolationMode The interpolation mode used when scaling the bitmap up or down.
         * @return result The resized bitmap.
         */
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

        /*! @brief A method to create an array of bytes of which a bitmap consists, row-by-row, column-by-column.
         * 
         * @param[in] bitmap The bitmap to be turned into an array of bytes.
         * @return result 1D array of bytes, acquired by going left to right, top to bottom.
         * 
         */
        public static byte[] BitmapToArray(Bitmap bitmap)
        {
            byte[] result = new byte[bitmap.Width * bitmap.Height];

            for (int y = 0; y < bitmap.Height; ++y)
            {
                for (int x = 0; x < bitmap.Width; ++x)
                {
                    Color pixel = bitmap.GetPixel(x, y);

                    /*! Converts each pixel's to an 8bit gray value. \n 
                     * Formula from: https://support.ptc.com/help/mathcad/r9.0/en/index.html#page/PTC_Mathcad_Help/example_grayscale_and_color_in_images.html \n 
                     */
                    byte gray = (byte)(int)(pixel.R * 0.299 + pixel.G * 0.587 + pixel.B * 0.114);
                    result[y * bitmap.Height + x] = gray; // This indexing feels a bit unnatural but it has to be like this for it to work
                }
            }

            return result;
        }
        
    }
}
