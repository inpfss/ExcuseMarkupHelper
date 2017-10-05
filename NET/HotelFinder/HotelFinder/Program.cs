using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace HotelFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            if (args.Length == 0)
            {
                args = new string[]
                {
                    "кондиціонер",
                    "автостоянка",
                    "ресторан",
                };
            }

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = args[i].ToLower();
            }

            Console.WriteLine("Criteria for looking to:");
            Console.WriteLine( string.Join(Environment.NewLine, args));

            Console.WriteLine();
            Console.WriteLine("Loading hotel list...");
            string Url = "http://ua.dorogovkaz.com/otdyh_na_chernom_more.php";
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(Url);

            List<HtmlNode> hotelsHeaders = doc.DocumentNode.Descendants("div")
                .Where(n => n.Attributes.Any(a => a.Name == "class" && a.Value == "art-postmetadataheader"))
                .ToList();

            List<string> hotelUrls = new List<string>();

            foreach (HtmlNode hotelHeader in hotelsHeaders)
            {
                try
                {
                    string hotelLink = hotelHeader.Descendants("a")
                        .FirstOrDefault()
                        ?.GetAttributeValue("href", null);
                    if (string.IsNullOrWhiteSpace(hotelLink))
                    {
                        continue;
                    }

                    Console.WriteLine($"Handling hotel {hotelLink} ...");
                    string hotelUrl = "http://ua.dorogovkaz.com/" + hotelLink;
                    HtmlWeb hotelPage = new HtmlWeb();
                    HtmlDocument hotelDoc = hotelPage.Load(hotelUrl);
                    string hotelText = hotelDoc.DocumentNode.InnerText.ToLower();

                    bool match = args.All(k => hotelText.Contains(k));
                    if (match)
                    {
                        Console.WriteLine("Hotel match criteria))");
                        hotelUrls.Add(hotelUrl);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error.");
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Found {hotelUrls.Count} hotels.");
            Console.WriteLine("Writing links to file...");
            string hotelLinks = string.Join(Environment.NewLine, hotelUrls);
            File.WriteAllText("FoundHotels.txt", hotelLinks);
            Console.WriteLine("Done.");
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
