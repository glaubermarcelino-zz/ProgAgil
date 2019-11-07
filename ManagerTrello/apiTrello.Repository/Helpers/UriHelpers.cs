using System;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;

namespace apiTrello.Repository.Repository
{
    public static class UriHelpers
    {
        public static Uri AttachParameters(this Uri uri, NameValueCollection parameters)
        {
            var stringBuilder = new StringBuilder();
            string str = "?";

            for (int index = 0; index < parameters.Count; ++index)
            {
                stringBuilder.Append(str + parameters.AllKeys[index] + "=" + parameters[index]);
                str = "&";
            }
            return new Uri(uri + stringBuilder.ToString());
        }

        public static string AddParameters(this Task<string> uri, NameValueCollection parameters)
        {
            var stringBuilder = new StringBuilder();
            string str = "?";

            for (int index = 0; index < parameters.Count; ++index)
            {
                stringBuilder.Append(str + parameters.AllKeys[index] + "=" + parameters[index]);
                str = "&";
            }
          
            return uri.Result + stringBuilder.ToString();
        }
    }
}
