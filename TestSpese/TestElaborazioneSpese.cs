using Xunit;
using System;
using GestioneSpese;
using GestioneSpese.HandlerSpese;
using GestioneSpese.Repository;
using GestioneSpese.TipiSpesa;
using System.Collections.Generic;

namespace TestSpese
{
    public class TestElaborazioneSpese
    {
        [Fact]
        public void ApprovazioneViaggio500()
        {
            //mi aspetto che la richiesta venga approvata dall'Ops e che reveda un rimborso da 550€

            //Arrange

            IHandler manager = new HandlerManager();
            IHandler operationalManager = new HandlerOperationalManager();
            IHandler ceo = new HandlerCEO();

            manager.SetNext(operationalManager).SetNext(ceo);

            ISpesa spesaNonElaborata = new Viaggio()
            {
                Importo = 500.0
            };
            
            List<ISpesa> listaProva = new List<ISpesa>();

            listaProva.Add(spesaNonElaborata);

            
            //Act


            ISpesa spesaElaborata = manager.Handle(spesaNonElaborata);

            
            //Assert

            Assert.Equal(550, spesaElaborata.ImportoRimborsato);
            Assert.True(spesaElaborata.ApprovazioneSpesa);
            Assert.Equal("OperationalManager",spesaElaborata.LivelloApprovazione);


        }


        [Fact]
        public void ApprovazioneViaggio3100()
        {
            //mi aspetto che la richiesta  non venga approvata 

            //Arrange

            IHandler manager = new HandlerManager();
            IHandler operationalManager = new HandlerOperationalManager();
            IHandler ceo = new HandlerCEO();

            manager.SetNext(operationalManager).SetNext(ceo);

            ISpesa spesaNonElaborata = new Viaggio()
            {
                Importo = 3100.0
            };

            List<ISpesa> listaProva = new List<ISpesa>();

            listaProva.Add(spesaNonElaborata);


            //Act


            ISpesa spesaElaborata = manager.Handle(spesaNonElaborata);


            //Assert

            Assert.False(spesaElaborata.ApprovazioneSpesa);

           



        }


        [Fact]
        public void ApprovazioneVitto1400()
        {
            //mi aspetto che la richiesta venga approvata dal CEO con un rimborso di 980€ 

            //Arrange

            IHandler manager = new HandlerManager();
            IHandler operationalManager = new HandlerOperationalManager();
            IHandler ceo = new HandlerCEO();

            manager.SetNext(operationalManager).SetNext(ceo);

            ISpesa spesaNonElaborata = new Vitto()
            {
                Importo = 1400.0
            };

            List<ISpesa> listaProva = new List<ISpesa>();

            listaProva.Add(spesaNonElaborata);


            //Act


            ISpesa spesaElaborata = manager.Handle(spesaNonElaborata);


            //Assert

            //var rimborso = spesaElaborata.ImportoRimborsato;



            Assert.Equal(979.9999999999999, spesaElaborata.ImportoRimborsato);
            Assert.True(spesaElaborata.ApprovazioneSpesa);
            Assert.Equal("CEO", spesaElaborata.LivelloApprovazione);



        }


        [Fact]
        public void ApprovazioneAltro50()
        {
            //mi aspetto che la richiesta venga approvata dal Manager con un rimborso di 5€ 

            //Arrange

            IHandler manager = new HandlerManager();
            IHandler operationalManager = new HandlerOperationalManager();
            IHandler ceo = new HandlerCEO();

            manager.SetNext(operationalManager).SetNext(ceo);

            ISpesa spesaNonElaborata = new Altro()
            {
                Importo = 50.0
            };

            List<ISpesa> listaProva = new List<ISpesa>();

            listaProva.Add(spesaNonElaborata);


            //Act


            ISpesa spesaElaborata = manager.Handle(spesaNonElaborata);


            //Assert


            Assert.Equal(5.0, spesaElaborata.ImportoRimborsato);
            Assert.True(spesaElaborata.ApprovazioneSpesa);
            Assert.Equal("Manager", spesaElaborata.LivelloApprovazione);



        }


        [Fact]
        public void ApprovazioneAlloggio350()
        {
            //mi aspetto che la richiesta venga approvata dal Manager con un rimborso di 350€ 

            //Arrange

            IHandler manager = new HandlerManager();
            IHandler operationalManager = new HandlerOperationalManager();
            IHandler ceo = new HandlerCEO();

            manager.SetNext(operationalManager).SetNext(ceo);

            ISpesa spesaNonElaborata = new Alloggio()
            {
                Importo = 350.0
            };

            List<ISpesa> listaProva = new List<ISpesa>();

            listaProva.Add(spesaNonElaborata);


            //Act


            ISpesa spesaElaborata = manager.Handle(spesaNonElaborata);


            //Assert


            Assert.Equal(350.0, spesaElaborata.ImportoRimborsato);
            Assert.True(spesaElaborata.ApprovazioneSpesa);
            Assert.Equal("Manager", spesaElaborata.LivelloApprovazione);



        }


    }
}