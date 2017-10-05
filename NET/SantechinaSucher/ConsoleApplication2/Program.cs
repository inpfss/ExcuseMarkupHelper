using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;

namespace ConsoleApplication2
{
    class DushOptions
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Size { get; set; }
        public string Glass { get; set; }
        public string GlassType { get; set; }
        public string Features { get; set; }
    }

    class Program
    {
        private static Func<HtmlDocument, string> getName = doc =>
        {
            return
                doc
                .DocumentNode
                .Descendants("h2")
                .FirstOrDefault(n => n.Attributes.Any(a => a.Name == "class" && a.Value == "detail_h2"))
                ?.InnerText;
        };

        static Func<HtmlDocument, string> getSize = doc =>
        {
            return
                  doc
                 .DocumentNode
                 .Descendants("tr")
                 .Where(trNode => trNode.Descendants("td").First().InnerText == "Розмір")
                 .Select(trNode => trNode.Descendants("td").Last().InnerText.Trim())
                 .FirstOrDefault();
        };

        static Func<HtmlDocument, string> getGlassType = doc =>
        {
            return
                  doc
                 .DocumentNode
                 .Descendants("tr")
                 .Where(trNode => trNode.Descendants("td").First().InnerText == "Скло")
                 .Select(trNode => trNode.Descendants("td").Last().InnerText.Trim())
                 .FirstOrDefault();
        };

        static Func<HtmlDocument, string> getGlassDescription = doc =>
        {
            return
             doc
                .DocumentNode
                .Descendants("tr")
                .Where(trNode => trNode.Descendants("td").First().InnerText == "Колір скла")
                .Select(trNode => trNode.Descendants("td").Last().InnerText.Trim())
                .FirstOrDefault();
        };


        static Func<HtmlDocument, string> getBoxFeatures = doc =>
        {
            return
              HttpUtility.HtmlDecode(doc
                .DocumentNode
                .Descendants("div")
                .Where(div => div.Attributes.Any(a => a.Name == "class" && a.Value == "description") &&
                    div.Descendants("p").Count() > 1)
                .Select(div => div.Descendants("p").Last().InnerText.Trim())
                .FirstOrDefault());
        };

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                args = new[]
                {
                 "масаж спини",
                 "масаж ніг",
                };
            }

            Thread.CurrentThread.CurrentCulture = new CultureInfo("uk-UA");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("uk-UA");

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = args[i].ToUpper();
            }

            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            List<DushOptions> dushes = new List<DushOptions>();
            List<string> sizes = new List<string>();
            List<Tuple<string, string>> glassDescriptions = new List<Tuple<string, string>>();
            List<string> glassTypes = new List<string>();
            List<string> dushUrls = new List<string>();

            for (int pageId = 1; pageId <= 2; pageId++)
            {
                string Url = $"http://santehnika.lviv.ua/catalog/206?page={pageId}";
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(Url);

                List<HtmlNode> dushItems = doc.DocumentNode.Descendants("div")
                      .Where(n => n.Attributes.Any(a => a.Name == "class" && a.Value.Contains("category_item one-four inl vtop")))
                        .ToList();

                foreach (HtmlNode hotelHeader in dushItems)
                {
                    try
                    {
                        var dushOptions = new DushOptions();

                        string dushUrl = hotelHeader.Descendants("a")
                            .FirstOrDefault()
                            ?.GetAttributeValue("href", null);
                        if (string.IsNullOrWhiteSpace(dushUrl))
                        {
                            continue;
                        }

                        dushOptions.Url = dushUrl;

                        HtmlWeb dushPage = new HtmlWeb();

                        HtmlDocument dushDoc = dushPage.Load(dushUrl);
                        string dushSizes = getSize(dushDoc);
                        sizes.Add(dushSizes);
                        dushOptions.Size = dushSizes;

                        string dushName = getName(dushDoc);
                        string glassDescription = getGlassDescription(dushDoc);
                        glassDescriptions.Add(new Tuple<string, string>(glassDescription, dushUrl));
                        dushOptions.Name = dushName;
                        dushOptions.Glass = glassDescription;

                        string glassType = getGlassType(dushDoc);
                        glassTypes.Add(glassType);
                        dushOptions.GlassType = glassType;

                        string boxFeatures = getBoxFeatures(dushDoc)?.ToUpper();
                        dushOptions.Features = boxFeatures;

                        dushes.Add(dushOptions);

                        //if (boxFeatures != null && args.All(feature => boxFeatures.Contains(feature)))
                        //{
                        //    if (dushDoc.DocumentNode.InnerText.ToLower().Contains("мат"))
                        //    {
                        //        dushUrls.Add(dushUrl);

                        //        Console.WriteLine(dushName);
                        //        Console.WriteLine(
                        //            $"розмір: {dushSizes};\nтип скла: {glassType};\nколір скла: {glassDescription};\nфункції: {boxFeatures}");
                        //        Console.WriteLine();
                        //        Console.WriteLine(new string('*', 30));
                        //    }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error.");
                    }
                }
            }

            /*  Console.WriteLine();
              Console.WriteLine($"Знайдено {dushUrls.Count} гідробоксів.");

              Console.WriteLine();
              Console.WriteLine("Всі розміри:");
              sizes.Distinct().OrderBy(s => s).ToList().ForEach(Console.WriteLine);

              Console.WriteLine();
              Console.WriteLine("Всі типи скла гідробоксів:");
              glassTypes.Distinct().OrderBy(s => s).ToList().ForEach(Console.WriteLine);

              Console.WriteLine();
              Console.WriteLine("Всі кольори гідробоксів:");
              glassDescriptions.Distinct(new Comp()).OrderBy(s => s).ToList().ForEach(Console.WriteLine);
              */
            var foundedDushes = dushes.Where(x => x.Glass == "матове" || x.GlassType == "матове").ToList();

            foreach (DushOptions dushOptionse in foundedDushes)
            {
                Console.WriteLine(dushOptionse.Name);
                Console.WriteLine(dushOptionse.Url);
                Console.WriteLine(dushOptionse.Features);
                Console.WriteLine(dushOptionse.Size);
                Console.WriteLine(dushOptionse.Glass);
                Console.WriteLine(dushOptionse.GlassType);
            }

            File.WriteAllText(
                "matchedDhushes.txt",
                string.Join(Environment.NewLine, foundedDushes.Select(x => x.Url).ToList())
             );

            Console.ReadLine();
        }

        class Comp : IEqualityComparer<Tuple<String, String>>
        {
            public bool Equals(Tuple<string, string> x, Tuple<string, string> y)
            {
                return GetHashCode(x) == GetHashCode(y);
            }

            public int GetHashCode(Tuple<string, string> obj) => obj?.Item1?.GetHashCode() ?? 0;
        }
    }
}
