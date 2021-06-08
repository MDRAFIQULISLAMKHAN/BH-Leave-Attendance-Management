using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.UI.WebControls;

namespace TW.Utility
{ 
    public class UtilityManager
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string FormatCSV(string input)
        {
            try
            {
                if (input == null)
                    return string.Empty;

                bool containsQuote = false;
                bool containsComma = false;
                int len = input.Length;
                for (int i = 0; i < len && (containsComma == false || containsQuote == false); i++)
                {
                    char ch = input[i];
                    if (ch == '"')
                        containsQuote = true;
                    else if (ch == ',')
                        containsComma = true;
                }

                if (containsQuote && containsComma)
                    input = input.Replace("\"", "\"\"");

                if (containsComma)
                    return "\"" + input + "\"";
                else
                    return input;
            }
            catch
            {
                throw;
            }
        }
        public static List<ListItem> GetPropertiesNameOfClass(object pObject)
        {
            Type myType = pObject.GetType();
            List<ListItem> propertyList = new List<ListItem>();
            if (pObject != null)
            {
                foreach (var prop in pObject.GetType().GetProperties())
                {
                    var propertyValue = prop.GetValue(pObject);

                    propertyList.Add(new ListItem(prop.Name, propertyValue != null ? propertyValue.ToString() : string.Empty));
                }
            }
            return propertyList;
        }

        /// <summary>
        ///     create a csv file, containing every properties of a model
        /// </summary>
        public static bool CreateCsv<T>(T t, string path)
        {
            var csv = new StringBuilder();
            List<ListItem> items = UtilityManager.GetPropertiesNameOfClass(t);
            using (var wstream = new StreamWriter(path))
            {
                foreach (var item in items)
                {
                    string newLine = string.Format("{0},{1}", item.Text, item.Value);
                    wstream.WriteLine(newLine);
                    wstream.Flush();
                }
                return true;
            }
        }
        public static List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {

                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }
        public static T DataReaderMap<T>(IDataReader dr)
        {
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
            }
            return obj;
        }

    }
}
