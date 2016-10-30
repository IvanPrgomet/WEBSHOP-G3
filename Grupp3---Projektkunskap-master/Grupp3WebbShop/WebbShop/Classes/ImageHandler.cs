using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebbShop.Classes
{
    static class ImageHandler
    {
        public static string ConvertingPics(object input)
        {
            var test = (byte[])input;
            MemoryStream imageStream = new MemoryStream(test);
            var base64 = Convert.ToBase64String(imageStream.ToArray());
            return ("data:image/gif;base64," + base64);
        }
    }
}