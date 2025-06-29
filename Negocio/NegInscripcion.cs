using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using Entidades;

namespace Negocios
{
    public class NegInscripcion_
    {
        DatosInscripcion DatosInscripcion = new DatosInscripcion();

        public int abmInscripcion(string accion, Inscripcion objInscripcion)
        {
            return DatosInscripcion.abmInscripcion(accion,  objInscripcion);
        }
        public DataSet listadoInscripcion(string cual)
        {
            return DatosInscripcion.listadoInscripcion(cual);
        }
    }
}
