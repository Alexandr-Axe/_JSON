using System;
using Newtonsoft.Json;

namespace _JSON
{
    public class Person
    {
        [JsonProperty("Jméno")]
        public string Name { get; set; }

        [JsonProperty("Příjmení")]
        public string LastName { get; set; }

        [JsonProperty("Věk")]
        public int Age { get; set; }
        public override string ToString() => $"Jsem {Name} {LastName} a je mi {Age} let.";
    }
    public class Pair
    {
        [JsonProperty("Otec")]
        public Person Osoba1 { get; set; }

        [JsonProperty("Matka")]
        public Person Osoba2 { get; set; }
        public override string ToString() => $"Jméno : {Osoba1.Name}\nPříjmení : {Osoba1.LastName}\nVěk : {Osoba1.Age}\n\nJméno : {Osoba2.Name}\nPříjmení : {Osoba2.LastName}\nVěk : {Osoba2.Age}";
    }
    class Program
    {
        static void Main(string[] args)
        {
            //string Output = JsonConvert.SerializeObject(Osoba);
            Person Alex = new Person { Name = "Alexandr", LastName = "Sekera", Age = 18 };
            Person Jirka = new Person { Name = "Jiří", LastName = "Měřínský", Age = 45 };
            Pair Par = new Pair { Osoba1 = Alex, Osoba2 = Jirka };
            var JsonPerson1 = JsonConvert.SerializeObject(Alex);
            var JsonPerson2 = JsonConvert.SerializeObject(Jirka);
            var JsonPar = JsonConvert.SerializeObject(Par);
            Console.WriteLine(JsonPerson1);
            Console.WriteLine(JsonPerson2);

            Pair c = JsonConvert.DeserializeObject<Pair>(JsonPar);
            Console.WriteLine(c);
        }
    }
}
