using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaneZPlikuOkienko
{
    class Metryki //sdd
    {
       public double Metryka_Euklidesa(string[] Obiekt_testowy, string[] Obiekt_treningowy)
        {
            double wynik;
            double zmienna = 0;
            for (int i = 0; i < Obiekt_testowy.Length - 1; i++)
            {
                zmienna += Math.Pow((Convert.ToDouble(Obiekt_testowy[i]) - Convert.ToDouble(Obiekt_treningowy[i])), 2);
            }
            wynik = Math.Sqrt(zmienna);
            return wynik;
        }
       public double Metryka_Manhattana(string[] Obiekt_testowy, string[] Obiekt_treningowy)
        {
            double wynik;
            double zmienna = 0;
            for (int i = 0; i < Obiekt_testowy.Length - 1; i++)
            {
                zmienna += Math.Abs((Convert.ToDouble(Obiekt_testowy[i]) - Convert.ToDouble(Obiekt_treningowy[i])));
            }
            wynik = zmienna;
            return wynik;
        }
      public double Metryka_Canberra(string[] Obiekt_testowy, string[] Obiekt_treningowy)
        {
            double wynik;
            double zmienna = 0;
            for (int i = 0; i < Obiekt_testowy.Length - 1; i++)
            {
                zmienna += Math.Abs(((Convert.ToDouble(Obiekt_testowy[i]) - Convert.ToDouble(Obiekt_treningowy[i]))) / ((Convert.ToDouble(Obiekt_testowy[i]) + Convert.ToDouble(Obiekt_treningowy[i]))));
            }
            wynik = zmienna;
            return wynik;
        }
     public double Metryka_Czebyszewa(string[] Obiekt_testowy, string[] Obiekt_treningowy)
        {
            double wynik;
            var zmienna = new List<double>();
            for (int i = 0; i < Obiekt_testowy.Length - 1; i++)
            {
                zmienna.Add(Math.Abs((Convert.ToDouble(Obiekt_testowy[i])) - Convert.ToDouble(Obiekt_treningowy[i])));
            }
            wynik = F_Max(zmienna);
            return wynik;
        }
     public double Metryka_Pearsona(string[] Obiekt_testowy, string[] Obiekt_treningowy)
        {
            double wynik;
            double x_=0;
            double y_=0;
            double n = 0;
            double r_x_y = 0;
            for (int i = 0; i < Obiekt_testowy.Length - 1; i++)
            {
                x_ += (Convert.ToDouble(Obiekt_testowy[i]));
                y_ += (Convert.ToDouble(Obiekt_treningowy[i]));
                n++;
            }
            x_ = (1 / n) * x_;
            y_ = (1 / n) * y_;
            double gora,gora1,dol,dol1 = 0;
           
            for (int i = 0; i < Obiekt_testowy.Length - 1; i++)
            {
                gora = ((Convert.ToDouble(Obiekt_testowy[i])) - x_);
                dol = Math.Sqrt((1 / n) * Math.Pow(Convert.ToDouble(Obiekt_testowy[i]) ,- x_));
                gora1 = ((Convert.ToDouble(Obiekt_treningowy[i])) - y_);
                dol1 = Math.Sqrt((1 / n) * Math.Pow(Convert.ToDouble(Obiekt_treningowy[i]), -y_));
                r_x_y += ((gora/dol)*(gora1/dol1));
            }
            r_x_y = Math.Abs((1 / n) * r_x_y);
            wynik = r_x_y;
            return wynik;
        }
      static double F_Max(List<double> lista)
        {
            double max = 0;
            for (int i = 0; i < lista.Count; i++)
                if (max < lista[i])
                {
                    max = lista[i];
                }
            return max;
        }
    }
}
