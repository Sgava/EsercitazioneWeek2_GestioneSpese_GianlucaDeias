using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese.TipiSpesa
{
    public interface ISpesa
    {
        public DateTime DataSpesa { get; set; }
        
        public string Descrizione { get; set; }

        public double Importo { get; set; }

        public bool ApprovazioneSpesa { get; set; }

        public string LivelloApprovazione { get; set; } 

        public double? ImportoRimborsato { get; }
    }
}
