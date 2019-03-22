using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CrawlerDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            StartCrawlerAsync();
            Console.ReadLine();
        }

        private static async Task StartCrawlerAsync()
        {
            var url = "http://www.automobile.tn/neuf/bmw.3";
            var httpclient = new HttpClient();
            var html = await httpclient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var cars = new List<Car>();
            var divs =
                htmlDocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "")
                .Equals("article_new_car_article_last_modele")).ToList();
            foreach (var div in divs)
            {
                var car = new Car
                {
                    Model = div.Descendants("h2").FirstOrDefault().InnerText,
                    Price = div.Descendants("div").FirstOrDefault().InnerText,
                    Link = div.Descendants("a").FirstOrDefault().ChildAttributes("href").FirstOrDefault().Value,
                    ImageUrl = div.Descendants("img").FirstOrDefault().ChildAttributes("src").FirstOrDefault().Value
                };
                cars.Add(car);
            }
        }
    }
}