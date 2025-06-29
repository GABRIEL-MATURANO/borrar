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
    public class DatosCalificacion : DatosConexionBD
    {
        public int abmCalificacion(string accion, Calificacion objCalificacion)
        {
            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Alta")
                orden = "insert into Calificacion values (" + objCalificacion.Id +
                                                         ",'" + objCalificacion.Nota + ",'" + "');";
            if (accion == "Modificar")
                orden = "update Calificacion set Nota='" + objCalificacion.Nota +
                      "' where Id = " + objCalificacion.Id + "; ";
            // NO falta la orden de borrar
            if (accion == "Baja")
                orden = "delete from Calificacion where Id = " + objCalificacion.Id + ";";

            OleDbCommand cmd = new OleDbCommand(orden, conexion);
            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Errror al tratar de guardar,borrar o modificar Estudiantes ", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }
        public DataSet listadoCalificacion(string cuals)
        {
            string orden = string.Empty;
            if (cuals != "Todos")
                orden = "select * from Calificacion where Id = " + int.Parse(cuals) + ";";
            else
                orden = "select * from Calificacion;";
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
                throw new Exception("Error al listar Calificacion", e);
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
