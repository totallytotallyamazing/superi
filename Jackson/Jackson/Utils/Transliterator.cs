using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Jackson.Utils
{
    public static class Transliterator
    {
        private static Dictionary<char, string> m_replacementRules;
        private static StringBuilder m_builder = new StringBuilder();

        static Transliterator()
        {
            InitializeReplacementRules();
        }

        public static string Transliterate(string str)
        {
            m_builder.Clear();

            foreach (char ch in str.ToCharArray())
            {
                string transCh = ch.ToString();

                char loweredCh = char.ToLower(ch);

                if (m_replacementRules.ContainsKey(loweredCh))
                {
                    transCh = m_replacementRules[loweredCh];

                    if (char.IsUpper(ch) && transCh != "")
                    {
                        transCh = transCh.Replace(transCh[0], char.ToUpper(transCh[0]));
                    }
                }

                m_builder.Append(transCh);
            }

            return m_builder.ToString();
        }

        private static void InitializeReplacementRules()
        {
            m_replacementRules = new Dictionary<char, string>();
            m_replacementRules['а'] = "a";
            m_replacementRules['б'] = "b";
            m_replacementRules['в'] = "v";
            m_replacementRules['г'] = "g";
            m_replacementRules['д'] = "d";
            m_replacementRules['е'] = "e";
            m_replacementRules['ё'] = "yo";
            m_replacementRules['ж'] = "zh";
            m_replacementRules['з'] = "z";
            m_replacementRules['и'] = "i";
            m_replacementRules['й'] = "j";
            m_replacementRules['к'] = "k";
            m_replacementRules['л'] = "l";
            m_replacementRules['м'] = "m";
            m_replacementRules['н'] = "n";
            m_replacementRules['о'] = "o";
            m_replacementRules['п'] = "p";
            m_replacementRules['р'] = "r";
            m_replacementRules['с'] = "s";
            m_replacementRules['т'] = "t";
            m_replacementRules['у'] = "u";
            m_replacementRules['ф'] = "f";
            m_replacementRules['х'] = "h";
            m_replacementRules['ц'] = "c";
            m_replacementRules['ч'] = "ch";
            m_replacementRules['ш'] = "sh";
            m_replacementRules['щ'] = "sh";
            m_replacementRules['ь'] = "";
            m_replacementRules['ы'] = "y";
            m_replacementRules['ъ'] = "";
            m_replacementRules['э'] = "e";
            m_replacementRules['ю'] = "yu";
            m_replacementRules['я'] = "ya";
            m_replacementRules[' '] = "-";
            m_replacementRules['/'] = "";
            m_replacementRules['\\'] = "";
            m_replacementRules['*'] = "";
            m_replacementRules[':'] = "";
            m_replacementRules['"'] = "";
            m_replacementRules['>'] = "";
            m_replacementRules['<'] = "";
            m_replacementRules['|'] = "";
        }
    }
}