using System.Collections.Generic;
using System.Linq;

namespace ExcusesCoreLogic
{
    public class Excuse
    {
        public Excuse()
        {
            SentenceTactics = new Dictionary<int, List<Tactic>>();
        }

        private string _safeName;
        public string SafeName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_safeName))
                {
                    if (string.IsNullOrWhiteSpace(Name))
                    {
                        _safeName = ToString();
                    }
                    _safeName = Name;
                }

                return _safeName;
            }
        }
        public string Name { get; set; }
        public string ExcuseText { get; set; }
        public List<string> Sentences { get; set; }
        public Dictionary<int, List<Tactic>> SentenceTactics { get; set; }

        public Dictionary<Tactic, List<int>> GetTacticSentences()
        {
            var result = new Dictionary<Tactic, List<int>>();
            foreach (KeyValuePair<int, List<Tactic>> sentenceTactic in SentenceTactics)
            {
                foreach (Tactic tactic in sentenceTactic.Value)
                {
                    if (!result.ContainsKey(tactic))
                    {
                        result[tactic] = new List<int>();
                    }
                    result[tactic].Add(sentenceTactic.Key);
                }
            }

            return result;
        }

        public string SaveSentenceChangesInExcuseText()
        {
            ExcuseText = string.Join(" ", Sentences);
            return ExcuseText;
        } 

        public override string ToString() { return SafeName; }


        public void SaveSplittedSentence(int editedSentenceId, string[] splittedSentences)
        {
            Sentences[editedSentenceId] = splittedSentences[0];

            if (splittedSentences.Length > 1)
            {
                Sentences.InsertRange(editedSentenceId + 1, splittedSentences.Skip(1));

                for (int newSentIndex = Sentences.Count - 1; newSentIndex > editedSentenceId + splittedSentences.Length - 1; newSentIndex--)
                {
                    int oldSentIndex = newSentIndex - splittedSentences.Length + 1;
                    if (SentenceTactics.ContainsKey(oldSentIndex))
                    {
                        List<Tactic> tempTacticList = SentenceTactics[oldSentIndex];
                        SentenceTactics[newSentIndex] = tempTacticList;
                    }
                }

                if (SentenceTactics.ContainsKey(editedSentenceId))
                {
                    for (int splittedSentenceId = editedSentenceId + 1;
                        splittedSentenceId < splittedSentences.Length;
                        splittedSentenceId++)
                    {
                        //copy
                        SentenceTactics[splittedSentenceId] =
                            SentenceTactics[editedSentenceId].Select(t => t).ToList();
                    }
                }
            }

            SaveSentenceChangesInExcuseText();
        }
    }
}