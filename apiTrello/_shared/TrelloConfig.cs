namespace apiTrello._shared
{
    public static class TrelloConfig
    {
        private static  string API_ROOT = "https://api.trello.com/1/";
        private static  string END_POINT = "members/me/boards/";
        private static  string API_PARAMETERS = "?key=9d62c9ab13e04e0e0132d79209e8c551&token=d049d782c343fd72f9cfaca175eb34597044f82d8e2b118c62e796bfc5ff8f87";
        public static string GetEndPoint()
        {
            return string.Concat(API_ROOT,END_POINT,API_PARAMETERS);
        }
    }
}