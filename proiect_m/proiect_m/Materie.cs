using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_m
{
    class Materie
    {
        private string denumire;
        private string an;
        private double nota_lab;
        private double nota_finala;
        private List<Prezentare> prezentari;

        public Materie(string denumire, string an, double nota_lab, List<Prezentare> prezentari)
        {
            this.denumire = denumire;
            this.an = an;
            this.nota_lab = nota_lab;
            this.prezentari = prezentari;
            if (calculMedie() != 0)
            {
                nota_finala = (nota_lab + calculMedie()) / 2;
            }
        }
        [Description("Denumire materie"), Category("Informatii materie")]
        public string Denumire
        {
            get { return denumire; }
        }
        [Description("Anul in care s-a studiat"), Category("Informatii materie")]
        public string An
        {
            get { return an; }
        }
        [Description("Nota la laborator"), Category("Informatii materie")]
        public double Nota_lab
        {
            get { return nota_lab; }
        }
        [Description("Prezentari"), Browsable(false)]
        public List<Prezentare> Prezentari
        {
            get { return prezentari; }
        }
        [Description("Nota finala"), Category("Informatii materie")]
        public double Nota_finala
        {
            get { return nota_finala; }
        }
        public double calculMedie()
        {
            double nota = 0;
            // int nr_note_trecere = 0;
            Prezentare p1 = prezentari.First<Prezentare>();
            Prezentare p2 = prezentari.Last<Prezentare>();
            //foreach (Prezentare pr in prezentari)
            //{
            if (p1.Nota_examen >= 5)
            {
                nota = p1.Nota_examen;
            }
            else
            {
                if (p2.Nota_examen >= 5)
                {
                    nota = p2.Nota_examen;
                }

            }

            //}
            /* if (nr_note_trecere >= 2)
             {
                 Prezentare p = prezentari.Last<Prezentare>();
                 nota = p.Nota_examen;
             }
             */
            return nota;
        }

    }
}
