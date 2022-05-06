using GestioneSpese.TipiSpesa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese.HandlerSpese
{
    public class HandlerOperationalManager : AbstractHandler
    {
        public override ISpesa Handle(ISpesa spesaRichiesta)
        {
            if (spesaRichiesta.Importo >= 401 && spesaRichiesta.Importo <= 1000)
            {
                spesaRichiesta.ApprovazioneSpesa = true;
                
                spesaRichiesta.LivelloApprovazione = "OperationalManager";

                return spesaRichiesta;
            }
            else
                return base.Handle(spesaRichiesta);
        }
    }
}
