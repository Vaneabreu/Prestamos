using Loans.DAL;
using Loans.Entity;
using SoftLoans.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftLoans
{
    public partial class ClienteCrearWF : System.Web.UI.Page
    {
        public string codigo;
        LoginDAL loginDAL = new LoginDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DatosUsuario"] != null)
            {
                loginDAL = (LoginDAL)Session["DatosUsuario"];
                if (!IsPostBack)
                {
                    CargarDropDown();
                    CargarInicio();
                }
            }
            else
            {
                Response.Redirect("InicioWF.aspx");
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
            Response.Redirect("RutasWF.aspx");
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



        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
           

                Response.Redirect("ClienteWF.aspx");
            

        }
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {            

            if (RFVName.IsValid)
            {

                if (String.IsNullOrEmpty(TbCustomerID.Text))
                {
                    Guardar();
                }
                else
                {
                    Actuaizar();
                }
            }



        }

        protected void CargarDropDown()
        {
            RoutesDAL routesDAL = new RoutesDAL();
            RoutesEntity routesEntity = new RoutesEntity();
            try
            {

                DropDownListRuta.DataSource = routesDAL.Search(routesEntity, loginDAL);
                DropDownListRuta.DataValueField = "RouteID";
                DropDownListRuta.DataTextField = "Name";
                DropDownListRuta.DataBind();


            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: " + ex.Message + "','error');", true);
            }
            routesDAL = null;
            routesEntity = null;

        }

        protected void CargarInicio() 
        {
            RFVName.EnableClientScript = false;
     

            if (Session["Parametro"] != null)
            {
                CustomersDAL customersDAL = new CustomersDAL();
                CustomersEntity customersEntity = new CustomersEntity();
                customersEntity = (CustomersEntity)Session["Parametro"];

                customersDAL.dbm.DataSource = loginDAL.DataSource;
                customersDAL.dbm.User = loginDAL.UserName;
                customersDAL.dbm.Password = loginDAL.UserPassword;
                customersDAL.dbm.DataBase = loginDAL.DataBaseName;

                TbCustomerID.Text = customersEntity.ID.ToString();
                TbDocumentNumber.Text = customersEntity.IdentificationNumber;
                DropDownListDocumentType.SelectedValue = customersEntity.IdentificationType;
                TbName.Text = customersEntity.Name;
                TbLastName.Text = customersEntity.LastName;
                TbPhoneNumber.Text = customersEntity.Phone;
                DropDownListEstado.SelectedValue = customersEntity.Status;
                TbAdrress.Text = customersEntity.Address;
                TbPosition.Text = customersEntity.Position;
                TbLugarTrabajo.Text = customersEntity.WorkPlace;
                TbSalario.Text = customersEntity.Salary.ToString("N2").Replace(",","");
                TbOtroSalario.Text = customersEntity.OtherSalary.ToString("N2").Replace(",", "");
                TbNombreMadre.Text = customersEntity.MotherName;
                TbNombrePadre.Text = customersEntity.FatherName;
                TbDependientes.Text = customersEntity.Dependents;
                TbReferenciasPersonales.Text = customersEntity.PersonalReferences;
                TbReferenciasTrabajo.Text = customersEntity.WorkReferences;
                DropDownListRuta.SelectedValue = customersEntity.RouteID.ToString();
                DropDownListTipoMora.SelectedValue = customersEntity.AmountType;
                TbMontoMora.Text = customersEntity.LateAmount.ToString("N2");

                customersEntity = null;
                Session["Parametro"] = null;
            }
        }
        protected void Guardar()
        {
            CustomersDAL customersDAL = new CustomersDAL();
            CustomersEntity customersEntity = new CustomersEntity();
            customersDAL.dbm.DataSource = loginDAL.DataSource;
            customersDAL.dbm.User = loginDAL.UserName;
            customersDAL.dbm.Password = loginDAL.UserPassword;
            customersDAL.dbm.DataBase = loginDAL.DataBaseName;
            try
            {
                decimal salary = 0;
                decimal otherSalary = 0;
                decimal lateAmount = 0;
                decimal.TryParse(TbSalario.Text, out salary);
                decimal.TryParse(TbOtroSalario.Text, out otherSalary);
                decimal.TryParse(TbMontoMora.Text, out lateAmount);

                customersEntity.IdentificationNumber = String.IsNullOrEmpty(TbDocumentNumber.Text) ? "" : TbDocumentNumber.Text;
                customersEntity.IdentificationType = DropDownListDocumentType.SelectedValue;
                customersEntity.Name = String.IsNullOrEmpty(TbName.Text) ? "" : TbName.Text;
                customersEntity.LastName = String.IsNullOrEmpty(TbLastName.Text) ? "" : TbLastName.Text;
                customersEntity.Phone = String.IsNullOrEmpty(TbPhoneNumber.Text) ? "" : TbPhoneNumber.Text;
                customersEntity.Address = String.IsNullOrEmpty(TbAdrress.Text) ? "" : TbAdrress.Text;
                customersEntity.Status = DropDownListEstado.SelectedValue;
                customersEntity.Age = 0;
                customersEntity.Position = String.IsNullOrEmpty(TbPosition.Text) ? "" : TbPosition.Text;
                customersEntity.WorkPlace = String.IsNullOrEmpty(TbLugarTrabajo.Text) ? "" : TbLugarTrabajo.Text;
                customersEntity.Salary = salary;
                customersEntity.OtherSalary = otherSalary;
                customersEntity.TimeInWork = "";
                customersEntity.Dependents = String.IsNullOrEmpty(TbDependientes.Text) ? "" : TbDependientes.Text;
                customersEntity.PersonalReferences = String.IsNullOrEmpty(TbReferenciasPersonales.Text) ? "" : TbReferenciasPersonales.Text;
                customersEntity.WorkReferences = String.IsNullOrEmpty(TbReferenciasTrabajo.Text) ? "" : TbReferenciasTrabajo.Text;
                customersEntity.MotherName = String.IsNullOrEmpty(TbNombreMadre.Text) ? "" : TbNombreMadre.Text;
                customersEntity.FatherName = String.IsNullOrEmpty(TbNombrePadre.Text) ? "" : TbNombrePadre.Text;
                customersEntity.LateAmount = lateAmount;
                customersEntity.AmountType = DropDownListTipoMora.SelectedValue;
                customersEntity.UserMobileID = 0;
                customersEntity.RegistrationDate = DateTime.Now;
                customersEntity.BirthDate = DateTime.Now.AddYears(-18);
                customersEntity.RouteID = int.Parse(DropDownListRuta.SelectedItem.Value.ToString());

                if (customersDAL.Insert(customersEntity, loginDAL))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), null, "Confirmacion('Cliente creado con exito!','ClienteWF.aspx')", true);
                }
               


            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: " + ex.Message + "','error');", true);
            }
            customersDAL = null;

        }
        protected void Actuaizar()
        {
            
            CustomersDAL customersDAL = new CustomersDAL();
            CustomersEntity customersEntity = new CustomersEntity();
            customersDAL.dbm.DataSource = loginDAL.DataSource;
            customersDAL.dbm.User = loginDAL.UserName;
            customersDAL.dbm.Password = loginDAL.UserPassword;
            customersDAL.dbm.DataBase = loginDAL.DataBaseName;
            try
            {
                decimal salary = 0;
                decimal otherSalary = 0;
                decimal lateAmount = 0;
                decimal.TryParse(TbSalario.Text, out salary);
                decimal.TryParse(TbOtroSalario.Text, out otherSalary);
                decimal.TryParse(TbMontoMora.Text, out lateAmount);

                customersEntity.ID = String.IsNullOrEmpty(TbCustomerID.Text) ? 0 : int.Parse(TbCustomerID.Text);
                customersEntity.IdentificationNumber = String.IsNullOrEmpty(TbDocumentNumber.Text) ? "" : TbDocumentNumber.Text;
                customersEntity.IdentificationType = DropDownListDocumentType.SelectedValue;
                customersEntity.Name = String.IsNullOrEmpty(TbName.Text) ? "" : TbName.Text;
                customersEntity.LastName = String.IsNullOrEmpty(TbLastName.Text) ? "" : TbLastName.Text;
                customersEntity.Phone = String.IsNullOrEmpty(TbPhoneNumber.Text) ? "" : TbPhoneNumber.Text;
                customersEntity.Address = String.IsNullOrEmpty(TbAdrress.Text) ? "" : TbAdrress.Text;
                customersEntity.Status = DropDownListEstado.SelectedValue;
                customersEntity.Age = 0;
                customersEntity.Position = String.IsNullOrEmpty(TbPosition.Text) ? "" : TbPosition.Text;
                customersEntity.WorkPlace = String.IsNullOrEmpty(TbLugarTrabajo.Text) ? "" : TbLugarTrabajo.Text;
                customersEntity.Salary = salary;
                customersEntity.OtherSalary = otherSalary;
                customersEntity.TimeInWork = "";
                customersEntity.Dependents = String.IsNullOrEmpty(TbDependientes.Text) ? "" : TbDependientes.Text;
                customersEntity.PersonalReferences = String.IsNullOrEmpty(TbReferenciasPersonales.Text) ? "" : TbReferenciasPersonales.Text;
                customersEntity.WorkReferences = String.IsNullOrEmpty(TbReferenciasTrabajo.Text) ? "" : TbReferenciasTrabajo.Text;
                customersEntity.MotherName = String.IsNullOrEmpty(TbNombreMadre.Text) ? "" : TbNombreMadre.Text;
                customersEntity.FatherName = String.IsNullOrEmpty(TbNombrePadre.Text) ? "" : TbNombrePadre.Text;
                customersEntity.LateAmount = lateAmount;
                customersEntity.AmountType = DropDownListTipoMora.SelectedValue;
                customersEntity.UserMobileID = 0;
                customersEntity.RegistrationDate = DateTime.Now;
                customersEntity.BirthDate = DateTime.Now.AddYears(-18);
                customersEntity.RouteID = int.Parse(DropDownListRuta.SelectedItem.Value.ToString());

                if (customersDAL.Edit(customersEntity, loginDAL))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), null, "Confirmacion('Cliente actualizado con exito!','ClienteWF.aspx')", true);
                }



            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: " + ex.Message + "','error');", true);
            }
            customersDAL = null;

        }
    }
}