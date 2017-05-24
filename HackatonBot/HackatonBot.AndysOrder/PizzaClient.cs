using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using HackatonBot.AndysOrder.Models;
using Newtonsoft.Json;

namespace HackatonBot.AndysOrder
{
    public class PizzaClient
    {
        public static async Task<PizzaLuisModel> ParseInputText(string strInput)
        {
            using (var client = new HttpClient())
            {
                string uri = ConfigurationManager.AppSettings["LuisSource"];
                HttpResponseMessage response = await client.GetAsync(uri + "&q=" + strInput);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var _Data = JsonConvert.DeserializeObject<PizzaLuisModel>(jsonResponse);
                    return _Data;
                }
            }

            return null;
        }
    }
}