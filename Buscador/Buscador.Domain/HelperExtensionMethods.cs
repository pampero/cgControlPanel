using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Buscador.Domain.com.clarin.entities;

namespace Buscador.Domain
{
    public static class HelperExtensionMethods
    {
        public static string ReplaceUrlInvalidChars(this string cadena)
        {
            return cadena.Replace(" ", "-")
                         .Replace("--", "-");
        }

        public static IEnumerable<string> SplitIntoSentencesOfSize(this string text, int partSize)
        {
            if (text.Length <= 30)
                return new List<string> {text};

            var delimiterString = @" ,.:;~!@#$%^&*(){}\/[]<>|'?؟-_+،""=";

            var separators = new List<char>();
            foreach (char ch in text.ToCharArray().ToList<char>())
            {
                if (char.IsSeparator(ch) || Convert.ToInt32(ch) > 2500)
                    separators.Add(ch);
            }

            delimiterString += new string(separators.ToArray());

            var delimiter = delimiterString.ToCharArray();

            string[] words = null;
            if (!string.IsNullOrEmpty(text))
                words = text.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length <= partSize)
                return new List<string> { text };

            var newWords = new List<string>();
            var first = true;

            for (var i = 0; i <= (words.Count() / partSize); i++)
            {
                if (first)
                {
                    newWords.Add(string.Join(" ", words, 0, partSize));
                    first = false;
                }
                else
                {
                    if (i * partSize <= words.Length - partSize)
                        newWords.Add(string.Join(" ", words, i * partSize, partSize));
                    else
                    {
                        var dif = (words.Length - partSize) - ((i - 1) * partSize);
                        newWords.Add(string.Join(" ", words, i * partSize, dif));
                    }
                }
            }
            return newWords.ToArray();
        }

        //public static string MemberName<T>(this Expression<Func<T,string>> query)
        //{
        //    return ((SolrNet.Attributes.SolrFieldAttribute)((MemberExpression)((MethodCallExpression) query.Body).Object).Member.GetCustomAttributes(false)[0]).FieldName;
        //}

        //public static string MemberName<T>(this Expression<Func<T, int>> query)
        //{
        //    return ((SolrNet.Attributes.SolrFieldAttribute)(((System.Linq.Expressions.MemberExpression)(((System.Linq.Expressions.LambdaExpression)(query)).Body)).Member).GetCustomAttributes(false)[0]).FieldName;
        //    //return ((SolrNet.Attributes.SolrFieldAttribute)((MemberExpression)((MethodCallExpression)query.Body).Object).Member.GetCustomAttributes(false)[0]).FieldName;
        //}

        public static string MemberName<T>(this Expression<Func<T, object>> query)
        {
            if (query.Body is UnaryExpression)
                return (((MemberExpression)(((UnaryExpression)(query.Body)).Operand)).Member).Name;
            return (((MemberExpression)(query.Body)).Member).Name;
        }

        public static PropertyInfo ToPropertyInfo<T>(this Expression<Func<T, int>> expression)
        {
            var member = ((MemberExpression) (expression.Body));
            return member.Member as PropertyInfo;
        }

        public static PropertyInfo ToPropertyInfo<T>(this Expression<Func<T, string>> expression)
        {
            var member = ((MemberExpression)(expression.Body));
            return member.Member as PropertyInfo;
        }

        public static T As<T>(this string cadena) where T : struct
        {
            var paramTypes = new[]
                                 {
                                     typeof (string),
                                     typeof (T).MakeByRefType()
                                 };

            var method = typeof(T).GetMethod("TryParse", paramTypes);
            var parameters = new Object[] { cadena, null };
            if (method != null)
            {
                var val = (bool)method.Invoke(typeof(T), parameters);
                if (val)
                    return (T)parameters[1];
            }
            return default(T);
        }

        public static string RemoveWhiteSpace(string str)
        {
            str = str.ToLower();
            var words = str.Split(' ');
            string result = "";
            if (words.Count() > 1)
            {
                foreach (var word in words)
                {
                    result += word;
                }
                return RemoveAccentsWithRegEx(result);
            }
            str = RemoveAccentsWithRegEx(str);
            return str;
        }

        public static string RemoveAccentsWithRegEx(string str)
        {
            var rega = new Regex("[á]", RegexOptions.Compiled);
            var rege = new Regex("[é]", RegexOptions.Compiled);
            var regi = new Regex("[í]", RegexOptions.Compiled);
            var rego = new Regex("[ó]", RegexOptions.Compiled);
            var regu = new Regex("[ú]", RegexOptions.Compiled);
            str = rega.Replace(str, "a");
            str = rege.Replace(str, "e");
            str = regi.Replace(str, "i");
            str = rego.Replace(str, "o");
            str = regu.Replace(str, "u");
            return str;
        }
    }
}
