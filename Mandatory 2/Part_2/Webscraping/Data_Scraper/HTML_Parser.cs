using System;
using System.Linq;
using System.Net.Http;
using HtmlAgilityPack;
using System.Threading.Tasks;

string url = "https://opensea.io/collection/boredapeyachtclub";

HtmlWeb web = new HtmlWeb();

HtmlDocument html_doc = web.Load(url);

string html_content = html_doc.DocumentNode.OuterHtml;

//Console.WriteLine(html_content);

string folder_name = "scraped_html";

string file_name = "Bored_Ape_Yacht_Club.html";

string file_path = Path.Combine(folder_name, file_name);

Console.WriteLine($"Saved the HTML to the following path: {file_path}");

Directory.CreateDirectory(folder_name);

html_doc.Save(file_path);