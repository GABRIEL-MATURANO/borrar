using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Materia 
    {
        private int id;
        private string nombreMateria;
        private string profesor;
        private int codigo;

        public Materia()
        {
            id = 0;
            nombreMateria = string.Empty;
            profesor = string.Empty;
            codigo = 0;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string NombreMateria
        {
            get { return nombreMateria; }
            set { nombreMateria = value; }
        }
        public string Profesor
        {
            get { return profesor; }
            set { profesor = value; }
        }
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

    }
}
