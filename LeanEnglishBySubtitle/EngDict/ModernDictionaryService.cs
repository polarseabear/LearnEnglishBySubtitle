﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Studyzy.LeanEnglishBySubtitle.Helpers;

namespace Studyzy.LeanEnglishBySubtitle.EngDict
{
    public  class ModernDictionaryService:DictionaryService
    {
        public override string DictionaryName
        {
            get { return "现代英汉综合大辞典"; }
        }

        public override string Ld2FilePath
        {
            get { return "Modern.ld2"; }
        }
        public override IList<string> GetCoreMeans(string xml)
        {
            var result = new List<string>();
            if (xml.IndexOf("<J D=") > 0)
            {
                xml = xml.Substring(0, xml.IndexOf("<J D="));
                //去掉继承用法和特殊用法的解释
            }

            foreach (Match match in regex.Matches(xml))
            {
                var val = match.Groups[1].Value;

                result.Add(detailRegex.Replace(val, ""));
            }
            return result;
        }
        private static Regex detailRegex = new Regex("<.*?/.*?>");
       
        private static Regex regex = new Regex("<Q>(.*?)</Q>");
    }
}
