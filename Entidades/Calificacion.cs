using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calificacion
    {
        private int id;
        private decimal nota;
        private DateTime FechaEvaluacion;

        public Calificacion()
        {
            id = 0;
            nota = 0;
            FechaEvaluacion = DateTime.Now;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public decimal Nota
        {
            get { return nota; }
            set { nota = value; }
        }
        
    }
}
