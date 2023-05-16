using System;
using System.Linq;
using System.Net.Http;
using HtmlAgilityPack;
using System.Threading.Tasks;

string url = "https://www.wowhead.com/news";

string folder_name = "scraped_html";

ScrapeSaveHtml(url, folder_name);

/*
* Functions
*/

// Function to scrape HTML content from a provided URL and save it to html file in a specified folder
void ScrapeSaveHtml(string url, string folder_name) {

    HtmlWeb web = new HtmlWeb();

    HtmlDocument html_doc = web.Load(url);

    string html_content = html_doc.DocumentNode.OuterHtml;

    //Console.WriteLine(html_content);

    string website_name = GetWebsiteName(url);

    string file_name = $"{website_name}.html";

    string file_path = Path.Combine(folder_name, file_name);

    Console.WriteLine($"Saved {website_name}.html to the following path: {file_path}");

    Directory.CreateDirectory(folder_name);

    html_doc.Save(file_path);
}

string GetWebsiteName(string url) {

    Uri uri = new Uri(url);

    string domain = uri.Host;

    string[] domain_parts = domain.Split('.');

    //Console.WriteLine(domainParts[1]);

    string website_name = domain_parts[1];

    return website_name;
}