<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClienteCrearWF.aspx.cs"
    Inherits="SoftLoans.ClienteCrearWF" %>

<!DOCTYPE html>

<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <!-- Bootstrap CSS -->
    <link href="/Content/bootstrap.min.css" rel="stylesheet" type="text/css">
    
    <!-- SweetAlert -->
    <script src="/Scripts/SweetAlert.min.js"></script>
    <link href="/Content/sweetalert/sweet-alert.css" rel="stylesheet" />


</head>

<body>

    <script src="/Scripts/loansApp.js"></script>
    <script src="/Scripts/bootstrap.bundle.min.js" type="text/javascript"></script>



    <form id="form1" runat="server">

    <%--menu admin--%>

        <nav runat="server" id="menuAdmin" class="navbar navbar-expand-lg navbar-dark bg-primary" style="height: 10% !important">
            <div class="container-fluid">
                <a></a>
                <button runat="server" class="navbar-brand btn-primary" onserverclick="BtnMenu_Click">
                    <b>
                        <img src="imagen/Icononegro.png" alt="Bootstrap" width="28" height="28" />
                        <i>Soft Loans</i>
                    </b>
                </button>

                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent"
                    aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link active" id="APrestamos" runat="server">
                                <img src="/Content/bootstrap-icons/icons/wallet-fill.svg" alt="Bootstrap" width="22" height="22" />
                                <asp:Button ID="BtnPrestamos" runat="server" Text="Prestamos" BorderWidth="0" BackColor="Transparent" ForeColor="White"
                                    OnClick="BtnPrestamos_Click" />
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active" id="AClientes" runat="server">
                                <img src="/Content/bootstrap-icons/icons/person-badge.svg" alt="Bootstrap" width="22" height="22" />
                                <asp:Button ID="BtnClientes" runat="server" Text="Clientes" BorderWidth="0" BackColor="Transparent" ForeColor="White"
                                    OnClick="BtnClientes_Click" />
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active" id="AGarantes" runat="server">
                                <img src="/Content/bootstrap-icons/icons/person-badge-fill.svg" alt="Bootstrap" width="22" height="22" />
                                <asp:Button ID="BtnGarante" runat="server" Text="Garantes" BorderWidth="0" BackColor="Transparent" ForeColor="White"
                                    OnClick="BtnGarante_Click" />
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active" id="ACaja" runat="server">
                                <img src="/Content/bootstrap-icons/icons/bank2.svg" alt="Bootstrap" width="22" height="22" />
                                <asp:Button ID="BtnBalanceCentral" runat="server" Text="Balance Central" BorderWidth="0" BackColor="Transparent" ForeColor="White"
                                    OnClick="BtnBalanceCentral_Click" />
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active" id="APagos" runat="server">
                                <img src="/Content/bootstrap-icons/icons/card-checklist.svg" alt="Bootstrap" width="22" height="22" />
                                <asp:Button ID="BtnCobros" runat="server" Text="Cobros" BorderWidth="0" BackColor="Transparent" ForeColor="White"
                                    OnClick="BtnCobros_Click" />
                            </a>
                        </li>

                        <li class="nav-item dropdown">
                            <a class="nav-link active dropdown-toggle" href="#" id="AConsultas" runat="server"
                                role="button" data-bs-toggle="dropdown" aria-expanded="false">Consultas
                            </a>
                            <ul class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                                <li>
                                    <a class="dropdown-item" id="AConPrestamos" runat="server">
                                        <img src="/Content/bootstrap-icons/icons/wallet-fill.svg" alt="Bootstrap" width="22" height="22" />
                                        <asp:Button ID="BtnConPrestamos" runat="server" Text="Prestamos" BorderWidth="0" BackColor="Transparent"
                                            OnClick="BtnConPrestamos_Click" />
                                    </a>
                                </li>
                                <li>
                                    <a class="dropdown-item" id="AVentaProximoVencer" runat="server">
                                        <img src="/Content/bootstrap-icons/icons/calendar-week.svg" alt="Bootstrap" width="22" height="22" />
                                        <asp:Button ID="BtnVencidosProximoVencer" runat="server" Text="Vencidos / proximo a vencer" BorderWidth="0" BackColor="Transparent"
                                            OnClick="BtnVencidosProximoVencer_Click" />
                                    </a>
                                </li>
                                <li>
                                    <a class="dropdown-item" id="AListPagos" runat="server">
                                        <img src="/Content/bootstrap-icons/icons/wallet.svg" alt="Bootstrap"
                                            width="22" height="22" />
                                        <asp:Button ID="BtnListPagos" runat="server" Text="Listado de pagos" BorderWidth="0" BackColor="Transparent"
                                            OnClick="BtnListPagos_Click" />
                                    </a>
                                </li>

                                <li>
                                    <a class="dropdown-item" href="#" id="AGastos" runat="server">
                                        <img src="/Content/bootstrap-icons/icons/wallet2.svg" alt="Bootstrap" width="22" height="22" />
                                        <asp:Button ID="BtnGastos" runat="server" Text="Gastos" BorderWidth="0" BackColor="Transparent"
                                            OnClick="BtnGastos_Click" />
                                    </a>
                                </li>
                                <li>
                                    <a class="dropdown-item" id="AListCuotas" runat="server">
                                        <img src="/Content/bootstrap-icons/icons/filter-square-fill.svg" alt="Bootstrap" width="22" height="22" />

                                        <asp:Button ID="BtnListCuotas" runat="server" Text="Listado de cuotas" BorderWidth="0" BackColor="Transparent"
                                            OnClick="BtnListCuotas_Click" />
                                    </a>
                                </li>

                            </ul>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link active dropdown-toggle" href="#" id="AConfiguracion" runat="server"
                                role="button" data-bs-toggle="dropdown" aria-expanded="false">Configuración
                            </a>
                            <ul class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                                <li>
                                    <a class="dropdown-item" id="AUsuarios" runat="server">
                                        <img src="/Content/bootstrap-icons/icons/person-lines-fill.svg" alt="Bootstrap" width="22" height="22" />
                                        <asp:Button ID="BtnUsuarios" runat="server" Text="Usuarios" BorderWidth="0" BackColor="Transparent"
                                            OnClick="BtnUsuarios_Click" />
                                    </a>
                                </li>
                                <li>
                                    <a class="dropdown-item" id="ANcf" runat="server">
                                        <img src="/Content/bootstrap-icons/icons/input-cursor.svg" alt="Bootstrap" width="22" height="22" />
                                        <asp:Button ID="BtnNCF" runat="server" Text="NCF" BorderWidth="0" BackColor="Transparent"
                                            OnClick="BtnNCF_Click" />
                                    </a>
                                </li>
                                <li>
                                    <a class="dropdown-item" id="AAcciones" runat="server">
                                        <img src="/Content/bootstrap-icons/icons/door-open.svg" alt="Bootstrap"
                                            width="22" height="22" />
                                        <asp:Button ID="BtnAcciones" runat="server" Text="Acciones" BorderWidth="0" BackColor="Transparent"
                                            OnClick="BtnAcciones_Click" />
                                    </a>
                                </li>

                                <li>
                                    <a class="dropdown-item" id="ARutas" runat="server">
                                        <img src="/Content/bootstrap-icons/icons/signpost.svg" alt="Bootstrap" width="22" height="22" />
                                        <asp:Button ID="BtnRutas" runat="server" Text="Rutas" BorderWidth="0" BackColor="Transparent"
                                            OnClick="BtnRutas_Click" />
                                    </a>
                                </li>
                                <li>
                                    <a class="dropdown-item" id="ARutasCobradores" runat="server">
                                        <img src="/Content/bootstrap-icons/icons/signpost-2.svg" alt="Bootstrap" width="22" height="22" />

                                        <asp:Button ID="BtnRutasCobradores" runat="server" Text="Rutas Cobradores" BorderWidth="0" BackColor="Transparent"
                                            OnClick="BtnRutasCobradores_Click" />
                                    </a>
                                </li>

                            </ul>
                        </li>



                    </ul>
                    <button runat="server" class="btn btn-outline-light fw-bold" onserverclick="BtnCerrarSeccion_Click">
                        <b>
                            <i>Cerrar Sesión </i>
                        </b>
                    </button>
                </div>
            </div>
        </nav>
        <%--fin menu admin--%>


        <br />
        <div class="container">
            <div class="row g-3">
                <div class="col-md-6">
                    <label for="inputIdCliente4" class="form-label">Id Cliente</label>
                    <asp:TextBox ID="TbCustomerID" runat="server" class="form-control" placeholder="Id Cliente"
                        ReadOnly="true" Text=""></asp:TextBox>
                </div>
               
                <div class="col-md-6">
                    <label for="inputNombre4" class="form-label">Nombre</label>
                    <asp:TextBox ID="TbName" runat="server" class="form-control" placeholder="Nombre de Cliente" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVName" runat="server"
                        ControlToValidate="TbName"
                        ErrorMessage="Campo obligatorio"
                        ForeColor="Red"
                        EnableClientScript="false">

                    </asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6">
                    <label for="inputApellido4" class="form-label">Apellido</label>
                    <asp:TextBox ID="TbLastName" runat="server" class="form-control" placeholder="Apellido de Cliente" MaxLength="50"></asp:TextBox>
                </div>

                  <div class="col-md-6">
                    <label for="inputDocumentType" class="form-label">Tipo Identif.</label>
                    <asp:DropDownList ID="DropDownListDocumentType" runat="server" CssClass="btn btn-secondary dropdown-toggle" Width="100%">
                        <asp:ListItem Text="CEDULA" Value="CEDULA"></asp:ListItem>
                        <asp:ListItem Text="PASAPORTE" Value="PASAPORTE"></asp:ListItem>
                        <asp:ListItem Text="RNC" Value="RNC"></asp:ListItem>
                        <asp:ListItem Text="MATRICULA" Value="RNC"></asp:ListItem>
                        <asp:ListItem Text="OTROS" Value="RNC"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                 <div class="col-md-6">
                    <label for="inputNumeroDocumento4" class="form-label">Numero de Documento</label>
                    <asp:TextBox ID="TbDocumentNumber" runat="server" class="form-control" placeholder="Numero de Documento" MaxLength="20"></asp:TextBox>
                </div>


                <div class="col-md-6">
                    <label for="inputPhoneNumber4" class="form-label">Telefono</label>
                    <asp:TextBox ID="TbPhoneNumber" runat="server" class="form-control" placeholder="Numero del Telefono" MaxLength="20"></asp:TextBox>
                </div>


                <div class="col-md-6">

                  
                    <label for="inputEstado" class="form-label">Estado</label>
                    <asp:DropDownList ID="DropDownListEstado" runat="server" CssClass="btn btn-secondary dropdown-toggle" Width="100%">
                        <asp:ListItem Text="SOLTERO" Value="SOLTERO"></asp:ListItem>
                        <asp:ListItem Text="CASADO" Value="CASADO"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                 <div class="col-md-6">
                    <label for="inputAdrress4" class="form-label">Dirección</label>
                    <asp:TextBox ID="TbAdrress" runat="server" class="form-control" placeholder="Dirección" MaxLength="100"></asp:TextBox>
                </div>

                <div class="col-md-6">
                    <label for="inputPosition4" class="form-label">Posición</label>
                    <asp:TextBox ID="TbPosition" runat="server" class="form-control" placeholder="Posición" MaxLength="100"></asp:TextBox>
                </div>

                 <div class="col-md-6">
                    <label for="inputLugarTrabajo4" class="form-label">Lugar Trabajo</label>
                    <asp:TextBox ID="TbLugarTrabajo" runat="server" class="form-control" placeholder="Lugar Trabajo" MaxLength="100"></asp:TextBox>
                </div>

                <div class="col-md-6">
                    <label for="inputSalario4" class="form-label">Salario</label>
                    <asp:TextBox ID="TbSalario" runat="server" class="form-control" type="number" placeholder="Salario" MaxLength="100"></asp:TextBox>
                </div>

                  <div class="col-md-6">
                    <label for="inputOtroSalario4" class="form-label">Otro Salario</label>
                    <asp:TextBox ID="TbOtroSalario" runat="server" class="form-control" type="number" placeholder="Otro Salario" MaxLength="100"></asp:TextBox>
                </div>

                <div class="col-md-6">
                    <label for="inputNombreMadre4" class="form-label">Nombre Madre</label>
                    <asp:TextBox ID="TbNombreMadre" runat="server" class="form-control" placeholder="Nombre Madre" MaxLength="100"></asp:TextBox>
                </div>

                <div class="col-md-6">
                    <label for="inputNombrePadre4" class="form-label">Nombre Padre</label>
                    <asp:TextBox ID="TbNombrePadre" runat="server" class="form-control" placeholder="Nombre Padre" MaxLength="100"></asp:TextBox>
                </div>

                 <div class="col-md-6">
                    <label for="inputDependientes4" class="form-label">Dependientes</label>
                    <asp:TextBox ID="TbDependientes" runat="server" class="form-control" placeholder="Dependientes" MaxLength="200"></asp:TextBox>
                </div>

                <div class="col-md-6">
                    <label for="inputReferenciasPersonales4" class="form-label">Referencias Personales</label>
                    <asp:TextBox ID="TbReferenciasPersonales" runat="server" class="form-control" placeholder="Referencias Personales" MaxLength="200"></asp:TextBox>
                </div>

                <div class="col-md-6">
                    <label for="inputReferenciasTrabajo4" class="form-label">Referencias Trabajo</label>
                    <asp:TextBox ID="TbReferenciasTrabajo" runat="server" class="form-control" placeholder="Referencias Trabajo" MaxLength="200"></asp:TextBox>
                </div>

                 <div class="col-md-6">
                    <label for="inputRuta4" class="form-label">Ruta</label>
                    <asp:DropDownList ID="DropDownListRuta" runat="server" CssClass="btn btn-secondary dropdown-toggle" Width="100%">
                    </asp:DropDownList>
                </div>

               

                  <div class="col-md-6">
                    <label for="inputTipoMora" class="form-label">Tipo Mora</label>
                    <asp:DropDownList ID="DropDownListTipoMora" runat="server" CssClass="btn btn-secondary dropdown-toggle" Width="100%">
                         <asp:ListItem Text="Fijo" Value="Fijo"></asp:ListItem>
                        <asp:ListItem Text="Porciento" Value="Porciento"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                
                
                  <div class="col-md-6">
                    <label for="inputMontoMora4" class="form-label">Monto Mora</label>
                    <asp:TextBox ID="TbMontoMora" runat="server" class="form-control" type="number" placeholder="Monto Mora" MaxLength="100"></asp:TextBox>
                </div>
             
            </div>
            <div class="row align-items-stard">

                <div class="col g-4">
                    <button runat="server" class="btn btn-primary" onserverclick="BtnCancelar_Click">
                        <b>
                            <img src="/Content/bootstrap-icons/icons/x-circle.svg" alt="Bootstrap" width="22"
                                height="22" /><i> Cancelar </i></b>
                    </button>
                </div>
                <div class="col g-4 align-self-start">
                    <button runat="server" type="submit" class="btn btn-success" onserverclick="BtnGuardar_Click" >
                        <b>
                            <img src="/Content/bootstrap-icons/icons/save.svg" alt="Bootstrap" width="22" height="22" /><i>
                                Guardar </i></b>
                    </button>
                </div>
            </div>

            <br/>





        </div>


    </form>

</body>

</html>
