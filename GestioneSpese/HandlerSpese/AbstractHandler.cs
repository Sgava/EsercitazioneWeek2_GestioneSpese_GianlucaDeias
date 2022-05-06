using GestioneSpese.TipiSpesa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese.HandlerSpese
{
    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;
        public virtual ISpesa Handle(ISpesa spesaRichiesta)
        {
            if (_nextHandler != null)

                return _nextHandler.Handle(spesaRichiesta);
            
            else

                return spesaRichiesta;
        }

        IHandler IHandler.SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }
    }
}
