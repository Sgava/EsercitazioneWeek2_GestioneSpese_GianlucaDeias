
using GestioneSpese.HandlerSpese;
using GestioneSpese.Repository;
using GestioneSpese.TipiSpesa;

IHandler manager = new HandlerManager();
IHandler operationalManager = new HandlerOperationalManager();
IHandler ceo = new HandlerCEO();

manager.SetNext(operationalManager).SetNext(ceo);

RepositorySpese gestoreFile = new RepositorySpese();

List<ISpesa> speseDaElaborare = gestoreFile.GetAll();

//List<ISpesa> speseElaborate = gestoreFile.GetAll();

foreach (ISpesa spesa in speseDaElaborare)
{
      gestoreFile.Aggiungi(manager.Handle(spesa));

    // Publish()

}





