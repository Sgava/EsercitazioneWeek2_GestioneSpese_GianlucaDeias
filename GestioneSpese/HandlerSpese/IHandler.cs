using GestioneSpese.TipiSpesa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese.HandlerSpese
{
    public interface IHandler
    {
        
            
            IHandler SetNext(IHandler handler);
            
            ISpesa Handle(ISpesa spesa);


        
    }
}
