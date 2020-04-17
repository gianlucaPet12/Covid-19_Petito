using ListaCovid_19_Petito.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace ListaCovid_19_Petito
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<DatoCovid> ListaCovid = new List<DatoCovid>();

        private void Btn_Covid_19_Click(object sender, RoutedEventArgs e)
        {
            Lstl_Covid_19.Items.Clear();

            Task.Factory.StartNew(() =>
            {
                Carica();
            });
        }

        public void Carica()
        {

            string file = @"DatiCovid.xml";
            XDocument xmlDoc = XDocument.Load(file);
            XElement xmlroot = xmlDoc.Element("root");
            var xmlrow = xmlroot.Elements("row");

            foreach (var item in xmlrow)
            {
                Thread.Sleep(1000);
                XElement xmlData = item.Element("data");
                XElement xmlStato = item.Element("stato");
                XElement xmricoverati_con_sintomi = item.Element("ricoverati_con_sintomi");
                XElement xmlterapia_intensiva = item.Element("terapia_intensiva");
                XElement xmltotale_ospedalizzati = item.Element("totale_ospedalizzati");
                XElement xmlisolamento_domiciliare = item.Element("isolamento_domiciliare");
                XElement xmltotale_positivi = item.Element("totale_positivi");
                XElement xmlvariazione_totale_positivi = item.Element("variazione_totale_positivi");
                XElement xmlnuovi_positivi = item.Element("nuovi_positivi");
                XElement xmldimessi_guariti = item.Element("dimessi_guariti");
                XElement xmldeceduti = item.Element("deceduti");
                XElement xmltotale_casi = item.Element("totale_casi");
                XElement xmltamponi = item.Element("tamponi");
                XElement xmlnote_it = item.Element("note_it");
                XElement xmlnote_en = item.Element("note_en");

                DatoCovid a = new DatoCovid();
                a.data = Convert.ToDateTime(xmlData.Value);
                a.stato = xmlStato.Value;
                a.ricoverati_con_sintomi = Convert.ToInt32(xmricoverati_con_sintomi.Value);
                a.terapia_intensiva = Convert.ToInt32(xmlterapia_intensiva.Value);
                a.totale_ospedalizzati = Convert.ToInt32(xmltotale_ospedalizzati.Value);
                a.isolamento_domiciliare = Convert.ToInt32(xmlisolamento_domiciliare.Value);
                a.totale_positivi = Convert.ToInt32(xmltotale_positivi.Value);
                a.variazione_totale_positivi = Convert.ToInt32(xmlvariazione_totale_positivi.Value);
                a.nuovi_positivi = Convert.ToInt32(xmlnuovi_positivi.Value);
                a.dimessi_guariti = Convert.ToInt32(xmldimessi_guariti.Value);
                a.deceduti = Convert.ToInt32(xmldeceduti.Value);
                a.totale_casi = Convert.ToInt32(xmltotale_casi.Value);
                a.tamponi = Convert.ToInt32(xmltamponi.Value);
                a.note_it = xmlnote_it.Value;
                a.note_en = xmlnote_en.Value;
                Dispatcher.Invoke(() =>
                {
                    Lstl_Covid_19.Items.Add(a);
                });

            }
        }
    }
}
