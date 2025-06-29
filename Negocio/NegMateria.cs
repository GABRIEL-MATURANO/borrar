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
    public class NegMateria
    {

        DatosMateria datosMateria = new DatosMateria();

        
        public int abmMateria(string accion, Materia objMateria)
        {
            return datosMateria.abmMateria(accion, objMateria);
        }
        public DataSet listadoMateria(string cual)
        {
            return datosMateria.listadoMateria(cual);

        }
    }
}
