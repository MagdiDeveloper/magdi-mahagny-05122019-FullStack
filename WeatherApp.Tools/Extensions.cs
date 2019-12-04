using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Tools.Logger;

namespace WeatherApp.Tools
{
    public static class Extensions
    {
        public static string GetString(this object field)
        {
            string defaultValue = string.Empty;
            return Extensions.GetString(field, defaultValue);
        }

        public static string GetString(this object field, string defaultValue)
        {
            string value = defaultValue;
            if (field != null)
                value = field.ToString();
            return value;
        }
        public static int GetInt32(this object field)
        {
            int defaultValue = 0;
            return Extensions.GetInt32(field, defaultValue);
        }

        public static int GetInt32(this object field, int defaultValue)
        {
            int value = defaultValue;
            if (field != null)
            {
                Int32.TryParse(field.ToString(), out value);
            }
            return value;
        }
        public static T GetWebConfigValue<T>(this string key)
        {
            string value = ConfigurationManager.AppSettings[key];
            if (value != null)
            {
                return (T)Convert.ChangeType(ConfigurationManager.AppSettings[key], typeof(T));
            }
            else
            {

                return default(T);
            }
        }
        public static T GetDataFromCache<T>(this T current, string key) where T : new()
        {
            if (HttpRuntime.Cache == null)
                return new T();
            current = (T)HttpRuntime.Cache.Get(key);
            return current;
        }
        public static T SetDataToCache<T>(this T current, string key) where T : new()
        {
            return SetDataToCache(current, key, "Cache.Time.PreHoure".GetWebConfigValue<float>());

        }
        public static T SetDataToCache<T>(this T current, string key, float cacheTimePreHoure) where T : new()
        {
            try
            {
                if (current == null)
                    throw new NoNullAllowedException();

                if (HttpRuntime.Cache == null)
                    return current;
                if (HttpRuntime.Cache.Get(key) == null)
                    HttpRuntime.Cache.Add(key, current, null, DateTime.Now.AddHours(cacheTimePreHoure), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
                else
                    HttpRuntime.Cache.Insert(key, current, null, DateTime.Now.AddHours(cacheTimePreHoure), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
                return current;
            }
            catch (NoNullAllowedException nullEx)
            {
                Logger.Error("you tyring to set a nullable object to cache! error message :: " + nullEx.Message);

            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            return new T();
        }

        public static T ConvertDataRowToItem<T>(this T item, DataRow dr)
    where T : new()
        {
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.IgnoreCase;

            foreach (DataColumn c in dr.Table.Columns)
            {

                // find the property for the column
                PropertyInfo p = item.GetType().GetProperty(c.ColumnName, flags);

                // if exists, set the value
                if (p != null && dr[c] != DBNull.Value)
                {
                    if (p.PropertyType == typeof(Int32))
                        p.SetValue(item, dr[c].GetInt32(), null);
                    else if (p.PropertyType == typeof(Nullable<int>))
                        p.SetValue(item, (int?)dr[c], null);
                    else if (p.PropertyType == typeof(Nullable<decimal>))
                        p.SetValue(item, (decimal?)dr[c], null);
                    else if (p.PropertyType == typeof(Nullable<double>))
                        p.SetValue(item, (double?)dr[c], null);
                    else if (p.PropertyType == typeof(DateTime))
                    {
                        p.SetValue(item, ((DateTime)dr[c]), null);
                    }
                    else if (p.PropertyType == typeof(DateTime?))
                    {
                        if (((DateTime?)dr[c]).HasValue)
                        {
                            p.SetValue(item, ((DateTime?)dr[c]).HasValue ? ((DateTime?)dr[c]).Value : (DateTime?)dr[c], null);
                        }
                        else
                        {
                            p.SetValue(item, dr[c], null);
                        }
                    }
                    else
                        p.SetValue(item, dr[c], null);
                }

            }
            return item;
        }

    }
}
