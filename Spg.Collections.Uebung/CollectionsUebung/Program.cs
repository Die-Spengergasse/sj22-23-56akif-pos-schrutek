using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace ExCollection.App
{
    public class Classroom
    {
        public Classroom(string name, string kV)
        {
            Name = name;
            KV = kV;
        }

        // TODO: Erstelle ein Property Students, welches alle Schüler der Classroom in einer
        //       Liste speichert.
        private List<Student> _students = new();
        public IReadOnlyList<Student> Students { get { return _students; } }

        public string Name { get; private set; }
        public string KV { get; private set; }

        /// <summary>
        /// Fügt den Schüler zur Liste hinzu und setzt das Property ClassroomNavigation
        /// des Schülers korrekt auf die aktuelle Instanz.
        /// </summary>
        /// <param name="s"></param>
        public void AddStudent(Student s)
        {
            if (s is not null)
            {
                if (Students.Any(i => i.Id == s.Id))
                {
                    throw new KeyNotFoundException("Schüler ist bereits vorhanden!");
                }
                _students.Add(s);
                s.ClassroomNavigation = this;
            }
            else
            {
                throw new ArgumentNullException("Schüler war NULL!");
            }
        }

        public void RemoveSchueler(Student s)
        {
            if (s is not null)
            {
                if (!Students.Any(i => i.Id == s.Id))
                {
                    throw new KeyNotFoundException("Schüler nicht vorhanden!");
                }
                _students.Remove(s);
            }
            else
            {
                throw new ArgumentNullException("Schüler war NULL!");
            }
        }
    }
    public class Student
    {
        //{
        //    A: "a",
        //    B: "b"
        //    { 
        //        C: "c",
        //    }
        //}

        // TODO: Erstelle ein Proeprty ClassroomNavigation vom Typ Classroom, welches auf
        //       die Classroom des Schülers zeigt.
        // Füge dann über das Proeprty die Zeile
        // [JsonIgnore]
        // ein, damit der JSON Serializer das Objekt ausgeben kann.
        [JsonIgnore]
        public Classroom ClassroomNavigation { get; set; } = default!;

        public int Id { get; set; }

        public string Zuname { get; set; } = string.Empty;

        public string Vorname { get; set; } = String.Empty;

        /// <summary>
        /// Ändert die Klassenzugehörigkeit, indem der Schüler
        /// aus der alten Classroom, die in ClassroomNavigation gespeichert ist, entfernt wird.
        /// Danach wird der Schüler in die neue Classroom mit der korrekten Navigation eingefügt.
        /// </summary>
        /// <param name="k"></param>
        public void ChangeKlasse(Classroom k)
        {
            if (k is not null)
            {
                ClassroomNavigation.RemoveSchueler(this);
                k.AddStudent(this);
            }
            else
            {
                throw new ArgumentNullException("Classroom war NULL!");
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Classroom> klassen = new Dictionary<string, Classroom>();
            klassen.Add("3AHIF", new Classroom("3AHIF", "KV1" ));
            klassen.Add("3BHIF", new Classroom(name: "3BHIF", kV: "KV2" ));
            klassen.Add("3CHIF", new Classroom(kV: "KV3" , name: "3CHIF"));
            klassen["3AHIF"].AddStudent(new Student() { Id = 1001, Vorname = "VN1", Zuname = "ZN1" });
            klassen["3AHIF"].AddStudent(new Student() { Id = 1002, Vorname = "VN2", Zuname = "ZN2" });
            klassen["3AHIF"].AddStudent(new Student() { Id = 1003, Vorname = "VN3", Zuname = "ZN3" });
            klassen["3BHIF"].AddStudent(new Student() { Id = 1011, Vorname = "VN4", Zuname = "ZN4" });
            klassen["3BHIF"].AddStudent(new Student() { Id = 1012, Vorname = "VN5", Zuname = "ZN5" });
            klassen["3BHIF"].AddStudent(new Student() { Id = 1013, Vorname = "VN6", Zuname = "ZN6" });

            //foreach (Student schueler in klassen["3AHIF"].Students)
            //{
            //    if (schueler.Id == 1002)
            //    {
            //        klassen["3AHIF"].Students.RemoveAt(i);
            //    }
            //}

            //for (int i = 0 ; i <= klassen["3AHIF"].Students.Count - 1; i++)
            //{
            //    if (i == 1)
            //    {
            //        klassen["3AHIF"].Students.RemoveAt(i);
            //    }
            //}

            Student s = klassen["3AHIF"].Students[0];
            Console.WriteLine($"s sitzt in der Classroom {s.ClassroomNavigation.Name} mit dem KV {s.ClassroomNavigation.KV}.");
            Console.WriteLine("3AHIF vor ChangeKlasse:");
            Console.WriteLine(JsonConvert.SerializeObject(klassen["3AHIF"].Students));
            s.ChangeKlasse(klassen["3BHIF"]);

            Console.WriteLine("3AHIF nach ChangeKlasse:");
            Console.WriteLine(JsonConvert.SerializeObject(klassen["3AHIF"].Students));
            Console.WriteLine("3BHIF nach ChangeKlasse:");
            Console.WriteLine(JsonConvert.SerializeObject(klassen["3BHIF"].Students));
            Console.WriteLine($"s sitzt in der Classroom {s.ClassroomNavigation.Name} mit dem KV {s.ClassroomNavigation.KV}.");

            
            
            
            //klassen["3BHIF"].Students.Add(new Student() { Id = 4711, Vorname = "asdasd", Zuname = "qweqwe" });    //Bad
            klassen["3BHIF"].AddStudent(new Student() { Id = 4711, Vorname = "asdasd", Zuname = "qweqwe" });      //OK
            
            
            
            
            
            //klassen["3BHIF"].Students = new List<Student>();
        }
    }
}