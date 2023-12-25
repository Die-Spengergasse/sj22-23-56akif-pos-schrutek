using ExCollection.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsUebung
{
    public class SchulerList : List<Student>
    {
        public Classroom Klasse { get; set; }

        public SchulerList(Classroom klasse)
        {
            Klasse = klasse;
        }

        public new void Add(Student s)
        {
            if (s != null)
            {
                base.Add(s);
            }
            else
            {
                throw new ArgumentNullException("Schüler war NULL");
            }
        }
    }
}
