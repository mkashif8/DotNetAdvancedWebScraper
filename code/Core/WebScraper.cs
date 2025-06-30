using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace SharpScrape.Core
{
    public class WebScraper
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly int _maxRetries;
        private readonly int _concurrencyLevel;

        public WebScraper(int maxRetries = 3, int concurrencyLevel = 5)
        {
            _maxRetries = maxRetries;
            _concurrencyLevel = concurrencyLevel;
        }

        public async Task<List<string>> ScrapeAsync(List<string> urls, string xpathSelector)
        {
            var results = new List<string>();
            var semaphore = new SemaphoreSlim(_concurrencyLevel);

            var tasks = new List<Task>();

            foreach (var url in urls)
            {
                await semaphore.WaitAsync();

                tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        var content = await RetryAsync(() => FetchHtmlAsync(url));
                        var data = ParseHtml(content, xpathSelector);
                        lock (results) results.AddRange(data);
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }));
            }

            await Task.WhenAll(tasks);
            return results;
        }

        private async Task<string> FetchHtmlAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private List<string> ParseHtml(string html, string xpath)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var nodes = doc.DocumentNode.SelectNodes(xpath);
            var output = new List<string>();

            if (nodes != null)
            {
                foreach (var node in nodes)
                    output.Add(node.InnerText.Trim());
            }

            return output;
        }

        private async Task<string> RetryAsync(Func<Task<string>> action)
        {
            int retryCount = 0;
            while (true)
            {
                try
                {
                    return await action();
                }
                catch (Exception ex) when (retryCount < _maxRetries)
                {
                    retryCount++;
                    Console.WriteLine($"Retrying ({retryCount}) after error: {ex.Message}");
                    await Task.Delay(1000 * retryCount);
                }
            }
        }
    }
}