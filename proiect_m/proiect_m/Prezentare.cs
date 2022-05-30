using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_m
{
    class Prezentare
    {
        private string nr_prezentare;
        private double nota_examen;
        private DateTime data;

        public Prezentare(string nr_prezentare, double nota_examen, DateTime data)
        {
            this.nr_prezentare = nr_prezentare;
            this.nota_examen = nota_examen;
            this.data = data;
        }
        [Description("Numarul prezentarii"), Category("Informatii prezentare")]
        public string Nr_prezentare
        {
            get { return nr_prezentare; }
        }
        [Description("Nota la examen"), Category("Informatii prezentare")]
        public double Nota_examen
        {
            get { return nota_examen; }
        }
        [Description("Data examenului"), Category("Informatii prezentare")]
        public DateTime Data
        {
            get { return data; }
        }
    }
}
