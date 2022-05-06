using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese.TipiSpesa
{
    public class Factory
    {
        public ISpesa GeneraSpesa(string categoria)
        {
            ISpesa spesa = null;
            
            if (categoria == "Viaggio")
            {
                return new Viaggio();
            }
            else if (categoria == "Alloggio")
            {
                spesa = new Alloggio();
            }
            else if (categoria == "Vitto")
            {
                spesa = new Vitto();
            }
            else if (categoria == "Altro")
            {
                spesa = new Altro();
            }
            
            return spesa;




        }
    }
}
