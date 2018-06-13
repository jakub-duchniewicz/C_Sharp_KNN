using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaneZPlikuOkienko
{
    class Odleglosc
    {
        public Dictionary<int, double> F_Coverage(string[][] System_testowy_sklasyfikowany, string[][] System_testowy, Dictionary<int, int> Number_of_object, Dictionary<int, List<int>> Podzial_na_klasy)
        {
            int Ostatnia_kolumna = System_testowy_sklasyfikowany[0].Length - 1;
            var Coverage = new Dictionary<int, double>();
            foreach (var kvp in Podzial_na_klasy)
            {
                double zmienna = 0;

                for (int j = 0; j < Podzial_na_klasy[kvp.Key].Count; j++)
                {
                    if (System_testowy_sklasyfikowany[Podzial_na_klasy[kvp.Key][j]][Ostatnia_kolumna] == "!")
                    {
                        zmienna += 1;
                    }
                }
                if (zmienna == 0)
                {
                    Coverage.Add(kvp.Key, 1);
                }
                else
                {
                    int value;
                    Number_of_object.TryGetValue(kvp.Key, out value);
                    Coverage.Add(kvp.Key, zmienna / value);
                }
            }
            return Coverage;
        }
        public Dictionary<int, int> F_Number_of_object(string[][] System_testowy)
        {
            var Number_of_object = new Dictionary<int, int>();
            int Ostatnia_kolumna = System_testowy[0].Length - 1;
            for (int i = 0; i < System_testowy.Length; i++)
            {
                if (!Number_of_object.ContainsKey(Convert.ToInt16(System_testowy[i][Ostatnia_kolumna])))
                {
                    Number_of_object.Add(Convert.ToInt16(System_testowy[i][Ostatnia_kolumna]), 0);
                }
            }
            for (int i = 0; i < System_testowy.Length; i++)
            {
                Number_of_object[Convert.ToInt16(System_testowy[i][Ostatnia_kolumna])]++;
            }
            return Number_of_object;
        }
        public Dictionary<int, double> F_Accuracy(string[][] System_testowy_sklasyfikowany, string[][] System_testowy, Dictionary<int, int> Number_of_object, Dictionary<int, List<int>> Podzial_na_klasy)
        {
            var Accuracy = new Dictionary<int, double>();
            int Ostatnia_kolumna = System_testowy_sklasyfikowany[0].Length - 1;
            foreach (var kvp in Podzial_na_klasy)
            {
                double zmienna = 0;
                for (int j = 0; j < Podzial_na_klasy[kvp.Key].Count; j++)
                {

                    if (System_testowy_sklasyfikowany[Podzial_na_klasy[kvp.Key][j]][Ostatnia_kolumna] != System_testowy[Podzial_na_klasy[kvp.Key][j]][Ostatnia_kolumna] && System_testowy_sklasyfikowany[Podzial_na_klasy[kvp.Key][j]][Ostatnia_kolumna] != "!")
                    {
                        zmienna += 1;//jezeli obiekt jest zle sklasyfikowany to dodaj 1
                    }
                }
                if (zmienna == 0)
                {
                    Accuracy.Add(kvp.Key, 1);
                }
                else
                {
                    int value;
                    Number_of_object.TryGetValue(kvp.Key, out value);
                    Accuracy.Add(kvp.Key, (zmienna / value));
                }
            }
            return Accuracy;
        }
        public Dictionary<int, double> F_Tpr(string[][] System_testowy, List<List<int>> Lista_klas, string[][] System_testowy_sklasyfikowany, Dictionary<int, List<int>> Podzial_na_klasy1)
        {
            var Tpr = new Dictionary<int, double>();
            int Ostatnia_kolumna = System_testowy_sklasyfikowany[0].Length - 1;
            var lista_klas_dec = new List<int>();
            var lista_klas1 = new List<List<int>>();
            for (int i = 0; i < Lista_klas.Count; i++)
                for (int j = 0; j < Lista_klas[i].Count; j++)
                {
                    if (!lista_klas_dec.Contains(Convert.ToInt16(System_testowy[Lista_klas[i][j]][Ostatnia_kolumna])))
                    {
                        lista_klas_dec.Add(Convert.ToInt16(System_testowy[Lista_klas[i][j]][Ostatnia_kolumna]));
                    }
                }
            var Tymczasowy_system_sklasyfikowany = new string[System_testowy_sklasyfikowany.Length][];
            for (int x = 0; x < Tymczasowy_system_sklasyfikowany.Length; x++)
            {
                Tymczasowy_system_sklasyfikowany[x] = new string[System_testowy_sklasyfikowany[0].Length];
                for (int xx = 0; xx < System_testowy_sklasyfikowany[0].Length; xx++)
                {
                    if (System_testowy_sklasyfikowany[x][Ostatnia_kolumna] != "!")
                        Tymczasowy_system_sklasyfikowany[x][xx] = System_testowy_sklasyfikowany[x][xx];
                    else
                    {
                        Tymczasowy_system_sklasyfikowany[x][xx] = "-1";
                    }
                }
            }
            var Podzial_na_klasy = new Dictionary<int, List<int>>();
            Podzial_na_klasy = F_podzial_na_klasy(Tymczasowy_system_sklasyfikowany);
            foreach (var kvp in Podzial_na_klasy)
            {
                double zmienna = 0;
                double X = 0;
                if (kvp.Key != -1)
                {
                    for (int j = 0; j < Podzial_na_klasy[kvp.Key].Count; j++)
                    {
                        if ((System_testowy_sklasyfikowany[Podzial_na_klasy[kvp.Key][j]][Ostatnia_kolumna] != System_testowy[Podzial_na_klasy[kvp.Key][j]][Ostatnia_kolumna] /*&& System_testowy_sklasyfikowany[lista_klas1[i][j]][Ostatnia_kolumna] != "!"*/))
                        {
                            zmienna += 1;
                        }
                        else if (System_testowy_sklasyfikowany[Podzial_na_klasy[kvp.Key][j]][Ostatnia_kolumna] == System_testowy[Podzial_na_klasy[kvp.Key][j]][Ostatnia_kolumna])
                        {
                            X += 1;
                        }
                    }
                    if (X != 0)
                        Tpr.Add(kvp.Key, X / (X + zmienna));
                    else
                        Tpr.Add(kvp.Key, 0);
                }
            }
            if (Podzial_na_klasy.ContainsKey(-1) && Podzial_na_klasy.Count == 2)
            {
                foreach (var kvp in Podzial_na_klasy1)
                {
                    if (!Podzial_na_klasy.ContainsKey(kvp.Key))
                    {
                        Tpr.Add(kvp.Key, 0);
                    }
                }
            }
            return Tpr;
        }
        public Dictionary<int, Dictionary<int, int>> F_Slownik_predykcji(string[][] System_testowy_sklasyfikowany, string[][] System_testowy, Dictionary<int, List<int>> Podzial_na_klasy)
        {
            int Ostatnia_kolumna = System_testowy_sklasyfikowany[0].Length - 1;
            var Slownik_predykcji = new Dictionary<int, Dictionary<int, int>>();//key,key,value//decyzja tst,decyzja po klasyfikacji)                                                                                //  Slownik_predykcji
            for (int j = 0; j < Podzial_na_klasy.Count; j++)
            {
                Slownik_predykcji.Add(Convert.ToInt16(System_testowy[j][Ostatnia_kolumna]), new Dictionary<int, int>());
            }
            for (int j = 0; j < Podzial_na_klasy.Count; j++)
            {
                for (int i = 0; i < System_testowy.Length; i++)
                {
                    if (!Slownik_predykcji[(Convert.ToInt16(System_testowy[j][Ostatnia_kolumna]))].ContainsKey((Convert.ToInt16(System_testowy[i][Ostatnia_kolumna]))))
                    {
                        Slownik_predykcji[Convert.ToInt16(System_testowy[j][Ostatnia_kolumna])].Add(Convert.ToInt16(System_testowy[i][Ostatnia_kolumna]), 0);
                    }
                }
            }
            foreach (var kvp in Podzial_na_klasy)
            {
                for (int j = 0; j < Podzial_na_klasy[kvp.Key].Count; j++)
                {
                    if (System_testowy_sklasyfikowany[Podzial_na_klasy[kvp.Key][j]][Ostatnia_kolumna] != "!")
                        Slownik_predykcji[Convert.ToInt16(System_testowy[Podzial_na_klasy[kvp.Key][j]][Ostatnia_kolumna])][Convert.ToInt16(System_testowy_sklasyfikowany[Podzial_na_klasy[kvp.Key][j]][Ostatnia_kolumna])]++;
                }
            }
            return Slownik_predykcji;
        }
        public Dictionary<int, List<int>> F_podzial_na_klasy(string[][] System_testowy)
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
                Podzielone_klasy.Add(Unikalne[j], Lista_klasy);
                Lista_klasy = new List<int>();
            }
            return Podzielone_klasy;//mam Liste zawierajaca liste obiektow podzielona na klasy decyzyjne
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
        static string F_policz_ktora_klasa_najblizsza(Dictionary<int, List<double>> Slownik)
        {
            string jaka_klasa = "!";
            double wynik;
            var lista_v2 = new List<int>();
            var Lista = new List<double>();
            var Slownik_v2 = new Dictionary<int, double>();
            foreach (var kvp in Slownik)
            {
                double zmienna = 0;
                for (int j = 0; j < kvp.Value.Count; j++)
                {
                    zmienna += kvp.Value[j];
                }
                Slownik_v2.Add(kvp.Key, zmienna);
            }
            wynik = 10000;
            foreach (var kvp in Slownik_v2)
            {
                if (wynik > kvp.Value)
                {
                    wynik = kvp.Value;
                }
            }
            int pom = 0;
            foreach (var kvp in Slownik_v2)
            {

                if (wynik == kvp.Value)
                {
                    pom++;
                }

            }
            if (pom == Slownik_v2.Count)
            {
                jaka_klasa = "!";
            }
            else
            {
                foreach (var kvp in Slownik_v2)
                {
                    if (kvp.Value == wynik)
                    {
                        jaka_klasa = Convert.ToString(kvp.Key);
                    }
                }
            }
            return jaka_klasa;
        }
        public string F_najblizszy_obiekt(Dictionary<int, double> Slownik_po_metryce, int K, string[][] System_treningowy)
        {
            var Slownik_z_podzialem_na_klasy_zawierajacy_liste_k_najblizszych_sasiadow = new Dictionary<int, List<double>>();
            var lista_wybranych_sasiadow = new List<double>();
            var lista_podzialu = new List<int>();
            var lista = new List<double>();
            var Lista_klas_treningowych = new List<List<int>>();
            Lista_klas_treningowych = F_podzielone_klasy(System_treningowy);
            double min;
            string decyzja;
            for (int j = 0; j < Lista_klas_treningowych.Count; j++)
            {
                lista = new List<double>();
                lista_podzialu = Lista_klas_treningowych[j];
                min = 0;
                for (int ii = 0; ii < K; ii++)
                {
                    min = 1000;
                    for (int i = 0; i < lista_podzialu.Count; i++)
                    {

                        if (Slownik_po_metryce.ContainsKey(lista_podzialu[i]))
                        {
                            double value;
                            Slownik_po_metryce.TryGetValue(lista_podzialu[i], out value);
                            if (lista.Contains(value))
                            {

                            }
                            else if (min > value)
                            {
                                min = value;
                            }
                        }
                    }
                    lista.Add(min);
                }
                Slownik_z_podzialem_na_klasy_zawierajacy_liste_k_najblizszych_sasiadow.Add(lista_podzialu[0], lista);
            }
            decyzja = F_policz_ktora_klasa_najblizsza(Slownik_z_podzialem_na_klasy_zawierajacy_liste_k_najblizszych_sasiadow);
            return decyzja;
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
            return Lista_klas;
        }
    }
}
