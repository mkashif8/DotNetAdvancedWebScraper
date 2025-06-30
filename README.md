#  SharpScrape 🕷️

**An advanced .NET Web Scraper with support for multiple targets, scheduling, smart retries, and export to JSON/CSV — built with C#, HtmlAgilityPack, and HttpClient.**

## 🚀 Features

- 🔍 Scrape multiple websites or pages in parallel
- 🗓️ Schedule scraping tasks using built-in timers
- 🔁 Auto retry with exponential backoff
- 🧠 Smart pattern matching using Regex and XPath
- 💾 Export data to JSON and CSV formats
- ⚙️ Modular architecture with clear separation (Scraper, Parser, Exporter)

## 🛠️ Tech Stack

- **Language:** C# (.NET 8 or .NET Core 7+)
- **Libraries:** HtmlAgilityPack, Newtonsoft.Json, CsvHelper
- **Tools:** HttpClient, Regex, LINQ, Task Scheduler

## 📂 Project Structure

```
DotNetAdvancedWebScraper/
├── Scraper/
│   ├── WebScraper.cs
│   ├── ScraperConfig.cs
│   └── RetryPolicy.cs
├── Parser/
│   ├── HtmlParser.cs
│   └── XPathPatterns.cs
├── Exporter/
│   ├── JsonExporter.cs
│   └── CsvExporter.cs
├── Scheduler/
│   └── TaskScheduler.cs
├── Program.cs
└── README.md
```

## 📸 Screenshots

### 🎯 Dashboard View
![Dashboard Screenshot](assets/scraper_dashboard.png)

### 🧾 Configuration UI
![Config Screenshot](assets/scraper_config.png)

### 📤 Export Result Preview
![Export Screenshot](assets/scraper_export.png)

## 📬 Need Custom Scraper?

Hire me to build scrapers tailored to your data needs — fast, reliable, and maintainable.

- 💼 [Upwork Profile](https://www.upwork.com/freelancers/~0101659ba9fa3c1f21)

---

**⭐ Star this repo for more .NET utilities and tools!**
