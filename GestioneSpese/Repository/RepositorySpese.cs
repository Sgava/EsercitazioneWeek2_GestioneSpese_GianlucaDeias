
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestioneSpese.TipiSpesa;


namespace GestioneSpese.Repository
{
    public class RepositorySpese
    {
        string pathLettura = @"C:\Users\gianluca.deias\source\repos\GestioneSpese\GestioneSpese\Repository\Spese.txt";
        string pathScrittura = @"C:\Users\gianluca.deias\source\repos\GestioneSpese\GestioneSpese\Repository\spese_elaborate.txt";


        public List<ISpesa> GetAll()
        {
            Console.WriteLine("sono entrato nel metodo");
            List<ISpesa> speseDaApprovare = new List<ISpesa>();
            using (StreamReader sr = new StreamReader(pathLettura))
            {
                string contenutoFile = sr.ReadToEnd();
                
                if (string.IsNullOrEmpty(contenutoFile))
                {
                    Console.WriteLine("non ci ho trovato niente");
                    return speseDaApprovare;
                }
                else
                {
                    Factory factory = new Factory();
                    var righeDelFile = contenutoFile.Split("\r\n");
                    Console.WriteLine(righeDelFile[0]);
                    for (int i = 0; i < righeDelFile.Length-1; i++)
                    {
                        var campiDellaRiga = righeDelFile[i].Split(";");
                        ISpesa s = factory.GeneraSpesa(campiDellaRiga[1]);
                        s.DataSpesa = DateTime.Parse(campiDellaRiga[0]);
                        //s.CategoriaRimborso = (Categoria)Enum.Parse(typeof(Categoria),campiDellaRiga[1]);
                        s.Descrizione = (campiDellaRiga[2]);
                        s.Importo = double.Parse(campiDellaRiga[3]);
                        speseDaApprovare.Add(s);

                        
                    }
                }
                Console.WriteLine("lista spese caricata");
                return speseDaApprovare;
            }
        }

        public bool Aggiungi(ISpesa s)
        {
            using (StreamWriter sw = new StreamWriter(pathScrittura, true))
            {
                string approvazionespesa = "RESPINTA";
                if (s.ApprovazioneSpesa == true) approvazionespesa = "APPROVATA";
                sw.WriteLine(
                    $"{s.DataSpesa.ToShortDateString()};" +
                    $"{s.GetType().Name};" +
                    $"{s.Descrizione};" +
                    $"{approvazionespesa};" +
                    $"{s.LivelloApprovazione};" +
                    $"{s.ImportoRimborsato}" 
                    );
            }
            return true;
        }
    }
}
