using SimpleWebScraper.Builders;
using SimpleWebScraper.Data;
using SimpleWebScraper.Workers;
using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace SimpleWebScraper
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                using (WebClient client = new WebClient())
                {
                    string content = client.DownloadString("https://boston.craigslist.org/d/cars-trucks/search/cta");
                    Console.WriteLine(content);

                    ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder()
                        .withData(content)
                        .withRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"">(.*?)</a>")
                        .withRegexOption(RegexOptions.ExplicitCapture)
                        .withPart(new ScrapeCriteriaPartBuilder()
                            .withRegex(@">(.*?)</a>")
                            .withRegexOption(RegexOptions.Singleline)
                            .Build())
                        .withPart(new ScrapeCriteriaPartBuilder()
                            .withRegex(@"href=\""(.*?)\""")
                            .withRegexOption(RegexOptions.Singleline)
                            .Build())
                        .Build();

                    Scraper scraper = new Scraper();
                    var scrapedElements = scraper.Scrape(scrapeCriteria);
                    if (scrapedElements.Any())
                    {
                        foreach (var scrapedElement in scrapedElements)
                        {
                            Console.WriteLine(scrapedElement);
                        }
                    }
                    else
                    {
                        Console.WriteLine("There are no match");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
