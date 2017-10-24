using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace ExcusesCoreLogic
{
    public class ExcusesXmlReader : IExcuseXmlReader
    {
        public List<Excuse> LoadFromFile(string fileName, List<Tactic> definedTactics)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            var excuses = new List<Excuse>();
            foreach (XmlNode node in doc.DocumentElement.ChildNodes.Cast<XmlNode>())
            {
                IEnumerable<XmlNode> children = node.ChildNodes.Cast<XmlNode>();
                string value = children.FirstOrDefault(n => n.Name == "id")?.InnerXml;
                if (value != null)
                {
                    var excuse = new Excuse()
                    {
                        Name = value.Trim(),
                        ExcuseText = children.FirstOrDefault(n => n.Name == "text")?
                                .InnerXml?.Trim(),
                        Sentences = new List<string>()
                    };

                    List<XmlNode> sentencesNodes = children.FirstOrDefault(n => n.Name == "sentences")
                        .ChildNodes.Cast<XmlNode>().Where(n => n.Name == "sentence").ToList();

                    for (var i = 0; i < sentencesNodes.Count; i++)
                    {
                        XmlNode sentenceNode = sentencesNodes[i];
                        if (sentenceNode == null)
                        {
                            continue;
                        }

                        string sentenceText = sentencesNodes[i]
                            .ChildNodes.Cast<XmlNode>()
                            .FirstOrDefault(n => n.Name == "text")?.InnerXml.Trim();
                        if (string.IsNullOrWhiteSpace(sentenceText))
                        {
                            continue;
                        }

                        excuse.Sentences.Add(sentenceText);
                        XmlNode tacticsNode = sentenceNode.ChildNodes.Cast<XmlNode>().FirstOrDefault(n => n.Name == "tactics");
                        if (tacticsNode != null)
                        {
                            int x;
                            List<int> tacticsIds = tacticsNode
                                .ChildNodes.Cast<XmlNode>()
                                .Where(n => n.Name == "tacticId")
                                .Select(tactic => tactic.InnerXml?.Trim())
                                .Where(tId => !string.IsNullOrWhiteSpace(tId) && int.TryParse(tId, out x))
                                .Select(int.Parse)
                                .ToList();

                            List<Tactic> tactics = tacticsIds.Select(tId =>
                                definedTactics.FirstOrDefault(t => t.Id == tId))
                                .ToList();

                            excuse.SentenceTactics[excuse.Sentences.Count - 1] = tactics;
                        }
                    }

                    excuses.Add(excuse);
                }
            }
            return excuses;
        }
    }
}
