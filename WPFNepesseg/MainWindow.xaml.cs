using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

namespace WPFNepesseg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Telepules> telepulesek;
        public MainWindow()
        {
            InitializeComponent();
            telepulesek=new List<Telepules>();
            StreamReader sr = new StreamReader("Adatok\\kozerdeku_lakossag_2022.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string CSVsor = sr.ReadLine();
                string[] mezok = CSVsor.Split(";");
                Telepules ujTelepules = new Telepules(mezok[2],
                                                      mezok[3],
                                                      mezok[4],
                                                      int.Parse(mezok[5].Replace(" ", "")),
                                                      int.Parse(mezok[6].Replace(" ", "")));
                telepulesek.Add(ujTelepules);
            }
            sr.Close();
            dgTelepulesek.ItemsSource = telepulesek;
        }
     
        private void cbMegyek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgTelepulesek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
  

}
public class Telepules
{
    String megye;
    String telepulesNev;
    String telepulesTipus; //község, nagyközség, város, ...
    int ferfiLakosokSzama;
    int noiLakosokSzama;

    public Telepules(string megye,
                     string telepulesNev,
                     string telepulesTipus,
                     int ferfiLakosokSzama,
                     int noiLakosokSzama)
    {
        this.megye = megye;
        this.telepulesNev = telepulesNev;
        this.telepulesTipus = telepulesTipus;
        this.ferfiLakosokSzama = ferfiLakosokSzama;
        this.noiLakosokSzama = noiLakosokSzama;
    }
    public string Megye { get => megye; }
    public string TelepulesNev { get => telepulesNev; }
    public string TelepulesTipus { get => telepulesTipus; }
    public int FerfilakosokSzama { get => ferfiLakosokSzama; }
    public int NoilakosokSzama { get => noiLakosokSzama; }
    public int LakosokSzamaEgyutt { get => this.noiLakosokSzama + this.ferfiLakosokSzama; }
}