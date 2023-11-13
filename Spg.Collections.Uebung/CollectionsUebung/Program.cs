using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace ExCollection.App
{
    public class Klasse
    {
        public Klasse(string name, string kV)
        {
            Name = name;
            KV = kV;
        }

        // TODO: Erstelle ein Property Schuelers, welches alle Schüler der Klasse in einer
        //       Liste speichert.
        public List<Schueler> Schuelers { get; set; }

        public string Name { get; private set; }
        public string KV { get; private set; }

        /// <summary>
        /// Fügt den Schüler zur Liste hinzu und setzt das Property KlasseNavigation
        /// des Schülers korrekt auf die aktuelle Instanz.
        /// </summary>
        /// <param name="s"></param>
        public void AddSchueler(Schueler s)
        {
            if (s is not null)
            {
                if (Schuelers.Any(i => i.Id == s.Id))
                {
                    throw new KeyNotFoundException("Schüler ist bereits vorhanden!");
                }
                Schuelers.Add(s);
                s.KlasseNavigation = this;
            }
            else
            {
                throw new ArgumentNullException("Schüler war NULL!");
            }
        }

        public void RemoveSchueler(Schueler s)
        {
            if (s is not null)
            {
                if (!Schuelers.Any(i => i.Id == s.Id))
                {
                    throw new KeyNotFoundException("Schüler nicht vorhanden!");
                }
                Schuelers.Remove(s);
            }
            else
            {
                throw new ArgumentNullException("Schüler war NULL!");
            }
        }
    }
    public class Schueler
    {
        //{
        //    A: "a",
        //    B: "b"
        //    { 
        //        C: "c",
        //    }
        //}

        // TODO: Erstelle ein Proeprty KlasseNavigation vom Typ Klasse, welches auf
        //       die Klasse des Schülers zeigt.
        // Füge dann über das Proeprty die Zeile
        // [JsonIgnore]
        // ein, damit der JSON Serializer das Objekt ausgeben kann.
        [JsonIgnore]
        public Klasse KlasseNavigation { get; set; } = default!;

        public int Id { get; set; }

        public string Zuname { get; set; } = string.Empty;

        public string Vorname { get; set; } = String.Empty;

        /// <summary>
        /// Ändert die Klassenzugehörigkeit, indem der Schüler
        /// aus der alten Klasse, die in KlasseNavigation gespeichert ist, entfernt wird.
        /// Danach wird der Schüler in die neue Klasse mit der korrekten Navigation eingefügt.
        /// </summary>
        /// <param name="k"></param>
        public void ChangeKlasse(Klasse k)
        {
            if (k is not null)
            {
                KlasseNavigation.RemoveSchueler(this);
                k.AddSchueler(this);
            }
            else
            {
                throw new ArgumentNullException("Klasse war NULL!");
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Klasse> klassen = new Dictionary<string, Klasse>();
            klassen.Add("3AHIF", new Klasse("3AHIF", "KV1" ));
            klassen.Add("3BHIF", new Klasse(name: "3BHIF", kV: "KV2" ));
            klassen.Add("3CHIF", new Klasse(kV: "KV3" , name: "3CHIF"));
            klassen["3AHIF"].AddSchueler(new Schueler() { Id = 1001, Vorname = "VN1", Zuname = "ZN1" });
            klassen["3AHIF"].AddSchueler(new Schueler() { Id = 1002, Vorname = "VN2", Zuname = "ZN2" });
            klassen["3AHIF"].AddSchueler(new Schueler() { Id = 1003, Vorname = "VN3", Zuname = "ZN3" });
            klassen["3BHIF"].AddSchueler(new Schueler() { Id = 1011, Vorname = "VN4", Zuname = "ZN4" });
            klassen["3BHIF"].AddSchueler(new Schueler() { Id = 1012, Vorname = "VN5", Zuname = "ZN5" });
            klassen["3BHIF"].AddSchueler(new Schueler() { Id = 1013, Vorname = "VN6", Zuname = "ZN6" });

            //foreach (Schueler schueler in klassen["3AHIF"].Schuelers)
            //{
            //    if (schueler.Id == 1002)
            //    {
            //        klassen["3AHIF"].Schuelers.RemoveAt(i);
            //    }
            //}

            //for (int i = 0 ; i <= klassen["3AHIF"].Schuelers.Count - 1; i++)
            //{
            //    if (i == 1)
            //    {
            //        klassen["3AHIF"].Schuelers.RemoveAt(i);
            //    }
            //}

            Schueler s = klassen["3AHIF"].Schuelers[0];
            Console.WriteLine($"s sitzt in der Klasse {s.KlasseNavigation.Name} mit dem KV {s.KlasseNavigation.KV}.");
            Console.WriteLine("3AHIF vor ChangeKlasse:");
            Console.WriteLine(JsonConvert.SerializeObject(klassen["3AHIF"].Schuelers));
            s.ChangeKlasse(klassen["3BHIF"]);

            Console.WriteLine("3AHIF nach ChangeKlasse:");
            Console.WriteLine(JsonConvert.SerializeObject(klassen["3AHIF"].Schuelers));
            Console.WriteLine("3BHIF nach ChangeKlasse:");
            Console.WriteLine(JsonConvert.SerializeObject(klassen["3BHIF"].Schuelers));
            Console.WriteLine($"s sitzt in der Klasse {s.KlasseNavigation.Name} mit dem KV {s.KlasseNavigation.KV}.");

            //klassen["3BHIF"].Schuelers.Add(new Schueler() { Id = 4711, Vorname = "asdasd", Zuname = "qweqwe" });    //Bad
            //klassen["3BHIF"].AddSchueler(new Schueler() { Id = 4711, Vorname = "asdasd", Zuname = "qweqwe" });      //OK
            //klassen["3BHIF"].Schuelers = new List<Schueler>();
        }
    }
}