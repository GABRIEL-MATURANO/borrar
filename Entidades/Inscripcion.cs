﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Inscripcion
    {
        private int Id;
        private bool Activo;
        private int IdEstudiante;  // <-- nuevo campo

        public Inscripcion()
        {
            Id = 0;
            Activo = false;
        }

        public int id
        {
            get { return Id; }
            set { Id = value; }
        }

        public bool activo
        {
            get { return Activo; }
            set { Activo = value; }


        }
        public int idEstudiante
        {
            get { return IdEstudiante; }
            set { IdEstudiante = value; }
        }
    }
}
