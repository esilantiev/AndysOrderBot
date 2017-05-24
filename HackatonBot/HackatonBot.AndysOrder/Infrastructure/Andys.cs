using System;
using System.Collections.Generic;
using System.Linq;
using HackatonBot.Dal.Entity;
using System.Net.Http;
using HtmlAgilityPack;

namespace HackatonBot.AndysOrder.Infrastructure
{
    public class Andys
    {
        public static IList<Pizza> GetPizzas()
        {
            string Url = "http://www.andys.md/ro/pages/menu/8/";
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(Url);
            var pizzas = doc.DocumentNode.SelectNodes("//div[@class='ands_ctg_content ands_no_space']/div");
            var testItem = pizzas.FirstOrDefault();
            var items = pizzas.Select(x => new Pizza(
             x.ChildNodes.First(w => w.Name == "h5").InnerText.ToString(),
             Convert.ToDouble(x.ChildNodes
                 .SelectMany(s => s.Attributes)
                 .First(a => a.Value == "ands_p_buy ands_clearfix")
                 .OwnerNode.FirstChild.InnerText.Split(' ')[0]),
             x.Id.Replace("mmmhd", "")
            )).ToList();

            return items;
        }

        public static Pizza GetByName(string name)
        {
            return GetPizzas().FirstOrDefault(x => x.Name.Trim().ToLower().Contains(name.ToLower()));
        }
    }
}
