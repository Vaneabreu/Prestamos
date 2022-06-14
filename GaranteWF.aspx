<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GaranteWF.aspx.cs"
    Inherits="SoftLoans.GaranteWF" %>

<!DOCTYPE html>

<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Garante</title>
    <!-- Bootstrap CSS -->
    <link href="/Content/bootstrap.min.css" rel="stylesheet" type="text/css">
    <script src="/Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>

    <!-- SweetAlert -->
    <script src="/Scripts/SweetAlert.min.js"></script>
    <link href="/Content/sweetalert/sweet-alert.css" rel="stylesheet" />


    <link href="/Content/estilos.css" rel="stylesheet" type="text/css">
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

        <div id="DivGaranteB" runat="server" class="container">
            <div class="row g-3">
                <div class="col-md-6">
                    <label for="LbIdGarante" class="form-label">Id Garante</label>
                    <asp:TextBox ID="TbIdGarante" type="number" runat="server" class="form-control" placeholder="Id Garante"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="LbNumeroDocumento" class="form-label">Numero de Documento</label>
                    <asp:TextBox ID="TbNumeroDocumento" runat="server" class="form-control" placeholder="Numero de Documento"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="LbNombre" class="form-label">Nombre</label>
                    <asp:TextBox ID="TbNombre" runat="server" class="form-control" placeholder="Nombre de Garante"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="inputLotery4" class="form-label">Tipo de Documento</label><br />
                    <asp:DropDownList ID="DropDownTipoDocumento" runat="server" CssClass="btn btn-secondary dropdown-toggle" Width="100%">
                        <asp:ListItem Selected="True">CEDULA</asp:ListItem>
                        <asp:ListItem>RNC</asp:ListItem>
                        <asp:ListItem>PASAPORTE</asp:ListItem>
                        <asp:ListItem>OTROS</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <br />
            <div class="col-md-6">
                <div class="col g-1">
                    <button id="BtnBuscar" onserverclick="BtnBuscar_ServerClick" runat="server" class="btn btn-primary" clientidmode="Static">
                        <b>
                            <img src="/Content/bootstrap-icons/icons/search.svg" alt="Bootstrap" width="22" height="22" /><i>
                                    Buscar </i></b>
                    </button>
                    <button id="BtnNuevo" onserverclick="BtnNuevo_ServerClick" runat="server" class="btn btn-primary" clientidmode="Static">
                        <b>
                            <img src="/Content/bootstrap-icons/icons/file-earmark-plus.svg" alt="Bootstrap" width="22" height="22" /><i>
                                    Nuevo </i></b>
                    </button>

                </div>
            </div>





        </div>

        <div id="DivGaranteC" runat="server" class="container">
            <div class="row g-3">
                <div class="col-md-4">
                    <label for="LbIdGarante" class="form-label">Id Garante</label>
                    <asp:TextBox ID="TbIdC" type="number" ReadOnly="true" runat="server" class="form-control" placeholder="Id Garante"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label for="LbNumeroDocumento" class="form-label">Numero de Documento</label>
                    <asp:TextBox ID="TbNumeroDocumentoC" runat="server" class="form-control" placeholder="Numero de Documento"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVNumeroDocumento" runat="server"
                        ControlToValidate="TbNumeroDocumentoC"
                        ErrorMessage="Campo obligatorio"
                        ForeColor="Red"
                        EnableClientScript="false">

                    </asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <label for="inputLotery4" class="form-label">Tipo de Documento</label><br />
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="btn btn-secondary dropdown-toggle" Width="100%">
                        <asp:ListItem Selected="True">CEDULA</asp:ListItem>
                        <asp:ListItem>RNC</asp:ListItem>
                        <asp:ListItem>PASAPORTE</asp:ListItem>
                        <asp:ListItem>OTROS</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <label for="LbNombre" class="form-label">Nombre</label>
                    <asp:TextBox ID="TbNombreC" runat="server" class="form-control" placeholder="Nombre de Garante"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVNombre" runat="server"
                        ControlToValidate="TbNombreC"
                        ErrorMessage="Campo obligatorio"
                        ForeColor="Red"
                        EnableClientScript="false">

                    </asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <label for="LbApellido" class="form-label">Apellido</label>
                    <asp:TextBox ID="TbApellido" runat="server" class="form-control" placeholder="Apellido"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVApellido" runat="server"
                        ControlToValidate="TbApellido"
                        ErrorMessage="Campo obligatorio"
                        ForeColor="Red"
                        EnableClientScript="false">

                    </asp:RequiredFieldValidator>kd
                </div>
                <div class="col-md-4">
                    <label for="LbTelefono" class="form-label">Telefono</label>
                    <asp:TextBox ID="TbTelefono" runat="server" class="form-control" placeholder="Telefono"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label for="LbEstado" class="form-label">Estado</label>
                    <asp:TextBox ID="TbEstado" runat="server" class="form-control" placeholder="Estado"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label for="LbEdad" class="form-label">Edad</label>
                    <asp:TextBox ID="TbEdad" type="number" runat="server" class="form-control" placeholder="Edad"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label for="LbPosicion" class="form-label">Posicion</label>
                    <asp:TextBox ID="TbPosicion" runat="server" class="form-control" placeholder="Posicion"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label for="LbLugarTrabajo" class="form-label">Lugar de Trabajo</label>
                    <asp:TextBox ID="TbLugarTrabajo" runat="server" class="form-control" placeholder="Lugar de trabajo"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label for="LbSalario" class="form-label">Salario</label>
                    <asp:TextBox ID="TbSalario" type="number" runat="server" class="form-control" placeholder="0.00"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label for="LbOtroSalario" class="form-label">Otro Salario</label>
                    <asp:TextBox ID="TbOtroSalario" type="number" runat="server" class="form-control" placeholder="0.00"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label for="LbTiempoTrabajo" class="form-label">Tiempo Trabajo</label>
                    <asp:TextBox ID="TbTiempoTrabajo" runat="server" class="form-control" placeholder="Tiempo Trabajo"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label for="LbNombrePadre" class="form-label">Nombre Padre</label>
                    <asp:TextBox ID="TbNombrePadre" runat="server" class="form-control" placeholder="Nombre padre"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label for="LbNombreMadre" class="form-label">Nombre Madre</label>
                    <asp:TextBox ID="TbNombreMadre" runat="server" class="form-control" placeholder="Nombre Madre"></asp:TextBox>
                </div>
                <div class="col-md-12">
                    <label for="LbDireccion" class="form-label">Direccion</label>
                    <asp:TextBox ID="TbDireccion" runat="server" class="form-control" placeholder="Direccion"></asp:TextBox>
                </div>

            </div>
            <br />
            <div class="col-md-6">
                <div class="col g-1">
                    <button id="BtnCancelar" runat="server" class="btn btn-primary w-auto" onserverclick="BtnCancelar_ServerClick">
                        <b>
                            <img src="/Content/bootstrap-icons/icons/x-circle.svg" alt="Bootstrap" width="22"
                                height="22" /><i> Cancelar </i></b>
                    </button>
                    <button id="BtnBorrar" runat="server" type="button" class="btn btn-danger w-auto" data-bs-toggle="modal" data-bs-target="#exampleModal">
                        <b>
                            <img src="/Content/bootstrap-icons/icons/trash.svg" alt="Bootstrap" width="22" height="22" /><i>
                                Borr.</i></b>
                    </button>
                    <button id="BtnGuardar" runat="server" type="submit" class="btn btn-success w-auto" onserverclick="BtnGuardar_ServerClick">
                        <b>
                            <img src="/Content/bootstrap-icons/icons/save.svg" alt="Bootstrap" width="22" height="22" /><i>
                                Guardar </i></b>
                    </button>

                </div>
            </div>

        </div>

        <!-- Modal -->
        <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <img src="/Content/bootstrap-icons/icons/exclamation-triangle.svg" alt="Bootstrap" width="32" height="32" class="btn-warning rounded-3" />
                        <div class="container g-2">
                            <h5 class="modal-title" id="exampleModalLabel">¡Proceso de Borrado!</h5>
                        </div>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        ¿Está seguro de continuar con el proceso de borrado?
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                        <button type="button" class="btn btn-success" onserverclick="BtnBorrar_ServerClick" runat="server">Continuar</button>
                    </div>
                </div>
            </div>
        </div>

        <br />
        <div id="DivGvGaranteB" runat="server" class="container table-responsive">
            <asp:GridView ID="GvGarante" runat="server" Width="100%"
                CssClass="table table-responsive table-striped table-hover table-sm" AutoGenerateColumns="False"
                DataKeyNames="ID"
                EmptyDataText="No se encontraron datos entre los limites establecidos!"
                AllowCustomPaging="True"
                OnSelectedIndexChanged="GvGarante_SelectedIndexChanged"
                OnRowDeleting="GvGarante_RowDeleting" ForeColor="#333333"
                OnRowDataBound="GvGarante_RowDataBound"
                OnRowUpdating="GvGarante_RowUpdating"
                GridLines="Horizontal">

                <Columns>

                    <%--ItemStyle-CssClass="d-none d-lg-block" HeaderStyle-CssClass="d-none d-lg-block"--%>
                    <asp:BoundField DataField="ID" HeaderText="ID Cliente" ReadOnly="True" SortExpression="ID">
                        <HeaderStyle Width="100px" HorizontalAlign="Center" CssClass="ocultar-div-sm"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" CssClass="ocultar-div-sm"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="IdentificationNumber" HeaderText="No. Documento" SortExpression="Documento">
                        <HeaderStyle Width="180px" CssClass="ocultar-div-md"></HeaderStyle>
                        <ItemStyle CssClass="ocultar-div-md"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Name" HeaderText="Nombre Cliente" SortExpression="Nombre" />
                    <asp:BoundField DataField="LastName" HeaderText="Apellido Cliente" SortExpression="Apellido">

                        <HeaderStyle CssClass="ocultar-div-lg"></HeaderStyle>
                        <ItemStyle CssClass="ocultar-div-lg"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Phone" HeaderText="# Telefono" SortExpression="Telef.">

                        <HeaderStyle CssClass="ocultar-div-lg"></HeaderStyle>
                        <ItemStyle CssClass="ocultar-div-lg"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Address" HeaderText="Dirección" SortExpression="Dirección"
                        HeaderStyle-Width="100px" ItemStyle-Width="100px">
                        <HeaderStyle Width="100px" CssClass="ocultar-div-xl"></HeaderStyle>
                        <ItemStyle Width="100px" CssClass="ocultar-div-xl"></ItemStyle>
                    </asp:BoundField>

                    <asp:ButtonField ImageUrl="/Content/bootstrap-icons/icons/pencil-square.svg" CommandName="Select" HeaderText="Modi." ButtonType="Image">
                        <ControlStyle CssClass="btn btn-warning"></ControlStyle>
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle CssClass="btn-warning" HorizontalAlign="Center" Width="50px" />
                    </asp:ButtonField>


                </Columns>

                <EditRowStyle BackColor="#2461BF" Width="100%" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#212529" Font-Bold="True" ForeColor="White"
                    HorizontalAlign="Center" Wrap="False" />
                <%-- #0d6efd --%>
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" Wrap="False" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />

            </asp:GridView>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
            </asp:ScriptManager>
        </div>



    </form>
</body>
</html>
