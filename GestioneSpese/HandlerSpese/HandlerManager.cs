using GestioneSpese.TipiSpesa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese.HandlerSpese
{
    public class HandlerManager : AbstractHandler
    {
        public override ISpesa Handle(ISpesa spesaRichiesta)
        {
            if (spesaRichiesta.Importo >= 0 && spesaRichiesta.Importo <= 400)
            {
                spesaRichiesta.ApprovazioneSpesa = true;

                spesaRichiesta.LivelloApprovazione = "Manager";

                return spesaRichiesta;
            }
            else
                return base.Handle(spesaRichiesta);
        }


        /*    prova eventi
         * 
         *      //Delegato da utilizzare nell'evento
                  public delegate void Notify(Publisher p, Notification notification);
         * 
         */
    }
}
