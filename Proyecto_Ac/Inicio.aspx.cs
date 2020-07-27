using CapaDatos;
using CapaDatos.Entidad;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Ac
{
    public partial class Inicio : System.Web.UI.Page
    {
        GestionBD objGestion;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargaAuto();
            }
        }
        void mostrarMensaje(string txtMensaje, bool Tipo)
        {
            if (Tipo)
            {
                lblExito.Text = txtMensaje;
                lblError.Text = "";
            }
            else
            {
                lblExito.Text = "";
                lblError.Text = txtMensaje;
            }
        }
        void cargaAuto()
        {
            DataTable datosAutos = new DataTable();
            objGestion = new GestionBD();
            datosAutos = objGestion.cargaAutos();

            if (datosAutos.Rows.Count > 0)
            {
                GridAutos.DataSource = datosAutos;
                GridAutos.DataBind();
            }
            else
            {
                datosAutos.Rows.Add(datosAutos.NewRow());
                GridAutos.DataSource = datosAutos;
                GridAutos.DataBind();
                GridAutos.Rows[0].Cells.Clear();
                GridAutos.Rows[0].Cells.Add(new TableCell());
                GridAutos.Rows[0].Cells[0].ColumnSpan = datosAutos.Columns.Count;
                GridAutos.Rows[0].Cells[0].Text = "No hay datos que mostrar.....";
                GridAutos.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        protected void GridAutos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                objGestion = new GestionBD();
                Autos objAutos = new Autos();
                objAutos.MARCA = (GridAutos.FooterRow.FindControl("txtMARCAPie") as TextBox).Text.Trim();
                objAutos.MODELO = (GridAutos.FooterRow.FindControl("txtMODELOPie") as TextBox).Text.Trim();
                objAutos.PAIS = (GridAutos.FooterRow.FindControl("txtPAISPie") as TextBox).Text.Trim();
                objAutos.COSTO = Convert.ToDouble((GridAutos.FooterRow.FindControl("txtCOSTOPie") as TextBox).Text.Trim());
                int resultado = objGestion.registrarAutos(objAutos); 

                if (resultado == 1)
                {
                    cargaAuto();
                    mostrarMensaje("Registro con exito", true);
                }
                else
                {
                    mostrarMensaje("Existe un error en el registro de la persona", false);

                }

            }
        }

        protected void GridAutos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridAutos.EditIndex = e.NewEditIndex;
            cargaAuto();
        }

        protected void GridAutos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridAutos.EditIndex = -1;
            cargaAuto();
        }

        protected void GridAutos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            objGestion = new GestionBD();
            Autos objAutos = new Autos();
            objAutos.MARCA = (GridAutos.Rows[e.RowIndex].FindControl("txtMARCA") as TextBox).Text.Trim();
            objAutos.MODELO = (GridAutos.Rows[e.RowIndex].FindControl("txtMODELO") as TextBox).Text.Trim();
            objAutos.PAIS = (GridAutos.Rows[e.RowIndex].FindControl("txtPAIS") as TextBox).Text.Trim();
            objAutos.COSTO = Convert.ToDouble((GridAutos.Rows[e.RowIndex].FindControl("txtCOSTO") as TextBox).Text.Trim());
            objAutos.IDCARRO = Convert.ToInt32(GridAutos.DataKeys[e.RowIndex].Value.ToString());
            int resultado = objGestion.actualizarAutos(objAutos);
            GridAutos.EditIndex = -1;


            if (resultado == 1)
            {
                cargaAuto();
                mostrarMensaje("Actualización con exito", true);
            }
            else
            {
                mostrarMensaje("Existe un error en el registro de la persona", false);

            }
        }

        protected void GridAutos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            objGestion = new GestionBD();
            Autos objAutos = new Autos();
            objAutos.IDCARRO = Convert.ToInt32(GridAutos.DataKeys[e.RowIndex].Value.ToString());
            objGestion.eliminarAutos(objAutos);
            GridAutos.EditIndex = -1;
            cargaAuto();

            mostrarMensaje("Elimino con exito", true);
        }
    }
}