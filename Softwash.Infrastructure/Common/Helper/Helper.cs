using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softwash.Infrastructure.Common.Helper
{
   
    public class Helper
    {

        public static bool IsVideoLink(string url)
        {
            return !string.IsNullOrEmpty(url) && url.StartsWith("https://", StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsYouTubeLink(string url)
        {
            if (string.IsNullOrEmpty(url)) return false;

            return url.StartsWith("https://", StringComparison.OrdinalIgnoreCase) &&
                   (url.Contains("youtube.com/watch", StringComparison.OrdinalIgnoreCase) ||
                    url.Contains("youtu.be/", StringComparison.OrdinalIgnoreCase));
        }

    }

}
