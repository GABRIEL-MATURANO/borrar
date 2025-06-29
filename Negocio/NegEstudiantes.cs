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
    public class NegEstudiantes
    {
        

            DatosEstudiantes DatosEstudiantes = new DatosEstudiantes();
            public int abmEstudiantes(string accion, Estudiantes objEstudiantes)
            {
                return DatosEstudiantes.abmEstudiantes(accion, objEstudiantes);
            }
            public DataSet listadoEstudiantes(string cual)
            {
                return DatosEstudiantes.listadoEstudiantes(cual);

            }
       



    }
}