using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ventas.LogicaNegocio;
using VentasEntidades;

namespace Ventas_01
{
    public partial class Categorias : Form
    {
        List<Categoria> lista = null;
        LNCategoria nlCategoria = new LNCategoria();
        Categoria cat;
        bool nuevo = false;


        public Categorias()
        {
            InitializeComponent();
            ActivarControlDatos(GBDatos,false);
            CargarDatos();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void ActivarControlDatos(Control Contenedor,bool estado)
        {
            try
            {
                foreach (var item in Contenedor.Controls)
                {
                    if (item.GetType()==typeof(TextBox))
                    {
                        ((TextBox)item).Enabled = estado;
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void CargarDatos()
        {
            if (lista==null)
            {
                lista = nlCategoria.Listar();
            }
            if (lista.Count>0)
            {
                DGVDatos.Rows.Clear();
                for (int i=0;i<lista.Count;i++)
                {
                    DGVDatos.Rows.Add(lista[i].id,lista[i].Codigo, lista[i].Nombre, lista[i].Observacion);
                }
            }
        }
        private void LimpiarControl(Control Contenedor)
        {
            foreach (var item in Contenedor.Controls)
            {
                if (item.GetType()==typeof(TextBox))
                {
                    ((TextBox)item).Clear();
                }
            }
        }
        private void ActivarButton(bool Estado)
        {
            btnNuevo.Enabled = Estado;
            btnGrabar.Enabled = !Estado;
            btnEliminar.Enabled = Estado;
            btnSalir.Enabled = Estado;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo = true;
            ActivarControlDatos(GBDatos,true);
            btnEditar.Text = "Cancelar";
            ActivarButton(false);
            LimpiarControl(DGVDatos);
            txtCodigo.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            int n = -1;
            if (nuevo)
            {
                cat = new Categoria(0,txtCodigo.Text,txtNombre.Text,txtObservacion.Text);
                n = nlCategoria.Insertar(cat);
            }
            else
            {
                cat.Codigo = txtCodigo.Text;
                cat.Nombre = txtNombre.Text;
                cat.Observacion = txtObservacion.Text;
                n = nlCategoria.Actualizar(cat);
            }
            if (n>0)
            {
                MessageBox.Show("Datos grabados correctamente","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                ActivarControlDatos(GBDatos, false);ActivarButton(true);
                DGVDatos.Enabled = true;LimpiarControl(GBDatos);
                btnEditar.Text = "Editar";lista = nlCategoria.Listar();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Error al grabar","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            nuevo = false;
            if (btnEditar.Text=="Cancelar")
            {
                LimpiarControl(GBDatos);
                ActivarControlDatos(GBDatos,false);
                ActivarButton(true);DGVDatos.Enabled = true;
                btnEditar.Text = "Editar";

            }
            else
            {
                if (DGVDatos.RowCount>0)
                {
                    cat = nlCategoria.TraerPorId((int)DGVDatos[0,DGVDatos.CurrentRow.Index].Value);
                    txtCodigo.Text = cat.Codigo;
                    txtNombre.Text = cat.Nombre;
                    txtObservacion.Text = cat.Observacion;
                    ActivarControlDatos(GBDatos, true);
                    ActivarButton(false);
                    DGVDatos.Enabled = false;
                    btnEditar.Text = "Cancelar";
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (DGVDatos.RowCount>0)
            {
                cat = nlCategoria.TraerPorId((int)DGVDatos[0,DGVDatos.CurrentRow.Index].Value);
                DialogResult rpta = MessageBox.Show("Desea eliminar el registro","Eliminar",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (rpta==System.Windows.Forms.DialogResult.Yes)
                {
                    int n = nlCategoria.Eliminar(cat.id);
                    if (n>0)
                    {
                        MessageBox.Show("Registro eliminado","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        lista = nlCategoria.Listar();
                        CargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }
    }
}
