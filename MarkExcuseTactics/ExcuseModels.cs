using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkExcuseTactics
{
    class Tactic
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Excuse
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
        public string OriginalExcuseText { get; set; }
        public string[] Sentences { get; set; }
        public Dictionary<int, List<Tactic>> SentenceTactics { get; set; }
        public override string ToString()
        {
            return OriginalExcuseText;
        }
    }
}