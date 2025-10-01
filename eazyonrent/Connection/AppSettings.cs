

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
        public const string GetItemDetailsById = "Lister/GetItemById";
        public const string UserLogin = "User/UserRegister";
        public const string EditProfile = "Lister/EditProfileById";
        public const string ProfileItem = "Lister/GetAllItem";
        public const string BookItem = "Lister/bookItem";
        public const string SimilarItems = "Lister/GetSimilarItems";
        public const string AddItems = "Lister/CreateItem";
        public const string AddItmeImages = "Lister/uploadItemImages";
        public const string HistoryItme = "Lister/bookHistory";
    }
}
