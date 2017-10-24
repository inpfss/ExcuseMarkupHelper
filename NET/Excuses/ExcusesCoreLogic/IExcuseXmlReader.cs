using System.Collections.Generic;

namespace ExcusesCoreLogic
{
    public interface IExcuseXmlReader
    {
        List<Excuse> LoadFromFile(string fileName, List<Tactic> definedTactics);
    }
}