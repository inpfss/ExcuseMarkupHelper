using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhraseArticlesParser
{
    public class PhrasesParser
    {
        public IEnumerable<Zaholovok> Parse(string fileName)
        {
            int phraseCounter = 109001;
            string text = File.ReadAllText(fileName);
            string[] phrasesBlocks = text.Split(
                new[] { "NEW_PHRASE" }, StringSplitOptions.RemoveEmptyEntries);
            List<Zaholovok> phrases = new List<Zaholovok>();
            foreach (string phraseBlock in phrasesBlocks.Select(s => s.Trim()))
            {
                if (!string.IsNullOrWhiteSpace(phraseBlock))
                {
                    string[] phraseParts = phraseBlock.Split(
                        new[] { "END_TITLE" },
                        StringSplitOptions.RemoveEmptyEntries);

                    var phrase = new Zaholovok
                    {
                        HeadWordText = phraseParts[0].Trim(),
                        HeadWordId = phraseCounter++
                    };

                    List<Hnizdo> idioms = new List<Hnizdo>();
                    string[] idiomBlocks = phraseParts[1].Split(
                        new[] { "PHRASE_TEXT" },
                        StringSplitOptions.RemoveEmptyEntries);

                    foreach (string idiomBlock in idiomBlocks.Select(s => s.Trim()))
                    {
                        if (!string.IsNullOrWhiteSpace(idiomBlock))
                        {
                            Hnizdo hnizdo = ParseIdiom(idiomBlock);
                            idioms.Add(hnizdo);
                        }
                    }

                    phrase.Idioms = idioms;
                    phrases.Add(phrase);
                }
            }

            return phrases;
        }

        private Hnizdo ParseIdiom(string text)
        {
            text = text.Replace(Environment.NewLine, " ");

            string pattern =
                @"(?<number>\d+)\.?(?<proverb>.+?)(SOURCE_BEGIN(?<source>.*?)SOURCE_END)(?<remark>.*)";

            string pattern2 =
              @"(?<number>\d+)\.?(?<proverb>.+?)(?<remark>.*)";

            Match match = Regex.Match(text, pattern);
            string remark;
            string number;
            string proverbText;
            string source = null;
            if (match.Success)
            {
                number = match.Groups["number"].Value;
                proverbText = (match.Groups["proverb"].Value);
                source = (match.Groups["source"].Value);
                remark = (match.Groups["remark"].Value);
            }
            else
            {
                Debugger.Break();
                match = Regex.Match(text, pattern2);

                number = match.Groups["number"].Value;
                proverbText = (match.Groups["proverb"].Value);
                remark = (match.Groups["remark"].Value);
            }

            Hnizdo hnizdo = new Hnizdo()
            {
                NestNumber = int.Parse(number),
                Remark = remark,
                Prypovidka = new Prypovidka()
                {
                    ProverbText = proverbText,
                    ProverbSource = source
                }
            };

            return hnizdo;
        }
    }
}
