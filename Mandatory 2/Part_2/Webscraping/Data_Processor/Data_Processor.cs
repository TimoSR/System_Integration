using System;
using System.Linq;
using System.Net.Http;
using HtmlAgilityPack;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

string folder_name = "scraped_html";
string file = "wowhead.html";
string project_directory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
//Console.WriteLine(projectDirectory);

string file_path = Path.Combine(project_directory, folder_name, file);
string html_content = File.ReadAllText(file_path);
//Console.WriteLine(htmlContent);

HtmlDocument html_doc = new HtmlDocument();
html_doc.LoadHtml(html_content);

var news_list_cards = html_doc.DocumentNode.Descendants("div")
    .Where(node => node.GetAttributeValue("class", "")
        .Equals("news-list-card")).ToList();

foreach (var news_card in news_list_cards)
{
    var newsTitle = news_card.Descendants("h3")
                .FirstOrDefault()?.InnerText.Trim();

    var newsLink = news_card .Descendants("a")
        .FirstOrDefault()?.GetAttributeValue("href", "");

    var newsContent = news_card .Descendants("div")
        .FirstOrDefault(node => node.GetAttributeValue("class", "")
        .Equals("news-list-card-content-body"))?.InnerText.Trim();

    var newsAuthorAndDate = news_card .Descendants("span")
        .FirstOrDefault(node => node.GetAttributeValue("class", "")
        .Equals("news-list-card-content-footer-author"))?.InnerText.Trim();

    Console.WriteLine($"Title: {newsTitle}");
    Console.WriteLine($"Link: {newsLink}");
    Console.WriteLine($"Content: {newsContent}");
    Console.WriteLine($"Author and Date: {newsAuthorAndDate}");
    Console.WriteLine("------------------------------");
}