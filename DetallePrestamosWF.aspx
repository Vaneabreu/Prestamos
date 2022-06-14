<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetallePrestamosWF.aspx.cs" Inherits="SoftLoans.DetallePrestamosWF" %>

<!DOCTYPE html>

<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Detalle</title>
    <!-- Bootstrap CSS -->
    <link href="/Content/bootstrap.min.css" rel="stylesheet" type="text/css">
    <script src="/Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>

    <!-- SweetAlert -->
    <script src="/Scripts/SweetAlert.min.js"></script>
    <link href="/Content/sweetalert/sweet-alert.css" rel="stylesheet" />


    <link href="/Content/estilos.css" rel="stylesheet" type="text/css">

    <!-- Print -->

    <link href="/Content/print.min.css" rel="stylesheet" type="text/css">
    <%--<script src="/Scripts/print.min.js"></script>--%>
    <script src="https://unpkg.com/print-js@1.0.60/dist/print.js"></script>
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
        <div class="container">
            <div class="row g-2">
                <div class="col-6">
                    <div class="row justify-content-start">
                        <div class="col-md-6">
                            <b>
                                <label class="form-label"># Préstamo</label></b>
                        </div>
                        <div class="col-md-6">
                            <label runat="server" id="TbIDPrestamo" class="form-label"></label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <b>
                                <label class="form-label">Cliente</label></b>
                        </div>
                        <div class="col-md-6">
                            <label runat="server" id="TbCustomerName" class="form-label"></label>
                        </div>


                    </div>


                </div>
                <div class="col-6">
                    <div class="row justify-content-start">
                          <div class="col-md-6">
                            <b>
                                <label class="form-label">Balance Pendiente</label></b>
                        </div>
                        <div class="col-md-6">
                            <label runat="server" id="LbBalancePendiente" class="form-label"></label>
                        </div>
                    </div>
                    <div class="row justify-content-start">
                          <div class="col-md-6">
                            <b>
                                <label class="form-label">Balance Pagado</label></b>
                        </div>
                        <div class="col-md-6">
                            <label runat="server" id="LbBalancePagado" class="form-label"></label>
                        </div>
                    </div>
                </div>


                <div class="col-4 col-md-4">
                    <b>
                        <label class="form-label">Acto</label></b>
                </div>
                <div class="col-8 col-md-8">
                    <asp:TextBox ID="TextActo" type="text" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="col-4 col-md-4">
                    <b>
                        <label class="form-label">Folio</label></b>
                </div>
                <div class="col-8 col-md-8">
                    <asp:TextBox ID="TextFolio" type="text" runat="server" class="form-control"></asp:TextBox>
                </div>

                <br />

                <div class="col">
                    <div class="col g-1">
                        <br />
                        <b>
                            <label id="LbTipoNCF" runat="server" class="form-label">TIPO NCF</label></b>
                        <asp:DropDownList ID="DropDownTipoNCF" runat="server" CssClass="btn btn-secondary dropdown-toggle flex-column w-50">
                        </asp:DropDownList>

                        <button id="btnPrintContrato" onserverclick="BtnImprimir_Click" runat="server" class="btn btn-primary">
                            <b>
                                <img src="/Content/bootstrap-icons/icons/printer.svg" alt="Bootstrap" width="22"
                                    height="22" /><i> Impr. Contrato</i></b>
                        </button>

                        <button id="BtnMontoAbono" runat="server" style="background-color: transparent; border: hidden; width: 120px;" class="btn" onclick="return false">

                            <asp:TextBox ID="TbMontoAbono" type="number" runat="server" class="form-control" placeholder="0.00"></asp:TextBox>

                        </button>
                        <button id="BtnAbonarCapital" runat="server" type="button" class="btn btn-success w-auto" data-bs-toggle="modal" data-bs-target="#exampleModalAbonarCapital">

                            <b>
                                <img src="/Content/bootstrap-icons/icons/credit-card.svg" alt="Bootstrap" width="22"
                                    height="22" /><i> Abonar capital </i></b>
                        </button>




                        <button id="BtnMonto" runat="server" style="background-color: transparent; border: hidden; width: 120px;" class="btn" onclick="return false">

                            <asp:TextBox ID="TbMonto" type="number" runat="server" class="form-control" placeholder="0.00"></asp:TextBox>
                            <asp:TextBox ID="TbMontoMora" type="number" runat="server" ReadOnly="true" class="form-control" placeholder="0.00"></asp:TextBox>

                        </button>
                        <button id="BtnPagar" runat="server" type="button" class="btn btn-success w-auto" data-bs-toggle="modal" data-bs-target="#exampleModalPagar">

                            <b>
                                <img src="/Content/bootstrap-icons/icons/credit-card.svg" alt="Bootstrap" width="22"
                                    height="22" /><i> Pagar </i></b>
                        </button>
                        <button id="BtnModificar" runat="server" type="button" class="btn btn-warning w-auto" data-bs-toggle="modal" data-bs-target="#exampleModalModificar">
                            <b>
                                <img src="/Content/bootstrap-icons/icons/pencil-square.svg" alt="Bootstrap" width="22" height="22" /><i>
                                Modificar</i></b>
                        </button>
                        <button id="BtnBuscar" onserverclick="BtnBuscar_ServerClick" runat="server" class="btn btn-primary d-none">
                        </button>


                    </div>
                </div>


            </div>
        </div>

        <!-- Modal Pagar -->
        <div class="modal fade" id="exampleModalPagar" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <img src="/Content/bootstrap-icons/icons/exclamation-triangle.svg" alt="Bootstrap" width="32" height="32" class="btn-warning rounded-3" />
                        <div class="container g-2">
                            <h5 class="modal-title" id="exampleModalLabel">¡Proceso de Pago!</h5>
                        </div>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div id="BodyPago" class="modal-body" onload="">
                        <asp:Label ID="LbBodyPago" runat="server"></asp:Label>
                        ¿Está seguro de continuar con el proceso de pago?
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                        <button type="button" class="btn btn-success" runat="server" onserverclick="BtnPagar_ServerClick">Continuar</button>
                    </div>
                </div>
            </div>
        </div>


        <!-- Modal Abonar Capital -->
        <div class="modal fade" id="exampleModalAbonarCapital" tabindex="-1" aria-labelledby="exampleModalLabelAbonarCapital" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <img src="/Content/bootstrap-icons/icons/exclamation-triangle.svg" alt="Bootstrap" width="32" height="32" class="btn-warning rounded-3" />
                        <div class="container g-2">
                            <h5 class="modal-title" id="exampleModalLabelAbonarCapital">¡Proceso de Pago!</h5>
                        </div>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div id="BodyAbono" class="modal-body" onload="">
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                        ¿Está seguro de continuar con el proceso de pago?
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                        <button type="button" class="btn btn-success" runat="server" onserverclick="BtnAbonarCapital_ServerClick">Continuar</button>
                    </div>
                </div>
            </div>
        </div>

        <br />


        <!-- Modal Modificar -->
        <div class="modal fade" id="exampleModalModificar" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <img src="/Content/bootstrap-icons/icons/exclamation-triangle.svg" alt="Bootstrap" width="32" height="32" class="btn-warning rounded-3" />
                        <div class="container g-2">
                            <h5 class="modal-title">¡Proceso de Modificaion!</h5>
                        </div>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="LbMensajeModificar" Text="" runat="server"></asp:Label>
                        <br />

                        <div class="row g-3">
                            <div class="col-md-6">
                                <label for="LbInteresActual" class="form-label">Interes Actual</label>
                                <asp:TextBox ID="TbInteresActual" ReadOnly="true" runat="server" class="form-control" placeholder="0.00"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="LbAtrasoActual" class="form-label">Atraso Actual</label>
                                <asp:TextBox ID="TbAtrasoActual" ReadOnly="true" runat="server" class="form-control" placeholder="0.00"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="LbInteresNuevo" class="form-label">Interes Nuevo</label>
                                <asp:TextBox ID="TbInteresNuevo" type="number" runat="server" class="form-control" placeholder="0.00"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="LbAtrasoNuevo" class="form-label">Atraso Nuevo</label>
                                <asp:TextBox ID="TbAtrasoNuevo" type="number" runat="server" class="form-control" placeholder="0.00"></asp:TextBox>
                            </div>


                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                        <button type="button" class="btn btn-success" runat="server" onserverclick="BtnModificar_ServerClick">Continuar</button>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div id="DivReciboCobro">
        </div>
        <div id="DivContrato">
        </div>



        <div class="container table-responsive">
            <asp:GridView ID="GvDetallePrestamos" runat="server" Width="100%"
                CssClass="table table-responsive table-striped table-hover table-sm" AutoGenerateColumns="False"
                DataKeyNames="ID"
                EmptyDataText="No se encontraron datos entre los limites establecidos!"
                AllowCustomPaging="True"
                OnSelectedIndexChanged="GvDetallePrestamos_SelectedIndexChanged"
                GridLines="Horizontal">

                <Columns>

                    <%--ItemStyle-CssClass="d-none d-lg-block" HeaderStyle-CssClass="d-none d-lg-block"--%>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID">
                        <HeaderStyle Width="100px" HorizontalAlign="Center" CssClass="ocultar-div-sm"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" CssClass="ocultar-div-sm"></ItemStyle>
                    </asp:BoundField>


                    <asp:BoundField DataField="QuotaNumber" HeaderText="Cuota" SortExpression="Cuota" />
                    <asp:BoundField DataField="Date" HeaderText="Fecha" DataFormatString="{0:d}" SortExpression="Fecha" />
                    <asp:BoundField DataField="TotalDueAmount" HeaderText="Deuda" SortExpression="Deuda" />

                    <asp:BoundField DataField="PayStatus" HeaderText="Fecha Pago" DataFormatString="{0:d}" SortExpression="Fecha Pago">
                        <HeaderStyle CssClass="ocultar-div-lg"></HeaderStyle>
                        <ItemStyle CssClass="ocultar-div-lg"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="CapitalBalance" HeaderText="Capital" SortExpression="Capital"
                        HeaderStyle-Width="100px" ItemStyle-Width="100px">
                        <HeaderStyle Width="100px" CssClass="ocultar-div-xl"></HeaderStyle>
                        <ItemStyle Width="100px" CssClass="ocultar-div-xl"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="InterestBalance" HeaderText="Interes" SortExpression="Interes"
                        HeaderStyle-Width="100px" ItemStyle-Width="100px">
                        <HeaderStyle Width="100px" CssClass="ocultar-div-xl"></HeaderStyle>
                        <ItemStyle Width="100px" CssClass="ocultar-div-xl"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="DelayBalance" HeaderText="Atraso" SortExpression="Atraso"
                        HeaderStyle-Width="100px" ItemStyle-Width="100px">
                        <HeaderStyle Width="100px" CssClass="ocultar-div-xl"></HeaderStyle>
                        <ItemStyle Width="100px" CssClass="ocultar-div-xl"></ItemStyle>
                    </asp:BoundField>



                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="CbHeader" runat="server" AutoPostBack="true" Text=" Todo" OnCheckedChanged="CbHeader_CheckedChanged" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CbItem" runat="server" AutoPostBack="true" OnCheckedChanged="CbItem_CheckedChanged" />
                        </ItemTemplate>
                    </asp:TemplateField>



                </Columns>




                <EditRowStyle BackColor="#2461BF" Width="100%" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#212529" Font-Bold="True" ForeColor="White"
                    HorizontalAlign="Center" Wrap="False" />
                <%-- #0d6efd --%>
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" Wrap="False" />
                <SelectedRowStyle CssClass="bg-danger text-info" BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />

            </asp:GridView>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
            </asp:ScriptManager>
        </div>
        <div class="container" id="ReciboImprimir" runat="server" style="background-color: aqua; display: none;">
        </div>

    </form>


</body>

</html>
