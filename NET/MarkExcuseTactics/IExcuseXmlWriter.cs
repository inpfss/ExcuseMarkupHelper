using System.Collections.Generic;

namespace MarkExcuseTactics
{
    public interface IExcuseXmlWriter
    {
        void WriteToFile(string fileName, List<Excuse> excuses);
    }
}