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
    public class NegCalificacion
    {
        DatosCalificacion DatosCalificacion = new DatosCalificacion();
        public int abmCalificacion(string accion, Calificacion objCalificacion)
        {
            return DatosCalificacion.abmCalificacion(accion, objCalificacion);
        }
        public DataSet listadoCalificacion(string cual)
        {
            return DatosCalificacion.listadoCalificacion(cual);
        }
    }
}
