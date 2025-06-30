using Entidades;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosInscripcion : DatosConexionBD
    {
        public int abmInscripcion(string accion, Inscripcion objInscripcion)
        {
            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Alta")
                orden = "INSERT INTO Inscripcion (Id, Activo, IdEstudiante) VALUES ("
                        + objInscripcion.id + ", '" + objInscripcion.activo + "', " + objInscripcion.idEstudiante + ");";
            if (accion == "Modificar")
                orden = "update Inscripcion set Activo='" + objInscripcion.activo +
                      "' where Id = " + objInscripcion.id + objInscripcion.idEstudiante + "; ";
            // NO falta la orden de borrar
            if (accion == "Baja")
                orden = "delete from Inscripcion where Id = " + objInscripcion.id + objInscripcion.idEstudiante +  ";";

            SqlCommand cmd = new SqlCommand(orden, conexion);
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
            SqlCommand cmd = new SqlCommand(orden, conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
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
