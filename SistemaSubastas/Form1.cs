using SistemaSubastas.App;
using SistemaSubastas.Domain;
using SistemaSubastas.Domain.Subastas;
using SistemaSubastas.Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaSubastas
{
    public partial class Form1 : Form
    {
        private readonly SubastaService _servicio = new SubastaService();
        private Subasta? _subastaActual;
        private List<Subasta> _listaFiltrada = new();

        private bool EsModoEspectador =>
            cmbTipoUsuario.SelectedItem?.ToString() == "Espectador";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOfertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_subastaActual == null)
                    throw new Exception("Seleccione una subasta de la lista.");

                decimal monto = 0;

                // Descendente no necesita validar monto del textbox
                if (_subastaActual.TipoSubasta == "Descendente")
                {
                    monto = _subastaActual.PrecioActual;
                }
                else
                {
                    if (!decimal.TryParse(txtMonto.Text, out monto))
                        throw new Exception("Ingrese un monto numérico válido.");
                }

                var comprador = new Comprador("Usuario1");
                comprador.RealizarOferta(_subastaActual, monto);

                ActualizarInfoSubasta();
                ActualizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbTipoUsuario.Items.AddRange(new string[] { "Comprador", "Espectador",});
            cmbTipoSubasta.Items.AddRange(new string[] { "Ascendente", "Descendente", "Cerrada" });
            cmbTipoProducto.Items.AddRange(new string[] { "Electrónico", "Alimenticio", "Ropa" });

            _servicio.CargarDatosDemo();
            ActualizarGrid();

            timerSubasta.Interval = 3000; 
            timerSubasta.Start();
        }

        private void btnCrearSubasta_Click(object sender, EventArgs e)
        {
            dgvSubastas.Visible = true;
            lblProducto.Visible = true;
            lblPrecioFinal.Visible = true;
            lblGanador.Visible = true;
            txtMonto.Visible = true;
            btnOfertar.Visible = true;
            try
            {
                if (cmbTipoProducto.SelectedItem == null || cmbTipoSubasta.SelectedItem == null)
                    throw new Exception("Seleccione tipo de producto y tipo de subasta.");

                _servicio.CrearSubasta(
                    cmbTipoProducto.SelectedItem.ToString()!,
                    cmbTipoSubasta.SelectedItem.ToString()!
                );

                ActualizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvSubastas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (EsModoEspectador) return;
            if (e.RowIndex < 0 || e.RowIndex >= _servicio.Subastas.Count) return;

            _subastaActual = _listaFiltrada[e.RowIndex];
            _subastaActual.Iniciar();
            ActualizarInfoSubasta();

            btnOfertar.Text = _subastaActual.TipoSubasta == "Descendente"
                ? "Aceptar precio"
                : "Ofertar";
            txtMonto.Enabled = _subastaActual.TipoSubasta != "Descendente";
            txtMonto.Text = _subastaActual.TipoSubasta == "Descendente"
                ? "—"
                : "";
        }

        private void ActualizarInfoSubasta()
        {
            if (_subastaActual == null) return;

            lblProducto.Text = $"{_subastaActual.Producto.Nombre} ({_subastaActual.TipoSubasta})";

            decimal precioFinal = _subastaActual.Producto.CalcularPrecioFinal(_subastaActual.PrecioActual);
            lblPrecioFinal.Text = $"${precioFinal:N2}";

            lblGanador.Text = _subastaActual.Activa
                ? "Subasta en curso..."
                : (_subastaActual.Ganador?.Nombre ?? "Sin ganador");
        }
        private void ActualizarGrid()
        {
            int filaSeleccionada = dgvSubastas.CurrentCell?.RowIndex ?? -1;

            var lista = _servicio.Subastas.AsEnumerable();

            if (!EsModoEspectador && cmbTipoSubasta.SelectedItem != null)
            {
                string tipoSubasta = cmbTipoSubasta.SelectedItem.ToString()!;
                lista = lista.Where(s => s.TipoSubasta == tipoSubasta);
            }

            if (!EsModoEspectador && cmbTipoProducto.SelectedItem != null)
            {
                string tipoProducto = cmbTipoProducto.SelectedItem.ToString()!
                    .Replace("é", "e")   
                    .Replace("ó", "o");  
                lista = lista.Where(s =>
                    s.Producto.GetType().Name.Contains(tipoProducto));
            }

            _listaFiltrada = lista.ToList();

            dgvSubastas.DataSource = null;
            dgvSubastas.DataSource = _listaFiltrada
                .Select(s => new
                {
                    Producto = s.Producto.Nombre,
                    Tipo = s.TipoSubasta,
                    Categoría = s.Producto.GetType().Name.Replace("Producto", ""),
                    PrecioActual = $"${s.PrecioActual:N2}",
                    Estado = s.Activa ? "✅ Activa" : "🔒 Cerrada",
                    Ganador = s.Ganador?.Nombre ?? "-"
                }).ToList();

            if (filaSeleccionada >= 0 && filaSeleccionada < dgvSubastas.Rows.Count)
                dgvSubastas.Rows[filaSeleccionada].Selected = true;
        }

        private void cmbTipoSubasta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EsModoEspectador) return;
            lblTipoProducto.Visible = true;
            cmbTipoProducto.Visible = true;
            ActualizarGrid();
        }

        private void cmbTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EsModoEspectador) return;
            btnCrearSubasta.Visible = true;
            ActualizarGrid();
        }

        private void timerSubasta_Tick(object sender, EventArgs e)
        {
            foreach (var s in _servicio.Subastas.Where(x => x.Activa).ToList())
                s.Actualizar();

            ActualizarGrid();

            if (_subastaActual != null)
                ActualizarInfoSubasta();
        }

        private void cmbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EsModoEspectador)
            {
                _subastaActual = null;
                cmbTipoSubasta.SelectedIndex = -1;
                cmbTipoProducto.SelectedIndex = -1;

                dgvSubastas.Visible = true;

                txtMonto.Visible = false;
                btnOfertar.Visible = false;
                lblProducto.Visible = false;
                lblPrecioFinal.Visible = false;
                lblGanador.Visible = false;
                lblTipoSubasta.Visible = false;
                cmbTipoSubasta.Visible = false;
                lblTipoProducto.Visible = false;
                cmbTipoProducto.Visible = false;
                btnCrearSubasta.Visible = false;
   

                ActualizarGrid();
                return;
            }

            lblTipoSubasta.Visible = true;
            cmbTipoSubasta.Visible = true;
            ActualizarGrid();
        }
    }
}
