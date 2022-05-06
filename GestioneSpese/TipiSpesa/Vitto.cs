namespace GestioneSpese.TipiSpesa
{
    public class Vitto : ISpesa
    {
        public DateTime DataSpesa { get; set; }

        public string Descrizione { get; set; }

        public double Importo { get; set; }

        public bool ApprovazioneSpesa { get; set; } = false;

        public string LivelloApprovazione { get; set; } = "";

        public double? ImportoRimborsato
        {
            get
            {
                if (ApprovazioneSpesa)
                    return Importo*.7;
                else
                    return null;
            }
        }
    }
}