using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    class Translit
    {
        static Dictionary<string, string> dictionaryChar = new Dictionary<string, string>()
        {
                {"а","a"},
                {"б","b"},
                {"в","v"},
                {"г","g"},
                {"д","d"},
                {"е","e"},
                {"ё","yo"},
                {"ж","zh"},
                {"з","z"},
                {"и","i"},
                {"й","y"},
                {"к","k"},
                {"л","l"},
                {"м","m"},
                {"н","n"},
                {"о","o"},
                {"п","p"},
                {"р","r"},
                {"с","s"},
                {"т","t"},
                {"у","u"},
                {"ф","f"},
                {"х","h"},
                {"ц","ts"},
                {"ч","ch"},
                {"ш","sh"},
                {"щ","sch"},
                {"ъ","'"},
                {"ы","yi"},
                {"ь",""},
                {"э","e"},
                {"ю","yu"},
                {"я","ya"}
        };
        public static string TranslitString(string source)
        {
            source = source.ToLower();
            string result = "";
            foreach (var ch in source)
            {
                string ss = "";
                if (dictionaryChar.TryGetValue(ch.ToString(), out ss))
                {
                    result += ss;
                }
                else result += ch;
            }
            return result.ToUpper();
        }
    }
}
