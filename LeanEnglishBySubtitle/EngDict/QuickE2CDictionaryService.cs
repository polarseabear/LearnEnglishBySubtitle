﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Studyzy.LeanEnglishBySubtitle.Helpers;

namespace Studyzy.LeanEnglishBySubtitle.EngDict
{
    public class QuickE2CDictionaryService : DictionaryService
    {
        public override string DictionaryName
        {
            get { return "英汉速查词典"; }
        }

        public override string Ld2FilePath
        {
            get { return "Quick E-C Dictionary.ld2"; }
        }
        public override Encoding MeanEncoding
        {
            get { return Encoding.Unicode; }
        }
        public override IList<string> GetCoreMeans(string xml)
        {
            var result = new List<string>();
           

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
