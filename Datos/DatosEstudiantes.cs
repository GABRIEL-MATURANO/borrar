using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
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
            {
                orden = "INSERT INTO Estudiantes VALUES (" + objEstudiantes.id +
                        ", '" + objEstudiantes.nombre + "', " + objEstudiantes.legajo + ");";
            }
            else if (accion == "Modificar")
            {
                orden = "UPDATE Estudiantes SET Nombre = '" + objEstudiantes.nombre +
                        "', Legajo = " + objEstudiantes.legajo +
                        " WHERE Id = " + objEstudiantes.id + ";";
            }
            else if (accion == "Baja")
            {
                orden = "DELETE FROM Estudiantes WHERE Id = " + objEstudiantes.id + ";";
            }
            else
            {
                throw new Exception("Acción inválida: " + accion);
            }

            SqlCommand cmd = new SqlCommand(orden, conexion);

            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al guardar, borrar o modificar Estudiantes", e);
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
                orden = "SELECT * FROM Estudiantes WHERE Id = " + int.Parse(cual) + ";";
            else
                orden = "SELECT * FROM Estudiantes;";

            SqlCommand cmd = new SqlCommand(orden, conexion);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                Abrirconexion();
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