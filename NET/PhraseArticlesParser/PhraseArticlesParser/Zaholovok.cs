using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhraseArticlesParser
{
    public class Zaholovok
    {
        public int HeadWordId { get; set; }
        public string HeadWordText { get; set; }
        public List<Hnizdo> Idioms { get; set; }
    }

    public class Hnizdo
    {
        public int NestNumber { get; set; }
        public string Remark { get; set; }
        public Prypovidka Prypovidka { get; set; }
    }

    public class Prypovidka
    {
        public string ProverbText { get; set; }
        public string ProverbSource { get; set; }
    }
}
