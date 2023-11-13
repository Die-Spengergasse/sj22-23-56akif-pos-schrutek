using ExCollection.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsUebung
{
    public class SchulerList : List<Schueler>
    {
        public Klasse Klasse { get; set; }

        public SchulerList(Klasse klasse)
        {
            Klasse = klasse;
        }

        public new void Add(Schueler s)
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
