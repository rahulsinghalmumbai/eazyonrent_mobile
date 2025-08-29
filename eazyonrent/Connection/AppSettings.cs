using Java.Util.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eazyonrent.Connection
{
    public class AppSettings
    {

        public const string BaseApiUrl = "https://eazyonrent.com/api/";
    }
    public static class Endpoints
    {
        public const string GetAllCat = "Categories/GellALLCategories";
        public const string GetGuestItem = "Lister/GetGuestItems";
    }
}
