using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;

namespace Examen
{
    public partial class Examen : Page
    {
        private string cadenaConexion = "Data Source=LAPTOP_ASUS\\Efra_Vargas;Initial Catalog=Cuestionario_UPI;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFechaNacimiento.Text = DateTime.Today.ToShortDateString();
            }
        }

        protected void btnGuardarEncuesta_Click(object sender, EventArgs e)
        {
            if (CamposVacios())
            {
                MostrarMensaje("Todos los campos son obligatorios.");
                return;
            }

            if (!ValidarEdad())
            {
                MostrarMensaje("La edad debe estar entre 18 y 50 años.");
                return;
            }

            Encuesta encuesta = new Encuesta
            {
                NombreParticipante = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                CorreoElectronico = txtCorreo.Text,
                CarroPropio = radioSi.Checked ? "Si" : "No"
            };

            GuardarEncuestaBD(encuesta);

            MostrarMensaje("Encuesta guardada correctamente.");
            LimpiarCampos();
        }

        protected void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        protected void btnMostrarReporte_Click(object sender, EventArgs e)
        {
            Response.Write("Este es un reporte de encuestas.");
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        private bool CamposVacios()
        {
            return string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtCorreo.Text);
        }

        private bool ValidarEdad()
        {
            DateTime fechaNacimiento;
            if (!DateTime.TryParseExact(txtFechaNacimiento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaNacimiento))
            {
                return false;
            }

            int edad = DateTime.Today.Year - fechaNacimiento.Year;
            return edad >= 18 && edad <= 50;
        }


        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCorreo.Text = "";
            radioSi.Checked = false;
            radioNo.Checked = false;
        }

        private void MostrarMensaje(string mensaje)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{mensaje}');", true);
        }

        private void GuardarEncuestaBD(Encuesta encuesta)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string query = "INSERT INTO informacion (Nombre_Participante, Apellido, Fecha_Nacimiento, Correo_Electronico, Carro_Propio) " +
                               "VALUES (@Nombre_Participante, @Apellido, @Fecha_Nacimiento, @Correo_Electronico, @Carro_Propio)";

                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Nombre_Participante", encuesta.NombreParticipante);
                comando.Parameters.AddWithValue("@Apellido", encuesta.Apellido);
                comando.Parameters.AddWithValue("@Fecha_Nacimiento", encuesta.FechaNacimiento);
                comando.Parameters.AddWithValue("@Correo_Electronico", encuesta.CorreoElectronico);
                comando.Parameters.AddWithValue("@Carro_Propio", encuesta.CarroPropio);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }
    }

    public class Encuesta
    {
        public string NombreParticipante { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
        public string CarroPropio { get; set; }
    }
}


