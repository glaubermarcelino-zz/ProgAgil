namespace apiTrello._shared
{
    public static class TrelloConfig
    {
        private static  string API_ROOT = "https://api.trello.com/1/";
        private static  string END_POINT = "members/me/boards/";
        private static  string API_PARAMETERS = "?key=9d62c9ab13e04e0e0132d79209e8c551&token=052396125112fc37b83b9d4215cc8e119720d4800fa2fad49760bfbd8ed7018e";
        public static string GetEndPoint()
        {
            return string.Concat(API_ROOT,END_POINT,API_PARAMETERS);
        }
    }
}