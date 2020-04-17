using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaCovid_19_Petito.Model
{
    class DatoCovid
    {
        public DateTime data { get; set; }
        public string stato { get; set; }
        public int ricoverati_con_sintomi { get; set; }
        public int terapia_intensiva { get; set; }
        public int totale_ospedalizzati { get; set; }
        public int isolamento_domiciliare { get; set; }
        public int totale_positivi { get; set; }
        public int variazione_totale_positivi { get; set; }
        public int nuovi_positivi { get; set; }
        public int dimessi_guariti { get; set; }
        public int deceduti { get; set; }
        public int totale_casi { get; set; }
        public int tamponi { get; set; }
        public string note_it { get; set; }
        public string note_en { get; set; }

        public override string ToString()
        {
            return $"Stato: {stato} Data: {data.ToShortDateString()} nuovi positivi: {nuovi_positivi} totale posivi: {totale_positivi} ricoverati: {ricoverati_con_sintomi} deceduti: {deceduti}";
        }
    }
}
