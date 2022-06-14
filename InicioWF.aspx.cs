using Microsoft.Ajax.Utilities;
using SoftLoans.Capas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoansDAL;

namespace SoftLoans
{
    public partial class InicioWF : System.Web.UI.Page
    {
        //Tarea por hacer
        //Colocar tecaldo solo numerico en los cambios Texbox
        //Agrandar botones del pie de la pantalla y alinear.
        //Quitar el numero 2 que sael en el nombre de la loteria l final, en la ventana Facturacion
        //

        VersionDALL versionDALL = new VersionDALL();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "GenerdorIDUnico();", true);
            }
            RFVUser.EnableClientScript = false;

            TbUser.Attributes.Add("OnKeyPress", "return disableEnterKey(event)");
            //TbUser.Attributes["onchange"] = "if ( IsValid(this) == false ) return;";
            RFVUser.EnableClientScript = false;
            lbVersion.InnerText = versionDALL.version;
            // Console.WriteLine("Slider 2");
            Page.SetFocus(TbUser);
        }
      
        protected void btnSlide2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Slider 2");

        }
        protected void BtnIniciar_Click(object sender, EventArgs e)
        {
            if (RFVUser.IsValid)
                Iniciar();

        }
        protected void Iniciar()
        {
            LoginDAL loginDAL = new LoginDAL();
            List<LoginDAL> listLoginDAL = new List<LoginDAL>();
            loginDAL.UserName = TbUser.Text;
            listLoginDAL = loginDAL.Search();
            if (listLoginDAL.Count > 0)
            {
                if (listLoginDAL[0].UserPassword == TbPassword.Text)
                {
                    if (String.IsNullOrEmpty(listLoginDAL[0].DeviceID))
                    {
                        loginDAL.UserID = listLoginDAL[0].UserID;
                        loginDAL.DeviceID = myHiddenInput.Value;
                        if (loginDAL.UpadetDeviceID())
                        {
                            Session["DatosUsuario"] = listLoginDAL[0];
                            if (listLoginDAL[0].IsAdministrator)
                            {

                                //Response.Redirect("TicketsListWF.aspx");
                                Response.Redirect("MenuWF.aspx");
                                //Notificaion("Lo sentimos!", "Las opciones administrativas aun no estan disponible, intente mas tarde", "warning");
                            }
                            else
                            {

                                Response.Redirect("ClienteWF.aspx");
                            }
                        }
                        else
                        {
                            Notificaion("Error!", "Algo salio mal, mas detalles: " + loginDAL.ErrorDescription, "error");
                        }



                    }
                    else if (listLoginDAL[0].DeviceID == myHiddenInput.Value)
                    {
                        Session["DatosUsuario"] = listLoginDAL[0];
                        if (listLoginDAL[0].IsAdministrator)
                        {
                            //Global.Instance().DataBaseName = listLoginDAL[0].DataBaseName;
                            //Response.Redirect("TicketsListWF.aspx");
                            Response.Redirect("MenuWF.aspx");
                            //Notificaion("Lo sentimos!", "Las opciones administrativas aun no estan disponible, intente mas tarde", "warning");
                        }
                        else
                        {
                            // Global.Instance().DataBaseName = listLoginDAL[0].DataBaseName;
                            Response.Redirect("ClienteWF.aspx");
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Error!','El usuario actual ya esta registrado en otro dispositivo o navegador','error');", true);
                        TbUser.Focus();
                    }



                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Error!','Clave incorrecta','error');", true);
                    if (TbUser.Text != "")
                    {
                        TbPassword.Focus();
                    }
                }
            }
            else
            {
                //string script = string.Format("swal({title: 'Good job!', text: 'You clicked the button!',icon: 'success'});");
                //ClientScript.RegisterStartupScript(this.GetType(), "sweetalert", script, true);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Error!','Usuario no existe','error');", true);
                this.TbUser.Focus();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), null,"AlertaUsuario('Error!','Usuario no existe','error')", true);
            }

        }
        public void Notificaion(string titulo, string texto, string icono)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Notificacion('" + texto + "', '" + titulo + "', '" + icono + "');", true);
        }

    }
}