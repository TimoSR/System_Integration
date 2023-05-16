using System;
using System.Linq;
using System.Net.Http;
using HtmlAgilityPack;
using System.Threading.Tasks;

string url = "https://www.wowhead.com/news";

htmlParser(url);

void htmlParser(string url) {

    HtmlWeb web = new HtmlWeb();

    HtmlDocument html_doc = web.Load(url);

    string html_content = html_doc.DocumentNode.OuterHtml;

    //Console.WriteLine(html_content);

    string website_name = getWebsiteName(url);

    string folder_name = "scraped_html";

    string file_name = $"{website_name}.html";

    string file_path = Path.Combine(folder_name, file_name);

    Console.WriteLine($"Saved {website_name} HTML to the following path: {file_path}");

    Directory.CreateDirectory(folder_name);

    html_doc.Save(file_path);
}

string getWebsiteName(string url) {

    Uri uri = new Uri(url);

    string domain = uri.Host;

    string[] domain_parts = domain.Split('.');

    //Console.WriteLine(domainParts[1]);

    string website_name = domain_parts[1];

    return website_name;
}