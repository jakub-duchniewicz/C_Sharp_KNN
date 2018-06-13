using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaneZPlikuOkienko
{
    public partial class Form2 : Form
    {
        
        public void PopulateDataGridView(string[][] System_testowy_sklasyfikowany, string[][] System_testowy, List<List<int>> Lista_klas)
        {
            Odleglosc o = new Odleglosc();
            int Ostatnia_kolumna = System_testowy_sklasyfikowany[0].Length - 1;
            var Number_of_object = new Dictionary<int, int>();
            var Accuracy = new Dictionary<int, double>();
            var Coverage = new Dictionary<int, double>();
            var Tpr = new Dictionary<int, double>();
            var Slownik_predykcji = new Dictionary<int, Dictionary<int, int>>();
            Number_of_object = o.F_Number_of_object(System_testowy);
            Accuracy = o.F_Accuracy(System_testowy_sklasyfikowany, System_testowy,Number_of_object,Podzial_na_klasy1);
            Coverage = o.F_Coverage(System_testowy_sklasyfikowany, System_testowy,Number_of_object,Podzial_na_klasy1);
            Tpr = o.F_Tpr(System_testowy, Lista_klas, System_testowy_sklasyfikowany, Podzial_na_klasy1);
            Slownik_predykcji =o.F_Slownik_predykcji(System_testowy_sklasyfikowany, System_testowy,Podzial_na_klasy1);
            Grid.Columns.Add("", "");
            foreach (var kvp in Podzial_na_klasy1)
            {
                Grid.Columns.Add("klasadecyzyjna", Convert.ToString(System_testowy[Podzial_na_klasy1[kvp.Key][0]][Ostatnia_kolumna]));
            }
            Grid.Columns.Add("numerobiektow", "Number_of_object");
            Grid.Columns.Add("skutecznosc", "Accuracy");
            Grid.Columns.Add("pokrycie", "Coverage");
            for (int i = 0; i < Lista_klas.Count; i++)
            {
                int value;
                double acc_value;
                double cov_value;
                var pre_value = new Dictionary<int, int>();
                int value1;
                int value2;
                int key2;
                int key = Convert.ToInt16(System_testowy[Lista_klas[i][0]][Ostatnia_kolumna]);
                if (i == 0 && i < Lista_klas.Count - 1)
                {
                    key2 = Convert.ToInt16(System_testowy[Lista_klas[i + 1][0]][Ostatnia_kolumna]);
                }
                else
                {
                    key2 = Convert.ToInt16(System_testowy[Lista_klas[i - 1][0]][Ostatnia_kolumna]);
                }
                Accuracy.TryGetValue(key, out acc_value);
                Coverage.TryGetValue(key, out cov_value);
                Number_of_object.TryGetValue(key, out value);
                Slownik_predykcji.TryGetValue(key, out pre_value);
                pre_value.TryGetValue(key, out value1);
                pre_value.TryGetValue(key2, out value2);
                var Macierz_0_1 = new int[Lista_klas.Count];
                Grid.Rows.Add(Convert.ToString(System_testowy[Lista_klas[i][0]][Ostatnia_kolumna]), value1, value2, value, acc_value, cov_value);
            }
            int zmienna = 0;
            var tab = new double[Tpr.Count];
            foreach (var kvp in Tpr)
            {
                Tpr.TryGetValue(kvp.Key, out tab[zmienna]);
                zmienna++;
            }
            Grid.Rows.Add("True Positive Rate", tab[1], tab[0]);
        }
        string[] F_klasyfikacja(string[] Obiekt_testowy, string[][] System_treningowy, string Metryka_string, int K)
        {
            Metryki m = new Metryki();
            Odleglosc o = new Odleglosc();
            var Obiekt_sklasyfikowany = new string[Obiekt_testowy.Length];
            for (int i = 0; i < Obiekt_testowy.Length; i++)
            {
                Obiekt_sklasyfikowany[i] = Obiekt_testowy[i];
            }


            int Ostatnia_kolumna = Obiekt_sklasyfikowany.Length - 1;

            switch (Metryka_string)
            {
                case "Euklidesa":
                    var Slownik_po_metryce = new Dictionary<int, double>();
                    for (int i = 0; i < System_treningowy.Length; i++)
                    {
                        Slownik_po_metryce.Add(i, m.Metryka_Euklidesa(Obiekt_testowy, System_treningowy[i]));
                    }
                    string decyzja = o.F_najblizszy_obiekt(Slownik_po_metryce, K, System_treningowy);
                    if (decyzja == "!")
                    {
                        Obiekt_sklasyfikowany[Ostatnia_kolumna] = "!";
                    }
                    else
                    {
                        string[] obiekt = System_treningowy[Convert.ToInt16(decyzja)];

                        Obiekt_sklasyfikowany[Ostatnia_kolumna] = obiekt[Ostatnia_kolumna];
                    }
                    break;
                case "Manhattan":
                    var Slownik_po_metryce1 = new Dictionary<int, double>();
                    for (int i = 0; i < System_treningowy.Length; i++)
                    {
                        Slownik_po_metryce1.Add(i, m.Metryka_Manhattana(Obiekt_testowy, System_treningowy[i]));
                    }
                    string decyzja1 = o.F_najblizszy_obiekt(Slownik_po_metryce1, K, System_treningowy);
                    if (decyzja1 == "!")
                    {
                        Obiekt_sklasyfikowany[Ostatnia_kolumna] = "!";
                    }
                    else
                    {
                        string[] obiekt = System_treningowy[Convert.ToInt16(decyzja1)];

                        Obiekt_sklasyfikowany[Ostatnia_kolumna] = obiekt[Ostatnia_kolumna];
                    }
                    break;
                case "Canberra":
                    var Slownik_po_metryce2 = new Dictionary<int, double>();
                    for (int i = 0; i < System_treningowy.Length; i++)
                    {
                        Slownik_po_metryce2.Add(i, m.Metryka_Canberra(Obiekt_testowy, System_treningowy[i]));
                    }
                    string decyzja2 = o.F_najblizszy_obiekt(Slownik_po_metryce2, K, System_treningowy);
                    if (decyzja2 == "!")
                    {
                        Obiekt_sklasyfikowany[Ostatnia_kolumna] = "!";
                    }
                    else
                    {
                        string[] obiekt = System_treningowy[Convert.ToInt16(decyzja2)];

                        Obiekt_sklasyfikowany[Ostatnia_kolumna] = obiekt[Ostatnia_kolumna];
                    }
                    break;
                case "Czebyszewa":
                    var Slownik_po_metryce3 = new Dictionary<int, double>();
                    for (int i = 0; i < System_treningowy.Length; i++)
                    {
                        Slownik_po_metryce3.Add(i, m.Metryka_Czebyszewa(Obiekt_testowy, System_treningowy[i]));
                    }
                    string decyzja3 = o.F_najblizszy_obiekt(Slownik_po_metryce3, K, System_treningowy);
                    if (decyzja3 == "!")
                    {
                        Obiekt_sklasyfikowany[Ostatnia_kolumna] = "!";
                    }
                    else
                    {
                        string[] obiekt = System_treningowy[Convert.ToInt16(decyzja3)];
                        Obiekt_sklasyfikowany[Ostatnia_kolumna] = obiekt[Ostatnia_kolumna];
                    }
                    break;
                case "Pearsona":
                    var Slownik_po_metryce4 = new Dictionary<int, double>();
                    for (int i = 0; i < System_treningowy.Length; i++)
                    {
                        Slownik_po_metryce4.Add(i, m.Metryka_Czebyszewa(Obiekt_testowy, System_treningowy[i]));
                    }
                    string decyzja4 = o.F_najblizszy_obiekt(Slownik_po_metryce4, K, System_treningowy);
                    if (decyzja4 == "!")
                    {
                        Obiekt_sklasyfikowany[Ostatnia_kolumna] = "!";
                    }
                    else
                    {
                        string[] obiekt = System_treningowy[Convert.ToInt16(decyzja4)];
                        Obiekt_sklasyfikowany[Ostatnia_kolumna] = obiekt[Ostatnia_kolumna];
                    }
                    break;
            }
            return Obiekt_sklasyfikowany;
        }
        static int F_min_k(Dictionary<List<int>, int> Slownik_czestosci)
        {
            int min = 10000;
            foreach (var kvp in Slownik_czestosci)
            {
                if (min > kvp.Value)
                {
                    min = kvp.Value;
                }
            }
            return min;
        }
        static Dictionary<int,List<int>> F_podzial_na_klasy(string[][] System_testowy)
        {
            int[] Kolumna_decyzyjna = new int[System_testowy.Length];
            var Lista_klasy = new List<int>();
            List<int> Unikalne = new List<int>();
            var Podzielone_klasy = new Dictionary<int, List<int>>();
            Kolumna_decyzyjna = F_kolumna(System_testowy, (System_testowy[0].Length - 1));
            Unikalne = F_unikalne(Kolumna_decyzyjna);
            for (int j = 0; j < Unikalne.Count; j++)
            {
                for (int i = 0; i < System_testowy.Length; i++)
                {
                    if (Kolumna_decyzyjna[i] == Unikalne[j])
                    {
                        Lista_klasy.Add(i);
                    }
                }
                Podzielone_klasy.Add(Unikalne[j],Lista_klasy);
                Lista_klasy = new List<int>();
            }
            return Podzielone_klasy;//mam Liste zawierajaca liste obiektow podzielona na klasy decyzyjne
        }
        static List<List<int>> F_podzielone_klasy(string[][] System_testowy)
        {
            int[] Kolumna_decyzyjna = new int[System_testowy.Length];
            var Lista_klasy = new List<int>();
            List<int> Unikalne = new List<int>();
            Kolumna_decyzyjna = F_kolumna(System_testowy, (System_testowy[0].Length - 1));
            Unikalne = F_unikalne(Kolumna_decyzyjna);
            var Lista_klas = new List<List<int>>();
            for (int j = 0; j < Unikalne.Count; j++)
            {
                for (int i = 0; i < System_testowy.Length; i++)
                {
                    if (Kolumna_decyzyjna[i] == Unikalne[j])
                    {
                        Lista_klasy.Add(i);
                    }
                }
                Lista_klas.Add(Lista_klasy);
                Lista_klasy = new List<int>();
            }
            return Lista_klas;//mam Liste zawierajaca liste obiektow podzielona na klasy decyzyjne
        }
        static int[] F_kolumna(string[][] tab, int n_kolumny)
        {
            int[] kolumna = new int[tab.Length];
            for (int i = 0; i < kolumna.Length; i++)
            {
                kolumna[i] = Convert.ToInt16(tab[i][n_kolumny]);
            }
            return kolumna;
        }
        static List<int> F_unikalne(int[] tab)
        {
            List<int> lista = new List<int>();
            lista.Add(tab[0]);
            for (int i = 1; i < tab.Length; i++)
            {
                if (!lista.Contains(tab[i]))
                    lista.Add(tab[i]);
            }
            return lista;
        }
        static Dictionary<List<int>, int> F_czestosc(List<List<int>> Lista)
        {
            var sl = new Dictionary<List<int>, int>();
            for (int i = 0; i < Lista.Count; i++)
            {
                sl.Add(Lista[i], 0);
            }
            for (int i = 0; i < Lista.Count; i++)
                for (int j = 0; j < Lista[i].Count; j++)
                {
                    sl[Lista[i]]++;
                }
            return sl;
        }
        public Form2(string[][] System_testowy, string[][] System_treningowy)
        {
            InitializeComponent();
            string[][] System_testowy_sklasyfikowany = new string[System_testowy.Length][];
            var Lista_klas = new List<List<int>>();
            var Slownik_czestosci = new Dictionary<List<int>, int>();
            var Podzielone_klasy = new Dictionary<int, List<int>>();
            Podzielone_klasy = F_podzial_na_klasy(System_testowy);
            Podzial_na_klasy1 = Podzielone_klasy;
            int K = 0;
            Combobax.Items.Add("Euklidesa");
            Combobax.Items.Add("Manhattan");
            Combobax.Items.Add("Canberra");
            Combobax.Items.Add("Czebyszewa");
            Combobax.Items.Add("Pearsona");
            Lista_klas = F_podzielone_klasy(System_treningowy);
            var lista = new List<List<int>>();
            lista = F_podzielone_klasy(System_testowy);
            Slownik_czestosci = F_czestosc(Lista_klas);
            K = F_min_k(Slownik_czestosci);
            Nup.Maximum = K;
            Combobax.SelectedIndex = 0;
            System_testowy1 = System_testowy;
            System_treningowy1 = System_treningowy;
            lista1 = lista;
            Ostatnia_kolumna1 = System_testowy[0].Length - 1; ;
        }
        string[][] System_testowy1;
        string[][] System_treningowy1;
        List<List<int>> lista1;
        Dictionary<int, List<int>> Podzial_na_klasy1;
        int Ostatnia_kolumna1;
        private void Form2_Load(object sender, EventArgs e)
        {       }
        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {       }
        private void bt1_Click(object sender, EventArgs e)
        {
            string Metryka_string;
            int K1;
            K1 = Convert.ToInt16(Nup.Value);
            Metryka_string = Combobax.SelectedItem.ToString();
            string[][] System_testowy_sklasyfikowany = new string[this.System_testowy1.Length][];
            for (int i = 0; i < this.System_testowy1.Length; i++)
            {
                System_testowy_sklasyfikowany[i] = F_klasyfikacja(System_testowy1[i], System_treningowy1, Metryka_string, K1);
            }
            Grid.Rows.Clear();
            Grid.Columns.Clear();
            Grid.Refresh();
            PopulateDataGridView(System_testowy_sklasyfikowany, System_testowy1, lista1);
        }
    }
}
