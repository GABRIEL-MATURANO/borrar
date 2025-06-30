using Entidades;
using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormInscripcion : Form
    {
        public Inscripcion objEntInsc = new Inscripcion();
        public NegInscripcion_ objNegInsc = new NegInscripcion_();

        public FormInscripcion()
        {
            InitializeComponent();
            this.Load += FormInscripcion_Load;

            dgvInscripcion.ColumnCount = 2;
            dgvInscripcion.Columns[0].HeaderText = "Id";
            dgvInscripcion.Columns[1].HeaderText = "Activo";

            dgvInscripcion.Columns[0].Width = 60;
            dgvInscripcion.Columns[1].Width = 50;

            dgvInscripcion.CellClick += dgvInscripcion_CellClick;
        }

        private void FormInscripcion_Load(object sender, EventArgs e)
        {
            LlenarDGV();
        }

        private void LlenarDGV()
        {
            dgvInscripcion.Rows.Clear();
            DataSet ds = objNegInsc.listadoInscripcion("Todos");

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string activoTexto = Convert.ToBoolean(dr["Activo"]) ? "Sí" : "No";

                    dgvInscripcion.Rows.Add(
                        dr["Id"].ToString(),
                        activoTexto
                    );
                }
                lblMensaje.Text = "";
            }
            else
            {
                lblMensaje.Text = "No hay inscripciones cargadas en el sistema.";
            }
        }

        private void dgvInscripcion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvInscripcion.Rows[e.RowIndex];
                txtId.Text = fila.Cells[0].Value.ToString();

                string activoStr = fila.Cells[1].Value.ToString();
                chkActivo.Checked = (activoStr == "Sí");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            chkActivo.Checked = false;
            lblMensaje.Text = "";
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Inscripcion insc = TxtBox_a_Obj();
            if (insc == null) return;

            string accion = "Alta";
            if (insc.id > 0)
                accion = "Modificar";

            try
            {
                objNegInsc.abmInscripcion(accion, insc);
                MessageBox.Show("Guardado correctamente");
                LlenarDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text.Trim(), out int id))
            {
                MessageBox.Show("ID inválido.");
                return;
            }

            try
            {
                Inscripcion insc = new Inscripcion { id = id };
                objNegInsc.abmInscripcion("Baja", insc);
                MessageBox.Show("Eliminado correctamente");
                LlenarDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private Inscripcion TxtBox_a_Obj()
        {
            if (!int.TryParse(txtId.Text.Trim(), out int id))
            {
                MessageBox.Show("El ID debe ser numérico.");
                return null;
            }

            return new Inscripcion
            {
                id = id,
                activo = chkActivo.Checked
            };
        }
    }
}
