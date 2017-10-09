using System.Collections.Generic;

namespace MarkExcuseTactics
{
    public interface IExcuseXmlReader
    {
        List<Excuse> LoadFromFile(string fileName, List<Tactic> definedTactics);
    }
}