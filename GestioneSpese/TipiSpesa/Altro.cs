namespace GestioneSpese.TipiSpesa
{
    public class Altro : ISpesa
    {
        public DateTime DataSpesa { get; set; }

        public string Descrizione { get; set; }

        public double Importo { get; set; }

        public bool ApprovazioneSpesa { get; set; }

        public string LivelloApprovazione { get; set; } = "";

        public double? ImportoRimborsato
        {
            get
            {
                if (ApprovazioneSpesa)
                    return Importo*.1;
                else
                    return null;
            }
        }
    }
}