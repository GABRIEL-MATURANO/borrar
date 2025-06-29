using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using Entidades;

namespace Datos
{
    public class DatosEstudiantes : DatosConexionBD
    {
        public int abmEstudiantes(string accion, Estudiantes objEstudiantes)
        {
            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Alta")
                orden = "insert into Estudiantes values (" + objEstudiantes.id +
                                                         ",'" + objEstudiantes.nombre + ",'" + 
                                                                objEstudiantes.legajo  + "');";
            if (accion == "Modificar")
                orden = "update Estudiantes set Nombre='" + objEstudiantes.nombre +
                      "' where Id = "+ objEstudiantes.id + "; ";
            // NO falta la orden de borrar
            if (accion == "Baja")
                orden = "delete from Estudiantes where Id = " + objEstudiantes.id + ";";

            OleDbCommand cmd = new OleDbCommand(orden, conexion);
            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Errror al tratar de guardar,borrar o modificar Estudiantes ",e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }
        public DataSet listadoEstudiantes(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")
                orden = "select * from Estudiantes where Id = " + int.Parse(cual) + ";";
            else
                orden = "select * from Estudiantes;";
            OleDbCommand cmd = new OleDbCommand(orden, conexion);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter();
            try
            {
                Abrirconexion();
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("Error al listar Estudiantes", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return ds;
        }
    }
}
