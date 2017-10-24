using System.Collections.Generic;

namespace ExcusesCoreLogic
{
    public interface IExcuseXmlWriter
    {
        void WriteToFile(string fileName, List<Excuse> excuses, List<Tactic> definedTactics);
    }
}