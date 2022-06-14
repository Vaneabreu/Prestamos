<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuariosWF.aspx.cs" Inherits="SoftLoteria.UsuariosWF" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Gestion de Usuarios</title>
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
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>

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
        <div id="ContendorC" runat="server" class="container">

            <div class="row g-2">
                <div class="col-md-2">
                    <div class="container">
                        <div class="row">
                            <div class="col g-1">
                                <asp:TextBox ID="TbID" runat="server" type="number" class="form-control" placeholder="ID"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="container">
                        <div class="row">
                            <div class="col g-1">
                                <asp:TextBox ID="TbNombre" runat="server" type="text" class="form-control" placeholder="Nombre"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-4 col-md-2">
                    <div class="container">
                        <div class="row">
                            <div class="col g-1">
                                <button id="BtnBuscar" runat="server" class="btn btn-primary" clientidmode="Static" onserverclick="BtnBuscar_ServerClick">
                                    <b>
                                        <img src="/Content/bootstrap-icons/icons/search.svg" alt="Bootstrap" width="22" height="22" /><i>
                                    Buscar </i></b>
                                </button>
                            </div>
                        </div>

                    </div>

                </div>
            </div>


        </div>

        <div id="ContendorE" runat="server" class="container">

            <div class="row g-2">
                <div class="col-md-2">
                    <div class="container">
                        <div class="row">
                            <div class="col g-1">
                                <asp:TextBox ID="TbIDE" runat="server" type="number" class="form-control" placeholder="ID" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="container">
                        <div class="row">
                            <div class="col g-1">
                                <asp:TextBox ID="TbNombreE" runat="server" type="text" class="form-control" placeholder="Nombre" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="container">
                        <div class="row">
                            <div class="col g-1">
                                <asp:TextBox ID="TbClaveE" runat="server" type="text" class="form-control" placeholder="Clave" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-5 col-md-1">
                    <div class="container p-2">
                        <label for="inputIdFechaPago" class="form-label">Fecha</label>
                    </div>
                </div>
                <div class="col-7 col-md-2">
                    <input type="date" class="form-control" id="InputFecha" value="" runat="server" readonly />
                </div>
                <div class="col-4 col-md-2">
                    <div class="container">
                        <div class="row">
                            <div class="col">
                                <asp:DropDownList ID="DropDownEstado" runat="server" CssClass="btn btn-secondary" ToolTip="Estado" Enabled="false">
                                    <asp:ListItem>Activo</asp:ListItem>
                                    <asp:ListItem>Inactivo</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                        </div>

                    </div>

                </div>
                <div class="col-4 col-md-1">
                    <div class="container">
                        <div class="row">
                            <div class="col">
                                <asp:CheckBox ID="CbAdmin" runat="server" Text=" Admin" Enabled="false" />

                            </div>
                        </div>

                    </div>

                </div>


                <div class="row align-items-stard">
                    <div class="col-12 col-md-6 p-1">
                        <button id="BtnCancelar" runat="server" class="btn btn-primary" clientidmode="Static" onserverclick="BtnCancelar_ServerClick">
                            <b>
                                <img src="/Content/bootstrap-icons/icons/x-circle.svg" alt="Bootstrap" width="22" height="22" /><i>
                                    Cancelar</i></b>
                        </button>
                    </div>
                    <div class="col-12 col-md-6 p-1">
                        <button id="BtnLiberar" runat="server" onserverclick="BtnLiberar_ServerClick" class="btn btn-warning">
                            <b>
                                <img src="/Content/bootstrap-icons/icons/key-fill.svg" alt="Bootstrap" width="22" height="22" /><i>
                                    Liberar</i></b>
                        </button>
                        <button id="BtnCerrar" runat="server" onserverclick="BtnCerrar_ServerClick" class="btn btn-danger">
                            <b>
                                <img src="/Content/bootstrap-icons/icons/lock-fill.svg" alt="Bootstrap" width="22" height="22" /><i>
                                    Cerrar</i></b>
                        </button>

                    </div>
                </div>
            </div>


        </div>


        <br />
        <div id="ContendorD" runat="server" class="container table-responsive">
            <asp:GridView ID="GvUsuarios" runat="server" AutoGenerateColumns="False" Width="100%"
                CssClass="table table-responsive table-striped table-hover table-sm"
                DataKeyNames="ID"
                EmptyDataText="No se encontraron datos entre los limites establecidos!"
                OnSelectedIndexChanged="GvUsuarios_SelectedIndexChanged"
                AllowCustomPaging="True"
                ForeColor="#333333"
                GridLines="Horizontal">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Nombre" />
                    <asp:BoundField DataField="Password" HeaderText="Clave">
                        <HeaderStyle CssClass="ocultar-div-md" Wrap="False"></HeaderStyle>
                        <ItemStyle CssClass="ocultar-div-md" Wrap="False"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="IsAdministrator" HeaderText="Administrador">
                        <HeaderStyle CssClass="ocultar-div-md" Wrap="False"></HeaderStyle>
                        <ItemStyle CssClass="ocultar-div-md" Wrap="False"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="RegistrationDate" HeaderText="Fecha Registro" />
                    <asp:BoundField DataField="Status" HeaderText="Estado" />

                    <asp:ButtonField ImageUrl="/Content/bootstrap-icons/icons/pencil-square.svg" Text="" CommandName="Select" HeaderText="Editar" ButtonType="Image">
                        <ControlStyle CssClass="btn btn-warning"></ControlStyle>
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle CssClass="btn-warning" HorizontalAlign="Center" Width="100px" />
                    </asp:ButtonField>


                </Columns>
                <EditRowStyle BackColor="#2461BF" Width="100%" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#212529" Font-Bold="True" ForeColor="White"
                    HorizontalAlign="Center" Wrap="True" />
                <%-- #0d6efd --%>
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" Wrap="True" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>

    </form>
</body>
</html>
