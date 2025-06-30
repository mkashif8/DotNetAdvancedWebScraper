using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SharpScrape.Core;

class Program
{
    static async Task Main(string[] args)
    {
        var urls = new List<string>
        {
            "https://example.com",
            "https://example.org"
        };

        var xpath = "//h1";

        var scraper = new WebScraper(maxRetries: 3, concurrencyLevel: 3);
        var results = await scraper.ScrapeAsync(urls, xpath);

        Console.WriteLine("\nScraped Results:");
        foreach (var result in results)
        {
            Console.WriteLine($"- {result}");
        }

        var exportPath = "scraped_output.txt";
        await System.IO.File.WriteAllLinesAsync(exportPath, results);
        Console.WriteLine($"
Results exported to {exportPath}");
    }
}