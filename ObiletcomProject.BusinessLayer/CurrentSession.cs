using System.Web;

namespace ObiletcomProject.BusinessLayer
{
    public class CurrentSession
    {
        public static object User
        {
            get
            {
                return Get("sessionInfo");
            }
        }

        public static void Set(string key, string value)
        {
            HttpContext.Current.Session[key] = value;
        }

        public static object Get(string key)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                return HttpContext.Current.Session[key];
            }
            return default(object);
        }

        public static void Remove(string key)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                HttpContext.Current.Session.Remove(key);
            }
        }

        public static void Clear()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}