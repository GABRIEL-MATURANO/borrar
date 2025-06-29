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
    public class DatosInscripcion : DatosConexionBD
    {
        public int abmInscripcion(string accion, Inscripcion objInscripcion)
        {
            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Alta")
                orden = "insert into Inscripcion values (" + objInscripcion.id +
                                                         ",'" + objInscripcion.activo + "');";
            if (accion == "Modificar")
                orden = "update Inscripcion set Activo='" + objInscripcion.activo +
                      "' where Id = " + objInscripcion.id + "; ";
            // NO falta la orden de borrar
            if (accion == "Baja")
                orden = "delete from Inscripcion where Id = " + objInscripcion.id + ";";

            OleDbCommand cmd = new OleDbCommand(orden, conexion);
            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Errror al tratar de guardar,borrar o modificar la inscripcion ", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }
        public DataSet listadoInscripcion(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")
                orden = "select * from Inscripcion where Id = " + int.Parse(cual) + ";";
            else
                orden = "select * from Inscripcion;";
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
                throw new Exception("Error al listar Inscripcion", e);
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
