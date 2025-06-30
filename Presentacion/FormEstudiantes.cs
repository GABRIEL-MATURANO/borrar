using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocios;

namespace Presentacion
{
    public partial class FormEstudiantes : System.Windows.Forms.Form
    {
        public Estudiantes objEntEst = new Estudiantes();
        public NegEstudiantes objNegEst = new NegEstudiantes();

        

       

        // constructor
        public FormEstudiantes()
        {

            InitializeComponent();
            dgvEstudiantes.ColumnCount = 3;
            dgvEstudiantes.Columns[0].HeaderText = "Id";
            dgvEstudiantes.Columns[1].HeaderText = "Nombre";
            dgvEstudiantes.Columns[2].Name = "Legajo";
            dgvEstudiantes.Columns[0].Width = 60;
            dgvEstudiantes.Columns[1].Width = 50;
            dgvEstudiantes.Columns[2].Width = 100;

            LlenarDGV();
            
        }
        private void LlenarDGV()
        {
            dgvEstudiantes.Rows.Clear();
            DataSet ds = objNegEst.listadoEstudiantes("Todos");

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvEstudiantes.Rows.Add(dr["Id"].ToString(), dr["Nombre"].ToString(), dr["Legajo"].ToString());
                }
            }
            else
            {
                lblMensaje.Text = "No hay estudiantes cargados en el sistema.";
            }
        }

        private void TxtBox_a_Obj()
        {
            objEntEst.id = int.Parse(txtId.Text);
            objEntEst.nombre = txtNombre.Text;
            objEntEst.legajo = int.Parse(txtLegajo.Text);
        }

        private void Limpiar()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtLegajo.Text = "";
            txtId.Enabled = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int resultado = -1;
            TxtBox_a_Obj();
            resultado = objNegEst.abmEstudiantes("Modificar", objEntEst);

            if (resultado != -1)
            {
                lblMensaje.Text = "Estudiante modificado con éxito.";
                LlenarDGV();
                Limpiar();
                btnGrabar.Visible = true;
            }
            else
                lblMensaje.Text = "Error al modificar el estudiante.";
        }

        private void dvgEstudiantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataSet ds = new DataSet();
            objEntEst.id = Convert.ToInt32(dgvEstudiantes.CurrentRow.Cells[0].Value);
            ds = objNegEst.listadoEstudiantes(objEntEst.id.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtId.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                txtNombre.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();
                txtLegajo.Text = ds.Tables[0].Rows[0]["Legajo"].ToString();
                txtId.Enabled = false;
                btnGrabar.Visible = false;
            }

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLegajo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            int resultado = -1;
            TxtBox_a_Obj();
            resultado = objNegEst.abmEstudiantes("Alta", objEntEst);

            if (resultado == -1)
                lblMensaje.Text = "No se pudo grabar el estudiante.";
            else
            {
                lblMensaje.Text = "Estudiante grabado con éxito.";
                LlenarDGV();
                Limpiar();
            }

        }

        private void btnInscripcion_Click(object sender, EventArgs e)
        {
            FormInscripcion formInscripcion = new FormInscripcion();
            formInscripcion.Show(); // Abre la ventana como una ventana separada
        }
    }
}
