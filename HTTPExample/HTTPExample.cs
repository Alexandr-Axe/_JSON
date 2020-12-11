using System;
using System.Net.Http;
using Newtonsoft.Json; //NuGet, který obohacuje projekt o json -> Spravovat NuGety -> vyhledat newtonsoft (stačí napsat json)
using System.Text;
using System.Threading.Tasks;

namespace HTTPExample
{
    public class Person
    {
        [JsonProperty("Jméno")] //Přepisuje název vlastnosti třídy
        public string Name { get; set; }

        [JsonProperty("Příjmení")]
        public string LastName { get; set; }

        [JsonProperty("Věk")]
        public int Age { get; set; }
        public override string ToString() => $"Jsem {Name} {LastName} a je mi {Age} let.";
    }
    class Program
    {
        static async Task Main(string[] args) //kvůli posílání informací na web -> nezapomenout using
        {
            Person Dalsi = new Person { Name = "Martin", LastName = "Stránský", Age = 24 };
            var JsonDalsi = JsonConvert.SerializeObject(Dalsi); //Převede proměnnou na formát json
            Person DeJsonDalsi = JsonConvert.DeserializeObject<Person>(JsonDalsi); //Převede formát json na libovolný, který chceme (ovšem musí fungovat konverze)

            HttpClient htc = new HttpClient();
            HttpContent htcContent = new StringContent(JsonDalsi, Encoding.UTF8, "application/json"); //identifikátor, který říká, jakého typu je informace, kterou posílám (konkrétně json)

            try
            {
                HttpResponseMessage hrm = await htc.PostAsync("http://ptsv2.com/t/7q0dq-1607691180/post", htcContent);
                Console.WriteLine(hrm);
            }
            catch (HttpRequestException hre)
            {
                Console.WriteLine(hre);
            }

            /*while (true)
            {
                await htc.PostAsync("http://ptsv2.com/t/7q0dq-1607691180/post", htcContent);
            }*/
        }
    }
}
