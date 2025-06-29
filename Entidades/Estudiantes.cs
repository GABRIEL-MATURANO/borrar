using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estudiantes
    {
        private int Id;
        private string Nombre;
        private int Legajo;

        public Estudiantes()
        {
            Id = 0;
            Nombre = string.Empty;
            Legajo = 0;
        }

        public int id
        {
            get { return Id; }
            set { Id = value; }
        }
        public string nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }
        public int legajo
        {
            get { return Legajo; }
            set { Legajo = value; }
        }
    }
}
