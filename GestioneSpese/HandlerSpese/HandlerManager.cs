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


        /*    
        //prova eventi
          
        //Delegato 
               
        public delegate void Notify(Publisher p, Notification notification);


        //Evento
                    
        public event Notify OnPublish; 
                
        public void Publish()
        {
            if(OnPublish != null)
            {
                
                Notification notifica = new Notification("Elaborazione spesa caricata sul file  ", DateTime.Now); 
                OnPublish(this, notifica);
            }
        }







         * 
         */
    }
}
