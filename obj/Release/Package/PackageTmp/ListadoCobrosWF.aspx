<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoCobrosWF.aspx.cs" Inherits="SoftLoteria.ListadoCobrosWF" %>

<!DOCTYPE html>

<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Listado Cobros</title>
    <!-- Bootstrap CSS -->
    <link href="/Content/bootstrap.min.css" rel="stylesheet" type="text/css">
    <script src="/Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>

    <!-- SweetAlert -->
    <script src="/Scripts/SweetAlert.min.js"></script>
    <link href="/Content/sweetalert/sweet-alert.css" rel="stylesheet" />


    <link href="/Content/estilos.css" rel="stylesheet" type="text/css">

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
            <div class="row m-md-3">

                <div class="col-12 col-md-4">
                    <div class="col-md-10">
                        <label for="LbIdGarante" class="form-label">Id</label>
                        <asp:TextBox ID="TbId" type="number" runat="server" class="form-control" placeholder="Id"></asp:TextBox>
                    </div>
                    <div class="col-md-10">
                        <label for="inputLotery4" class="form-label">Ruta</label><br />
                        <asp:DropDownList ID="DropDownRuta" runat="server" CssClass="btn btn-secondary dropdown-toggle" Width="100%">
                        </asp:DropDownList>
                    </div>
                    <div class="row align-items-end">
                        <div class="col-9 col-md-8">
                            <label for="LbIdGarante" class="form-label">Cliente</label>
                            <asp:TextBox ID="TbCliente" type="number" runat="server" class="form-control" placeholder="Cliente"></asp:TextBox>
                        </div>
                        <div class="col-3 col-md-2">
                            <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
                                <b>
                                    <img src="/Content/bootstrap-icons/icons/search.svg" alt="Bootstrap" width="22" height="22" /><i>
                                    </i></b>
                            </button>
                        </div>
                    </div>
                </div>
                <div class="col-12 col-md-4 align-self-end p-3">
                    <div class="row">
                        <div class="col">
                            <div class="col-2 col-md-1">
                                <div class="container p-2">
                                    <label for="inputIdFechaInicio" class="form-label">Desde</label>
                                </div>
                            </div>
                            <div class="col">
                                <input type="date" class="form-control" id="InputFechaInicio" value="" runat="server" clientidmode="Static" />
                            </div>

                            <div class="col-2 col-md-1">
                                <div class="container p-2">
                                    <label for="inputIdFechaFin" class="form-label">Hasta</label>
                                </div>
                            </div>
                            <div class="col">
                                <input type="date" class="form-control" id="InputFechaFin" value="" runat="server" clientidmode="Static" />
                            </div>

                        </div>
                        <div class="col align-self-end g-3 p-3">
                            <div>

                                <button id="BtnImprimir" onserverclick="BtnImprimir_ServerClick" runat="server" class="btn btn-primary w-100" clientidmode="Static">
                                    <b>
                                        <img src="/Content/bootstrap-icons/icons/printer-fill.svg" alt="Bootstrap" width="22" height="22" /><i>
                                    Impri. </i></b>
                                </button>

                            </div>
                            <br />
                            <div>

                                <button id="BtnBuscar" onserverclick="BtnBuscar_ServerClick" runat="server" class="btn btn-primary w-100" clientidmode="Static">
                                    <b>
                                        <img src="/Content/bootstrap-icons/icons/search.svg" alt="Bootstrap" width="22" height="22" /><i>
                                    Buscar </i></b>
                                </button>

                            </div>
                        </div>
                    </div>
                </div>

                <div id="div-resumen" class="col-12 col-md-4 p-3 border border-danger border-2 back bg-gradient bg-light  ">
                    <div class="row  align-content-center">
                         <label class="form-label">RESUMEN DE COBROS</label>
                        <p class="m-0 text-dark fw-bold">
                            <label class="form-label">Total Capital: RD$</label><label runat="server" id="lbTCapital" class="form-label text-danger">0.00</label>
                        </p>
                        <p class="m-0 text-dark fw-bold">
                            <label class="form-label">Total Interes: RD$</label><label runat="server" id="lbTInteres" class="form-label text-danger">0.00</label>
                        </p>
                        <p class="m-0 text-dark fw-bold">
                            <label class="form-label">Total Atraso: RD$</label><label runat="server" id="lbTAtraso" class="form-label text-danger">0.00</label>
                        </p>
                        <p class="m-0 text-dark fw-bold">
                            <label class="form-label">Total: RD$</label><label runat="server" id="lbTotal" class="form-label text-danger">0.00</label>
                        </p>

                    </div>

                </div>
            </div>
             <div id="div-list">
             </div>

            <div>
                <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
                </asp:ScriptManager>
                <!-- Modal -->
                <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLabel">Buscar Cliente</h5>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div runat="server" class="modal-body" onload="CargarClientes">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="container">
                                            <div class="row align-items-end">
                                                <div class="col-9 col-md-10">
                                                    <asp:TextBox ID="TbNombreCliente" runat="server" class="form-control" placeholder="Nombre"></asp:TextBox>
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


            </div>
        </div>
        <br />
         <div id="DivReciboCobro">

        </div>
        <div id="DivGridViewListCobros" runat="server" class="container table-responsive">


            <asp:GridView ID="GvListCobros" runat="server" Width="100%"
                CssClass="table table-responsive table-striped table-hover table-sm" AutoGenerateColumns="False"
                DataKeyNames="ID"
                EmptyDataText="No se encontraron datos entre los limites establecidos!"
                 OnSelectedIndexChanged="GvListCobros_SelectedIndexChanged"
                AllowCustomPaging="True"
                ForeColor="#333333"
                GridLines="Horizontal">

                <Columns>

                    <%--ItemStyle-CssClass="d-none d-lg-block" HeaderStyle-CssClass="d-none d-lg-block"--%>

                    <asp:BoundField DataField="ID" HeaderText="ID">
                        <HeaderStyle CssClass="ocultar-div-md" Wrap="False"></HeaderStyle>
                        <ItemStyle CssClass="ocultar-div-md" Wrap="False"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="CustomerName" HeaderText="Cliente" />
                    <asp:BoundField DataField="QuotaNumber" HeaderText="# Cuota" />
                    <asp:BoundField DataField="Date" HeaderText="Fecha" />
                    <asp:BoundField DataField="CapitalPay" HeaderText="Capital">
                        <HeaderStyle CssClass="ocultar-div-md" Wrap="False"></HeaderStyle>
                        <ItemStyle CssClass="ocultar-div-md" Wrap="False"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="InterestPay" HeaderText="Interes">
                        <HeaderStyle CssClass="ocultar-div-md" Wrap="False"></HeaderStyle>
                        <ItemStyle CssClass="ocultar-div-md" Wrap="False"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="DelayPay" HeaderText="Atraso">
                        <HeaderStyle CssClass="ocultar-div-md" Wrap="False"></HeaderStyle>
                        <ItemStyle CssClass="ocultar-div-md" Wrap="False"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Amount" HeaderText="Monto" />
                    <asp:BoundField DataField="Comment" HeaderText="Comentario">
                        <HeaderStyle CssClass="ocultar-div-md" Wrap="False"></HeaderStyle>
                        <ItemStyle CssClass="ocultar-div-md" Wrap="False"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Type" HeaderText="Tipo C.">
                        <HeaderStyle CssClass="ocultar-div-md" Wrap="False"></HeaderStyle>
                        <ItemStyle CssClass="ocultar-div-md" Wrap="False"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="RouteName" HeaderText="Ruta">
                        <HeaderStyle CssClass="ocultar-div-md" Wrap="False"></HeaderStyle>
                        <ItemStyle CssClass="ocultar-div-md" Wrap="False"></ItemStyle>
                    </asp:BoundField>
                       <asp:BoundField DataField="LoandID" HeaderText="ID Prest.">
                        <HeaderStyle CssClass="ocultar-div-md" Wrap="False"></HeaderStyle>
                        <ItemStyle CssClass="ocultar-div-md" Wrap="False"></ItemStyle>
                    </asp:BoundField>
                    <asp:ButtonField ImageUrl="/Content/bootstrap-icons/icons/printer-fill.svg" CommandName="Select" HeaderText="" ButtonType="Image">
                        <ControlStyle CssClass="btn btn-warning"></ControlStyle>
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle CssClass="btn-warning" HorizontalAlign="Center" Width="50px" />
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
