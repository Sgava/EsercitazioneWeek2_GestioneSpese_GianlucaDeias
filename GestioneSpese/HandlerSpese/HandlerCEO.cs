using GestioneSpese.TipiSpesa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GestioneSpese.HandlerSpese
{
    public class HandlerCEO : AbstractHandler
    {
        public override ISpesa Handle(ISpesa spesaRichiesta)
        {
            if (spesaRichiesta.Importo >= 1000 && spesaRichiesta.Importo <= 2500)
            {
                spesaRichiesta.ApprovazioneSpesa = true;

                spesaRichiesta.LivelloApprovazione = "CEO";

                return spesaRichiesta;
            }
            else
                return base.Handle(spesaRichiesta);
        }
    }
}
