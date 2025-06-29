using Entidades;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosMateria : DatosConexionBD
    {
        public int abmMateria(string accion, Materia objMateria)
        {
            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Alta")
                orden = "insert into Materia values (" + objMateria.Id +
                                                         ",'" + objMateria.NombreMateria + 
                                                         ",'" + objMateria.Codigo +
                                                         ",'" + objMateria.Profesor + "');";
            if (accion == "Modificar")
                orden = "update Materia set Id='" + objMateria.Id +
                      "' where Id = " + objMateria.Id + "; ";
            // NO falta la orden de borrar
            if (accion == "Baja")
                orden = "delete from Materia where Id = " + objMateria.Id + ";";

            OleDbCommand cmd = new OleDbCommand(orden, conexion);
            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Errror al tratar de guardar,borrar o modificar la materia ", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }
        public DataSet listadoMateria(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")
                orden = "select * from Materia where Id = " + int.Parse(cual) + ";";
            else
                orden = "select * from Materia;";
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
                throw new Exception("Error al listar Materias", e);
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
