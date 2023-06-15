using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using System.IO;

namespace Wpf_Versenyzok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Pilota> pilotak = new List<Pilota>();
        public MainWindow()
        {
            InitializeComponent();

            //2. adatbeolvasás

            ReadingData("DataSource\\pilotak.csv");

            //3. 

            lblFeladat3.Content = $"3. feladat: {pilotak.Count}";

            //4.

            var lastLine = pilotak.Last();
            var lastName = lastLine.Nev;

            lblFeladat4.Content = $"4. feladat: {lastName}";

            //5. 

            DateTime newDate = new DateTime(1901, 01, 01);
            var newPilotak = pilotak.Where(x => x.Szuletesi_datum.Year < 1901).ToList();

            newPilotak.ForEach(x => lbXixSzazadiPilotak.Items.Add($"\t{x.Nev} ({x.Szuletesi_datum})"));

            //6. 

            var newPilotak2 = pilotak.Where(x => x.Rajtszam != "").OrderBy(x => int.Parse(x.Rajtszam)).ToList();
            //newPilotak2.OrderBy(x => int.Parse(x.Rajtszam)).ToList();
            var legkisebbRajtszam = newPilotak2.First();
            var legkisebbRajtszamuNemzetiseg = legkisebbRajtszam.Nemzetiseg;
            lblFeladat6.Content = $"6. feladat: {legkisebbRajtszamuNemzetiseg}";

            //newPilotak2.ForEach(x => lbXixSzazadiPilotak.Items.Add($"{x.Rajtszam}:{x.Nemzetiseg}"));

            //7.

            var pilotakTobbRajtszammal = pilotak.GroupBy(pilot => pilot.Rajtszam)
                .Where(group => group.Count() >1)
                .Select(group => group.Key) ;

            lblFeladat7.Content = "7. feladat: ";

            foreach (var pilota in pilotakTobbRajtszammal)
            {
                lblFeladat7.Content += $"{pilota}, ";
            }

            //8. 

            foreach (var pilota in pilotak)
            {
                if (pilota.Rajtszam == "7")
                {
                    lbFeladat8.Items.Add($"{pilota.Nev} {pilota.Rajtszam} {pilota.Nemzetiseg} {pilota.Szuletesi_datum}");
                }
            }

        }

        public void ReadingData(string filename)
        {
            string[] lines = File.ReadAllLines(filename);

            for (int index = 1; index < lines.Length; index++)
            {
                string[] sor = lines[index].Split(';');

                string nev = sor[0];
                DateTime szuletesi_datum = DateTime.Parse(sor[1]);
                string nemzetiseg = sor[2];
                string rajtszam = sor[3];

                Pilota pilotaLine = new(nev, szuletesi_datum, nemzetiseg,  rajtszam);

                pilotak.Add(pilotaLine);
            }
            lblFeladat2.Content = $"2. feladat: pilotak.csv beolvasása a {pilotak} listába sikeresen megtörtént!";
        }
    }

    
}
