<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrestamoCrearWF.aspx.cs"
    Inherits="SoftLoans.PrestamoCrearWF" %>

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

    <!-- Print -->
    <link href="/Content/print.min.css" rel="stylesheet" type="text/css">
    <script src="/Scripts/print.min.js"></script>


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

        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        <!-- Modal Cargar Detalle Prestamo-->
        <div class="modal fade" id="exampleModalDetallePrestamo" tabindex="-1" aria-labelledby="exampleModalLabelDetallePrestamo" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabelDetallePrestamo">Tabla de Amortización</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div runat="server" class="modal-body" onload="CargarDetallePrestamo">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <div id="DivAmortizacion" class="container">
                                    <div class="row align-items-end">
                                        <div class="col-6 col-md-6">
                                            <label for="LbIdClienteD" class="form-label">Cliente</label>
                                            <asp:TextBox ID="TbClienteD" ReadOnly="true" type="text" runat="server" class="form-control" placeholder="Cliente"></asp:TextBox>
                                        </div>
                                        <div class="col-6 col-md-6">
                                            <label for="LbCapitalD" class="form-label">Capital</label>
                                            <asp:TextBox ID="TbCapitalD" ReadOnly="true" type="text" runat="server" class="form-control" placeholder="Capital"></asp:TextBox>
                                        </div>

                                        <div class="col-6 col-md-6">
                                            <label for="LbInteresD" class="form-label">Interes</label>
                                            <asp:TextBox ID="TbInteresD" ReadOnly="true" type="text" runat="server" class="form-control" placeholder="Interes"></asp:TextBox>
                                        </div>
                                        <div class="col-6 col-md-6">
                                            <label for="LbTotalD" class="form-label">Total</label>
                                            <asp:TextBox ID="TbTotalD" ReadOnly="true" type="text" runat="server" class="form-control" placeholder="Total"></asp:TextBox>
                                        </div>


                                        <div class="col-6 col-md-6">
                                            <label for="LbTraspasoD" class="form-label">Traspaso</label>
                                            <asp:TextBox ID="TbTraspasoD" ReadOnly="true" type="text" runat="server" class="form-control" placeholder="0.00"></asp:TextBox>
                                        </div>
                                        <div class="col-6 col-md-6">
                                            <label for="LbOposicionD" class="form-label">Oposicion</label>
                                            <asp:TextBox ID="TbOposicionD" ReadOnly="true" type="text" runat="server" class="form-control" placeholder="0.00"></asp:TextBox>
                                        </div>

                                        <div class="col-6 col-md-6">
                                            <label for="LbActoVentaD" class="form-label">Acto de Venta</label>
                                            <asp:TextBox ID="TbActoVentaD" ReadOnly="true" type="text" runat="server" class="form-control" placeholder="0.00"></asp:TextBox>
                                        </div>
                                        <div class="col-6 col-md-6">
                                            <label for="LbAbogadoD" class="form-label">Abogado</label>
                                            <asp:TextBox ID="TbAbogadoD" ReadOnly="true" type="text" runat="server" class="form-control" placeholder="0.00"></asp:TextBox>
                                        </div>
                                        <div class="col-6 col-md-6">
                                            <label for="LbGatosLegalesD" class="form-label">Gastos Legales</label>
                                            <asp:TextBox ID="TbGastosLegalesD" ReadOnly="true" type="text" runat="server" class="form-control" placeholder="0.00"></asp:TextBox>
                                        </div>
                                        <%--<div class="col-3 col-md-2">
                                            <button id="Button1" runat="server" class="btn btn-primary" onserverclick="BtnBuscaC_ServerClick">
                                                <b>
                                                    <img src="/Content/bootstrap-icons/icons/search.svg" alt="Bootstrap" width="22" height="22" /><i>
                                                    </i></b>
                                            </button>
                                        </div>--%>

                                        <div class="container table-responsive">
                                            <br />
                                            <asp:GridView ID="GridViewAmortizacion" runat="server" Width="100%"
                                                CssClass="table table-responsive table-striped table-hover table-sm" AutoGenerateColumns="False"
                                                DataKeyNames="QuotaNumber,PayDate"
                                                EmptyDataText="No se encontraron datos entre los limites establecidos!"
                                                AllowCustomPaging="True"
                                                ForeColor="#333333"
                                                GridLines="Horizontal">

                                                <Columns>

                                                    <%--ItemStyle-CssClass="d-none d-lg-block" HeaderStyle-CssClass="d-none d-lg-block"--%>
                                                    <asp:BoundField DataField="QuotaNumber" HeaderText="#" ReadOnly="True" />

                                                    <asp:BoundField DataField="PayDate" HeaderText="Fecha de pago" ControlStyle-CssClass="d-none" />

                                                    <asp:BoundField DataField="Quota" HeaderText="Cuota" />
                                                    <asp:BoundField DataField="Interest" HeaderText="Interes">
                                                        <HeaderStyle CssClass="ocultar-div-md" Wrap="False"></HeaderStyle>
                                                        <ItemStyle CssClass="ocultar-div-md" Wrap="False"></ItemStyle>
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Amortization" HeaderText="Amortizacion" />
                                                    <asp:BoundField DataField="Capital" HeaderText="Capital" />
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
                                        </div>

                                    </div>

                                </div>
                                <br />


                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="GvClientes" />
                            </Triggers>


                        </asp:UpdatePanel>


                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cerrar</button>
                        <button type="button" runat="server" id="BtImprimir" onserverclick="BtImprimir_ServerClick" class="btn btn-info" data-bs-dismiss="modal">Imprimir</button>
                        <button type="button" runat="server" id="BtnGuardar" onserverclick="BtnGuardar_ServerClick" class="btn btn-success" data-bs-dismiss="modal">Guardar</button>
                    </div>
                </div>
            </div>
        </div>



        <!-- Modal Clientes-->
        <div class="modal fade" id="exampleModalClientes" tabindex="-1" aria-labelledby="exampleModalLabelClientes" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabelClientes">Buscar Cliente</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div runat="server" class="modal-body" onload="CargarClientes">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="container">
                                    <div class="row align-items-end">
                                        <div class="col-9 col-md-10">
                                            <asp:TextBox ID="TbNombreClienteB" runat="server" class="form-control" placeholder="Nombre"></asp:TextBox>
                                        </div>
                                        <div class="col-3 col-md-2">
                                            <button id="BtnBuscaC" runat="server" class="btn btn-primary" onserverclick="BtnBuscaC_ServerClick">
                                                <b>
                                                    <img src="/Content/bootstrap-icons/icons/search.svg" alt="Bootstrap" width="22" height="22" /><i>
                                                    </i></b>
                                            </button>
                                        </div>
                                    </div>

                                </div>
                                <br />
                                <div class="container table-responsive">
                                    <asp:GridView ID="GvClientes" runat="server" Width="100%"
                                        CssClass="table table-responsive table-striped table-hover table-sm" AutoGenerateColumns="False"
                                        DataKeyNames="ID"
                                        EmptyDataText="No se encontraron datos entre los limites establecidos!"
                                        OnSelectedIndexChanged="GvClientes_SelectedIndexChanged"
                                        AllowCustomPaging="True"
                                        ForeColor="#333333"
                                        GridLines="Horizontal">

                                        <Columns>

                                            <%--ItemStyle-CssClass="d-none d-lg-block" HeaderStyle-CssClass="d-none d-lg-block"--%>
                                            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />

                                            <asp:BoundField DataField="IdentificationNumber" HeaderText="No. Documento" SortExpression="Documento" Visible="false" />

                                            <asp:BoundField DataField="Name" HeaderText="Nombre" SortExpression="Nombre" />
                                            <asp:BoundField DataField="LastName" HeaderText="Apellido" SortExpression="Apellido">
                                                <HeaderStyle CssClass="ocultar-div-md" Wrap="False"></HeaderStyle>
                                                <ItemStyle CssClass="ocultar-div-md" Wrap="False"></ItemStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Phone" HeaderText="# Telefono" SortExpression="Telef." Visible="false" />
                                            <asp:BoundField DataField="Address" HeaderText="Dirección" SortExpression="Dirección" Visible="false" />

                                            <asp:ButtonField ImageUrl="/Content/bootstrap-icons/icons/check2-circle.svg" CommandName="Select" HeaderText="Selec." ButtonType="Image">
                                                <ControlStyle CssClass="btn btn-success"></ControlStyle>
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
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="GvClientes" />
                            </Triggers>


                        </asp:UpdatePanel>


                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>

        <!-- Modal Garantes-->
        <div class="modal fade" id="exampleModalGarantes" tabindex="-1" aria-labelledby="exampleModalLabelGarantes" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabelGarantes">Buscar Garantes</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div runat="server" class="modal-body" onload="CargarGarantes">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <div class="container">
                                    <div class="row align-items-end">
                                        <div class="col-9 col-md-10">
                                            <asp:TextBox ID="TbNombreGaranteB" runat="server" class="form-control" placeholder="Nombre"></asp:TextBox>
                                        </div>
                                        <div class="col-3 col-md-2">
                                            <button id="BtnBuscarG" runat="server" class="btn btn-primary" onserverclick="BtnBuscarG_ServerClick">
                                                <b>
                                                    <img src="/Content/bootstrap-icons/icons/search.svg" alt="Bootstrap" width="22" height="22" /><i>
                                                    </i></b>
                                            </button>
                                        </div>
                                    </div>

                                </div>
                                <br />
                                <div class="container table-responsive">
                                    <asp:GridView ID="GvGarantes" runat="server" Width="100%"
                                        CssClass="table table-responsive table-striped table-hover table-sm" AutoGenerateColumns="False"
                                        DataKeyNames="ID"
                                        EmptyDataText="No se encontraron datos entre los limites establecidos!"
                                        OnSelectedIndexChanged="GvGarantes_SelectedIndexChanged"
                                        AllowCustomPaging="True"
                                        ForeColor="#333333"
                                        GridLines="Horizontal">

                                        <Columns>

                                            <%--ItemStyle-CssClass="d-none d-lg-block" HeaderStyle-CssClass="d-none d-lg-block"--%>
                                            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />

                                            <asp:BoundField DataField="IdentificationNumber" HeaderText="No. Documento" SortExpression="Documento" Visible="false" />

                                            <asp:BoundField DataField="Name" HeaderText="Nombre" SortExpression="Nombre" />
                                            <asp:BoundField DataField="LastName" HeaderText="Apellido" SortExpression="Apellido">
                                                <HeaderStyle CssClass="ocultar-div-md" Wrap="False"></HeaderStyle>
                                                <ItemStyle CssClass="ocultar-div-md" Wrap="False"></ItemStyle>
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Phone" HeaderText="# Telefono" SortExpression="Telef." Visible="false" />
                                            <asp:BoundField DataField="Address" HeaderText="Dirección" SortExpression="Dirección" Visible="false" />


                                            <asp:ButtonField ImageUrl="/Content/bootstrap-icons/icons/check2-circle.svg" CommandName="Select" HeaderText="Selec." ButtonType="Image">
                                                <ControlStyle CssClass="btn btn-success"></ControlStyle>
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
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="GvGarantes" />
                            </Triggers>


                        </asp:UpdatePanel>


                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>


        <div class="container">
            <div class="row m-md-3 m-3 w-100">
                <label for="LbTituloCliente" class="form-label fs-4 fw-bold">Informacion del cliente</label>
                <div class="row  align-items-end p-2  border-2 border border-secondary">
                    <div class="col-9 col-md-3">
                        <label for="LbIdCliente" class="form-label">ID Cliente</label>
                        <asp:TextBox ID="TbIdCliente" type="number" runat="server" class="form-control" placeholder="ID Cliente"></asp:TextBox>
                    </div>
                    <div class="col-3 col-md-1">
                        <button type="button" class="btn btn-primary float-end" data-bs-toggle="modal" data-bs-target="#exampleModalClientes">
                            <b>
                                <img src="/Content/bootstrap-icons/icons/search.svg" alt="Bootstrap" width="22" height="22" /><i>
                                </i></b>
                        </button>
                    </div>


                    <div class="col-md-4">
                        <label for="LbTipoIdentificacionC" class="form-label">Tipo de Identificacion</label>
                        <asp:TextBox ID="TbTipoIdentificacionC" type="text" ReadOnly="true" runat="server" class="form-control" placeholder="Tipo de Identificacion"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label for="LbNumeroIdenticacionC" class="form-label">No. de Infentificacion</label><br />
                        <asp:TextBox ID="TbNumeroIdenticacionC" type="text" ReadOnly="true" runat="server" class="form-control" placeholder="No. de Identificacion"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label for="LbNombreCliente" class="form-label">Nombre del cliente</label><br />
                        <asp:TextBox ID="TbNombreClienteC" type="text" ReadOnly="true" runat="server" class="form-control" placeholder="Nombre cliente"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label for="LbTelefono" class="form-label">Telefono</label><br />
                        <asp:TextBox ID="TbTelefonoC" type="text" ReadOnly="true" runat="server" class="form-control" placeholder="Telefono"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label for="LbEstadoC" class="form-label">Estado</label><br />
                        <asp:TextBox ID="TbEstadoC" type="text" ReadOnly="true" runat="server" class="form-control" placeholder="Estado"></asp:TextBox>
                    </div>
                </div>

            </div>

            <div class="row m-md-3 m-3 w-100">
                <label for="LbTituloGarantee" class="form-label fs-4 fw-bold">Informacion del Garante</label>
                <div class="row  align-items-end p-2  border-2 border border-secondary">
                    <div class="col-9 col-md-3">
                        <label for="LbIdGarante" class="form-label">ID Garante</label>
                        <asp:TextBox ID="TbIdGaranteGC" type="number" runat="server" class="form-control" placeholder="ID Garante"></asp:TextBox>
                    </div>
                    <div class="col-3 col-md-1">
                        <button type="button" class="btn btn-primary float-end" data-bs-toggle="modal" data-bs-target="#exampleModalGarantes">
                            <b>
                                <img src="/Content/bootstrap-icons/icons/search.svg" alt="Bootstrap" width="22" height="22" /><i>
                                </i></b>
                        </button>
                    </div>


                    <div class="col-md-4">
                        <label for="LbTipoIdentificacionG" class="form-label">Tipo de Identificacion</label>
                        <asp:TextBox ID="TbTipoIdentificacionG" type="text" ReadOnly="true" runat="server" class="form-control" placeholder="Tipo de Identificacion"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label for="LbNumeroIdenticacionG" class="form-label">No. de Infentificacion</label><br />
                        <asp:TextBox ID="TbNumeroIdenticacionG" type="text" ReadOnly="true" runat="server" class="form-control" placeholder="No. de Identificacion"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label for="LbNombreGarante" class="form-label">Nombre del Garante</label><br />
                        <asp:TextBox ID="TbNombreGarante" type="text" ReadOnly="true" runat="server" class="form-control" placeholder="Nombre Garante"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label for="LbTelefono" class="form-label">Telefono</label><br />
                        <asp:TextBox ID="TbTelefonoG" type="text" ReadOnly="true" runat="server" class="form-control" placeholder="Telefono"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label for="LbEstadoG" class="form-label">Estado</label><br />
                        <asp:TextBox ID="TbEstadoG" type="text" ReadOnly="true" runat="server" class="form-control" placeholder="Estado"></asp:TextBox>
                    </div>
                </div>

            </div>

            <br />
            <div class="row m-md-3 m-3 w-100">
                <label for="LbTituloPrestamo" class="form-label fs-4 fw-bold">Informacion del Prestamo</label>
                <div class="row  align-items-center p-2  border-2 border border-secondary">
                    <div class="col-md-4">
                        <label for="LbMonto" class="form-label">Monto</label>
                        <asp:TextBox ID="TbMonto" type="number" runat="server" class="form-control w-50" placeholder="0.00"></asp:TextBox>
                        <br />
                        <asp:CheckBox ID="CbPorCuota" runat="server" Checked="true" TextAlign="Left" Text="Por cuota" />
                        <br />
                        <br />

                        <label for="LbFrecuencia" class="form-label">Frecuencia</label>
                        <asp:DropDownList ID="DropDownFrecuencia" runat="server" CssClass="btn btn-secondary dropdown-toggle" Width="100%">
                            <asp:ListItem Text="DIARIO" Value="DIARIO"></asp:ListItem>
                            <asp:ListItem Text="SEMANAL" Value="SEMANAL"></asp:ListItem>
                            <asp:ListItem Text="QUINCENAL" Value="QUINCENAL"></asp:ListItem>
                            <asp:ListItem Text="MENSUAL" Value="MENSUAL"></asp:ListItem>
                        </asp:DropDownList>

                        <br />
                        <br />

                        <label for="inputIdFecha" class="form-label">Fecha</label>
                        <input type="date" class="form-control" id="InputFecha" value="" runat="server" />

                        <br />

                        <label for="LbTiempo" class="form-label">Tiempo</label>
                        <asp:DropDownList ID="DropDownTiempo" runat="server" CssClass="btn btn-secondary dropdown-toggle" Width="100%">
                        </asp:DropDownList>
                        <br />
                        <br />
                        <div class="row w-100">
                            <div class="col-5">
                                <label for="LbInteres" class="form-label">% Interes</label>
                                <asp:TextBox ID="TbInteres" type="text" runat="server" class="form-control w-100" placeholder="0%"></asp:TextBox>
                            </div>
                            <div class="col-5">
                                <label for="LbCuota" class="form-label">Cuota</label>
                                <asp:TextBox ID="TbCuota" type="number" ReadOnly="true" runat="server" class="form-control w-100" placeholder="0.00"></asp:TextBox>
                            </div>
                            <div class="col-2 align-self-end">
                                <button runat="server" type="submit" class="btn btn-success" onserverclick="BtnConvertir_Click">
                                    <b>
                                        <img src="/Content/bootstrap-icons/icons/calculator-fill.svg" alt="Bootstrap" width="22"
                                            height="22" /><i>  </i></b>
                                </button>
                            </div>
                        </div>
                        <br />
                        <div class="row w-100">
                            <div class="col-6">
                                <asp:RadioButton ID="RbInteres" runat="server" Text="Interes" Checked="true" GroupName="CuotaInteres" AutoPostBack="true" OnCheckedChanged="RbInteres_CheckedChanged" />
                            </div>
                            <div class="col-6">
                                <asp:RadioButton ID="RbCuota" runat="server" Text="Cuota" GroupName="CuotaInteres" AutoPostBack="true" OnCheckedChanged="RbCuota_CheckedChanged" />
                            </div>
                        </div>

                    </div>
                    <div class="col-md-4">
                    </div>
                    <br />
                    <div class="col-md-4 align-self-center">
                        <label for="LbTraspaso" class="form-label">Traspaso</label>
                        <asp:TextBox ID="TbTraspaso" type="number" runat="server" class="form-control w-50" placeholder="0.00"></asp:TextBox>
                        <br />

                        <label for="LbOposicion" class="form-label">Oposicion</label>
                        <asp:TextBox ID="TbOposicion" type="number" runat="server" class="form-control w-50" placeholder="0.00"></asp:TextBox>
                        <br />

                        <label for="LbActoDeVenta" class="form-label">Acto de Venta</label>
                        <asp:TextBox ID="TbActoDeVenta" type="number" runat="server" class="form-control w-50" placeholder="0.00"></asp:TextBox>
                        <br />

                        <label for="LbAbogado" class="form-label">Abogado</label>
                        <asp:TextBox ID="TbAbogado" type="number" runat="server" class="form-control w-50" placeholder="0.00"></asp:TextBox>
                        <br />

                        <label for="LbGastosLegales" class="form-label">Gastos Legales</label>
                        <asp:TextBox ID="TbGastosLegales" type="number" runat="server" class="form-control w-50" placeholder="0.00"></asp:TextBox>
                        <br />

                    </div>
                </div>
            </div>

            <div class="col container">
                <button runat="server" class="btn btn-primary" onserverclick="BtnCancelar_Click">
                    <b>
                        <img src="/Content/bootstrap-icons/icons/x-circle.svg" alt="Bootstrap" width="22"
                            height="22" /><i> Cancelar </i></b>
                </button>
                <%--   <button runat="server" type="submit" class="btn btn-success" onserverclick="BtnGuardar_Click">
                    <b>
                        <img src="/Content/bootstrap-icons/icons/save.svg" alt="Bootstrap" width="22" height="22" /><i>
                                Calcular </i></b>
                </button>--%>

                <button id="BtnProcesar" runat="server" type="button" class="btn btn-primary float-end" data-bs-toggle="modal" data-bs-target="#exampleModalDetallePrestamo" visible="false">
                    <b>
                        <img src="/Content/bootstrap-icons/icons/search.svg" alt="Bootstrap" width="22" height="22" /><i>
                                Procesar</i></b>
                </button>

            </div>

            <br />

        </div>


    </form>

</body>

</html>
