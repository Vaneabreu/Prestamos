using Loans.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftLoans
{
    public partial class GaranteWF : System.Web.UI.Page
    {
        LoginDAL loginDAL = new LoginDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DatosUsuario"] != null)
            {
                loginDAL = (LoginDAL)Session["DatosUsuario"];
            }
            else
            {
                Response.Redirect("InicioWF.aspx");
            }

            if (!IsPostBack)
            {
                //BtnBuscar.Attributes.Remove("disabled");
                //BtnEntradaSalida.Attributes.Remove("disabled");
                //DivEntradaSalida.Style.Add("display", "none");
                //DivGridView.Style.Add("display", "block");
                Bloqueo();
                if (GvGarante.Controls.Count == 0)
                {
                    GvGarante.DataSource = null;
                    GvGarante.DataBind();
                    Cargar();

                }
            }
            if (loginDAL.IsAdministrator == false)
            {
                ocultarOpciones();
            }

        }
        public void ocultarOpciones()
        {
            APrestamos.Style.Add("display", "none");
            AClientes.Style.Add("display", "none");
            AGarantes.Style.Add("display", "none");
           
            AConfiguracion.Style.Add("display", "none");
        }
        /**Inicio Botones Menu Usuario **********************/
        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuWF.aspx");

        }
        protected void BtnPrestamos_Click(object sender, EventArgs e)
        {
            Response.Redirect("PrestamoCrearWF.aspx");
        }
        protected void BtnClientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClienteWF.aspx");
        }
        protected void BtnGarante_Click(object sender, EventArgs e)
        {
            Response.Redirect("GaranteWF.aspx");
        }
        protected void BtnCobros_Click(object sender, EventArgs e)
        {

            Response.Redirect("ListadoCobrosWF.aspx");
        }
        protected void BtnBalanceCentral_Click(object sender, EventArgs e)
        {

            Response.Redirect("CentralMovimientosWF.aspx");
        }

        protected void BtnConPrestamos_Click(object sender, EventArgs e)
        {
            Response.Redirect("PrestamosWF.aspx");
        }
        protected void BtnVencidosProximoVencer_Click(object sender, EventArgs e)
        {

            Response.Redirect("ListadoPrestamosPendienteWF.aspx");
        }
        protected void BtnListPagos_Click(object sender, EventArgs e)
        {

        }
        protected void BtnGastos_Click(object sender, EventArgs e)
        {
            Response.Redirect("GastosWF.aspx");
        }
        protected void BtnListCuotas_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReporteCuotasWF.aspx");
        }

        protected void BtnUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsuariosWF.aspx");
        }
        protected void BtnNCF_Click(object sender, EventArgs e)
        {

            Response.Redirect("NcfWF.aspx");
        }
        protected void BtnAcciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccionesWF.aspx");

        }
        protected void BtnRutas_Click(object sender, EventArgs e)
        {

        }
        protected void BtnRutasCobradores_Click(object sender, EventArgs e)
        {
            Response.Redirect("RutasCobradorWF.aspx");
        }

        protected void BtnCerrarSeccion_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioWF.aspx");

        }
        /**FIn Botones Menu Usuario **********************/

        protected void BtnBuscar_ServerClick(object sender, EventArgs e)
        {
            Cargar();
        }
        protected void BtnNuevo_ServerClick(object sender, EventArgs e)
        {
            BloqueoNuevo();
            BtnBorrar.Visible = false;

        }
        protected void BtnCancelar_ServerClick(object sender, EventArgs e)
        {
            Bloqueo();
            Cargar();
        }
        protected void BtnGuardar_ServerClick(object sender, EventArgs e)
        {
            if (RFVNumeroDocumento.IsValid && RFVNombre.IsValid && RFVApellido.IsValid)
            {
                string respuesta = Guardar();
                if (respuesta == "")
                {
                    if (!String.IsNullOrEmpty(TbIdC.Text))
                    {
                        Notificaion("Proceso de Actualización!", "Proceso completado con exito.", "success");
                        Limpiar();
                    }
                    else
                    {
                        Notificaion("Proceso de Creación!", "Proceso completado con exito.", "success");
                        Limpiar();
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(TbIdC.Text))
                    {

                        Notificaion("Proceso de Actualización!", "Algo salio mal, mas detalles: " + respuesta, "error");

                    }
                    else
                    {
                        Notificaion("Proceso de Creación!", "Algo salio mal, mas detalles: " + respuesta, "error");
                    }

                }
            }


        }


        protected void GvGarante_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void GvGarante_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void GvGarante_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }
        protected void GvGarante_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (GvGarante.SelectedRow.RowIndex >= 0)
            {

                GuarantorDAL guarantorDAL = new GuarantorDAL();
                GuarantorEntity guarantorEntity = new GuarantorEntity();

                List<GuarantorEntity> listGuarantorEntity = new List<GuarantorEntity>();
                try
                {
                    BloqueoNuevo();

                    BtnBorrar.Visible = true;

                    guarantorEntity.ID = int.Parse(GvGarante.SelectedRow.Cells[0].Text);
                    listGuarantorEntity=guarantorDAL.Search(guarantorEntity,loginDAL);
                    TbIdC.Text = listGuarantorEntity[0].ID.ToString();
                    TbNombreC.Text = listGuarantorEntity[0].Name;
                    TbApellido.Text = listGuarantorEntity[0].LastName;
                    TbNumeroDocumentoC.Text = listGuarantorEntity[0].IdentificationNumber;
                    DropDownTipoDocumento.SelectedValue= listGuarantorEntity[0].IdentificationType;

                    TbDireccion.Text = listGuarantorEntity[0].Address;
                    TbTelefono.Text = listGuarantorEntity[0].Phone;
                    TbEstado.Text = listGuarantorEntity[0].Status;
                    TbEdad.Text = listGuarantorEntity[0].Age.ToString();
                    TbPosicion.Text = listGuarantorEntity[0].Position;
                    TbLugarTrabajo.Text = listGuarantorEntity[0].WorkPlace;
                    TbSalario.Text = listGuarantorEntity[0].Salary.ToString();
                    TbOtroSalario.Text = listGuarantorEntity[0].OtherSalary.ToString();
                    TbTiempoTrabajo.Text = listGuarantorEntity[0].TimeInWork;
                    TbNombreMadre.Text = listGuarantorEntity[0].MotherName;
                    TbNombrePadre.Text = listGuarantorEntity[0].FatherName;

                    //TbNombrePadre.Text = listGuarantorEntity[0].FatherName;
                    //guarantorEntity.RegistrationDate = DateTime.Now;

                }
                catch (Exception ex)
                {
                    Bloqueo();
                    Notificaion("Error!", "Algo salio mal, mas detalles: "+ex.Message, "error");
                }


            }

        }

        public void Notificaion(string titulo, string texto, string icono)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Notificacion('" + texto + "', '" + titulo + "', '" + icono + "');", true);
        }

        protected void Borrar(object sender, EventArgs e)
        {
            string dd = GvGarante.SelectedIndex.ToString();
        }
        public string Cargar()
        {
            string respuesta = "Algo salio mal";
            GuarantorDAL guarantorDAL = new GuarantorDAL();
            GuarantorEntity guarantorEntity = new GuarantorEntity();



            try
            {
                if (!String.IsNullOrEmpty(TbIdGarante.Text))
                    guarantorEntity.ID = int.Parse(TbIdGarante.Text);

                if (!String.IsNullOrEmpty(TbNumeroDocumento.Text))
                {
                    guarantorEntity.IdentificationNumber = TbNumeroDocumento.Text;
                    guarantorEntity.IdentificationType = DropDownTipoDocumento.SelectedValue.Trim();
                }

                if (!String.IsNullOrEmpty(TbNombre.Text))
                    guarantorEntity.Name = TbNombre.Text;

                GvGarante.DataSource = guarantorDAL.Search(guarantorEntity, loginDAL);
                GvGarante.DataBind();



                if (!string.IsNullOrEmpty(guarantorDAL.errorDescription))
                    respuesta = guarantorDAL.errorDescription;
                else
                    respuesta = "";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }

            guarantorDAL = null;
            guarantorEntity = null;
            return respuesta;
        }
        public string Guardar()
        {
            string respuesta = "Algo salio mal";
            GuarantorDAL guarantorDAL = new GuarantorDAL();
            GuarantorEntity guarantorEntity = new GuarantorEntity();



            try
            {
                if (string.IsNullOrEmpty(TbIdC.Text))
                {
                    guarantorEntity.ID = 0;
                }
                else
                {
                    guarantorEntity.ID = Convert.ToInt32(TbIdC.Text);
                }

                guarantorEntity.Name = TbNombreC.Text;
                guarantorEntity.LastName = TbApellido.Text;


                if (string.IsNullOrEmpty(TbDireccion.Text))
                {
                    guarantorEntity.Address = "";
                }
                else
                {
                    guarantorEntity.Address = TbDireccion.Text;
                }

                if (string.IsNullOrEmpty(TbTelefono.Text))
                {
                    guarantorEntity.Phone = "";
                }
                else
                {
                    guarantorEntity.Phone = TbTelefono.Text;
                }

                if (string.IsNullOrEmpty(TbEstado.Text))
                {
                    guarantorEntity.Status = "";
                }
                else
                {
                    guarantorEntity.Status = TbEstado.Text;
                }

                if (string.IsNullOrEmpty(TbEdad.Text))
                {
                    guarantorEntity.Age = 0;
                }
                else
                {
                    guarantorEntity.Age = Convert.ToInt32(TbEdad.Text);
                }

                guarantorEntity.IdentificationType = DropDownTipoDocumento.SelectedValue.Trim();
                guarantorEntity.IdentificationNumber = TbNumeroDocumentoC.Text;


                if (string.IsNullOrEmpty(TbPosicion.Text))
                {
                    guarantorEntity.Position = "";
                }
                else
                {
                    guarantorEntity.Position = TbPosicion.Text;
                }
                if (string.IsNullOrEmpty(TbLugarTrabajo.Text))
                {
                    guarantorEntity.WorkPlace = "";
                }
                else
                {
                    guarantorEntity.WorkPlace = TbLugarTrabajo.Text;
                }

                if (string.IsNullOrEmpty(TbSalario.Text))
                {
                    guarantorEntity.Salary = 0;
                }
                else
                {
                    guarantorEntity.Salary = Convert.ToDecimal(TbSalario.Text);
                }

                if (string.IsNullOrEmpty(TbOtroSalario.Text))
                {
                    guarantorEntity.OtherSalary = 0;
                }
                else
                {
                    guarantorEntity.OtherSalary = Convert.ToDecimal(TbOtroSalario.Text);
                }


                if (string.IsNullOrEmpty(TbTiempoTrabajo.Text))
                {
                    guarantorEntity.TimeInWork = "";
                }
                else
                {
                    guarantorEntity.TimeInWork = TbTiempoTrabajo.Text;
                }

                if (string.IsNullOrEmpty(TbNombreMadre.Text))
                {
                    guarantorEntity.MotherName = "";
                }
                else
                {
                    guarantorEntity.MotherName = TbNombreMadre.Text;
                }

                if (string.IsNullOrEmpty(TbNombrePadre.Text))
                {
                    guarantorEntity.FatherName = "";
                }
                else
                {
                    guarantorEntity.FatherName = TbNombrePadre.Text;
                }


                guarantorEntity.RegistrationDate = DateTime.Now;

                if (string.IsNullOrEmpty(TbIdC.Text))
                {
                    guarantorDAL.Insert(guarantorEntity, loginDAL);
                }
                else
                {
                    guarantorDAL.Edit(guarantorEntity, loginDAL);
                }

                if (!string.IsNullOrEmpty(guarantorDAL.errorDescription))
                    respuesta = guarantorDAL.errorDescription;
                else
                    respuesta = "";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }

            guarantorDAL = null;
            guarantorEntity = null;
            return respuesta;
        }

        public void Limpiar()
        {

            TbIdGarante.Text = "";
            TbNumeroDocumento.Text = "";
            TbNombre.Text = "";

            TbIdC.Text = "";
            TbNumeroDocumentoC.Text = "";
            TbNombreC.Text = "";
            TbApellido.Text = "";
            TbTelefono.Text = "";
            TbEstado.Text = "";
            TbEdad.Text = "";
            TbPosicion.Text = "";
            TbLugarTrabajo.Text = "";
            TbSalario.Text = "";
            TbOtroSalario.Text = "";
            TbTiempoTrabajo.Text = "";
            TbNombrePadre.Text = "";
            TbNombreMadre.Text = "";
            TbDireccion.Text = "";
        }

        public void Bloqueo()
        {
            DivGaranteB.Style.Add("display", "block");
            DivGvGaranteB.Style.Add("display", "block");

            DivGaranteC.Style.Add("display", "none");

            TbIdGarante.Text = "";
            TbNumeroDocumento.Text = "";
            TbNombre.Text = "";

            TbIdC.Text = "";
            TbNumeroDocumentoC.Text = "";
            TbNombreC.Text = "";
            TbApellido.Text = "";
            TbTelefono.Text = "";
            TbEstado.Text = "";
            TbEdad.Text = "";
            TbPosicion.Text = "";
            TbLugarTrabajo.Text = "";
            TbSalario.Text = "";
            TbOtroSalario.Text = "";
            TbTiempoTrabajo.Text = "";
            TbNombrePadre.Text = "";
            TbNombreMadre.Text = "";
            TbDireccion.Text = "";
        }
        public void BloqueoNuevo()
        {
            DivGaranteB.Style.Add("display", "none");
            DivGvGaranteB.Style.Add("display", "none");

            DivGaranteC.Style.Add("display", "block");

            TbIdGarante.Text = "";
            TbNumeroDocumento.Text = "";
            TbNombre.Text = "";

            TbIdC.Text = "";
            TbNumeroDocumentoC.Text = "";
            TbNombreC.Text = "";
            TbApellido.Text = "";
            TbTelefono.Text = "";
            TbEstado.Text = "";
            TbEdad.Text = "";
            TbPosicion.Text = "";
            TbLugarTrabajo.Text = "";
            TbSalario.Text = "";
            TbOtroSalario.Text = "";
            TbTiempoTrabajo.Text = "";
            TbNombrePadre.Text = "";
            TbNombreMadre.Text = "";
            TbDireccion.Text = "";
        }

        protected void BtnBorrar_ServerClick(object sender, EventArgs e)
        {
            GuarantorDAL guarantorDAL = new GuarantorDAL();
            GuarantorEntity guarantorEntity = new GuarantorEntity();
            guarantorEntity.ID = int.Parse(TbIdC.Text);

            if (guarantorDAL.Delete(guarantorEntity.ID, loginDAL))
            {
                Bloqueo();
                Cargar();
            }
            else
            {
                Notificaion("Error!", "Algo salio mal, mas detalles: " + guarantorDAL.errorDescription, "error");

            }



        }
    }
}