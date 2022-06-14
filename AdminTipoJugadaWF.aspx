<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminTipoJugadaWF.aspx.cs" Inherits="SoftLoans.AdminTipoJugadaWF" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Tipo de Jugadas</title>
    <!-- Bootstrap CSS -->
    <link href="/Content/bootstrap.min.css" rel="stylesheet" type="text/css">
    <script src="/Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>


    <!-- SweetAlert -->
    <script src="/Scripts/SweetAlert.min.js"></script>
    <link href="/Content/sweetalert/sweet-alert.css" rel="stylesheet" />


    <link href="/Content/estilos.css" rel="stylesheet" type="text/css">
</head>

<body>
    <script src="/Scripts/app.js"></script>
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
                        <i>Soft Banking</i>
                    </b>
                </button>

                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent"
                    aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>

                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item dropdown">
                            <a class="nav-link active dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown"
                                aria-expanded="false">General
                            </a>
                            <ul class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                                <%--<li>
                                    <a class="dropdown-item" href="clientes.html">
                                        <img src="/Content/bootstrap-icons/icons/file-earmark-easel-fill.svg" alt="Bootstrap"
                                            width="22" height="22" />
                                        <asp:Button ID="BtnPuntos" runat="server" Text="Puntos" BorderWidth="0" BackColor="Transparent" />
                                    </a>
                                </li>--%>
                                <%--  <li>
                                    <a class="dropdown-item" href="clientes.html">
                                        <img src="/Content/bootstrap-icons/icons/person-square.svg" alt="Bootstrap" width="22"
                                            height="22" />
                                        <asp:Button ID="BtnEmpleados" runat="server" Text="Empleados" BorderWidth="0" BackColor="Transparent" />
                                    </a>
                                </li>--%>
                                <li>
                                    <a class="dropdown-item" href="#">
                                        <img src="/Content/bootstrap-icons/icons/bank2.svg" alt="Bootstrap" width="22" height="22" />
                                        <asp:Button ID="BtnLoterias" runat="server" Text="Loterias" BorderWidth="0" BackColor="Transparent"
                                            OnClick="BtnLoteriasAdmin_Click" />
                                    </a>
                                </li>

                            </ul>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link active dropdown-toggle" aria-current="page" href="#" id="navbarDropdownMenuLink"
                                role="button" data-bs-toggle="dropdown" aria-expanded="false">Jugadas
                            </a>
                            <ul class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                                <li>
                                    <a class="dropdown-item" href="#">
                                        <img src="/Content/bootstrap-icons/icons/dice-2.svg" alt="Bootstrap" width="22" height="22" />
                                        <asp:Button ID="BtnTipoJugada" runat="server" Text="Tipo de Jugadas" BorderWidth="0" BackColor="Transparent"
                                            OnClick="BtnAdminTipoJugada_Click" />
                                    </a>
                                </li>
                                <li>
                                    <a class="dropdown-item" href="#">
                                        <img src="/Content/bootstrap-icons/icons/dice-2-fill.svg" alt="Bootstrap" width="22" height="22" />
                                        <asp:Button ID="Button1" runat="server" Text="Limite por Tipo de Jugada" BorderWidth="0" BackColor="Transparent"
                                            OnClick="BtnAdminLimiteTipoJugada_Click" />
                                    </a>
                                </li>
                                <li>
                                    <a class="dropdown-item" href="#">
                                        <img src="/Content/bootstrap-icons/icons/sort-numeric-up-alt.svg" alt="Bootstrap"
                                            width="22" height="22" />
                                        <asp:Button ID="Button2" runat="server" Text="Limite por Numeros" BorderWidth="0" BackColor="Transparent"
                                            OnClick="BtnAdminLimiteNumero_Click" />
                                    </a>
                                </li>
                                <li>
                                    <a class="dropdown-item" href="#">
                                        <img src="/Content/bootstrap-icons/icons/link.svg" alt="Bootstrap" width="22" height="22" />
                                        <asp:Button ID="Button3" runat="server" Text=" Combinaciones Permitidas" BorderWidth="0" BackColor="Transparent"
                                            OnClick="BtnAdminCombinacionesPermitidas_Click" />
                                    </a>
                                </li>
                                <li>
                                    <a class="dropdown-item" href="#">
                                        <img src="/Content/bootstrap-icons/icons/trophy.svg" alt="Bootstrap" width="22" height="22" />

                                        <asp:Button ID="BtnNumerosGanadoresAdmin" runat="server" Text="Números Ganadores" BorderWidth="0" BackColor="Transparent"
                                            OnClick="BtnNumerosGanadores_Click" />
                                    </a>
                                </li>
                                <li>
                                    <a class="dropdown-item" href="#">
                                        <img src="/Content/bootstrap-icons/icons/suit-diamond.svg" alt="Bootstrap" width="22" height="22" />
                                        <asp:Button ID="Button4" runat="server" Text="Numeros Jugados" BorderWidth="0" BackColor="Transparent"
                                            OnClick="BtnAdminNumerosJugados_Click" />
                                    </a>
                                </li>


                                <%-- <li>
                                    <a class="dropdown-item" href="#">
                                        <img src="/Content/bootstrap-icons/icons/percent.svg" alt="Bootstrap" width="22"
                                            height="22"> Porciento X Tipo de Jugada</img>
                                    </a>
                                </li>--%>
                            </ul>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link active dropdown-toggle" aria-current="page" href="#" id="navbarDropdownMenuLink"
                                role="button" data-bs-toggle="dropdown" aria-expanded="false">Tickets
                            </a>
                            <ul class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                                <li>
                                    <a class="dropdown-item" href="#">
                                        <img src="/Content/bootstrap-icons/icons/stickies.svg" alt="Bootstrap" width="22"
                                            height="22" />
                                        <asp:Button ID="BtnTicketsAdmin" runat="server" Text="Tickets" BorderWidth="0" BackColor="Transparent" ForeColor="black"
                                            OnClick="BtnTickets_Click" />
                                    </a>
                                </li>
                                <li>
                                    <a class="dropdown-item" href="#">
                                        <img src="/Content/bootstrap-icons/icons/trophy.svg" alt="Bootstrap" width="22"
                                            height="22" />
                                        <asp:Button ID="BtnWinTicketsAdmin" runat="server" Text="Tickets Ganadores" BorderWidth="0" BackColor="Transparent" ForeColor="black"
                                            OnClick="BtnTicketsWin_Click" />
                                    </a>
                                </li>

                                <li>
                                    <a class="dropdown-item" href="#">
                                        <img src="/Content/bootstrap-icons/icons/spellcheck.svg" alt="Bootstrap" width="22"
                                            height="22" />
                                        <asp:Button ID="BtnCuadreAdmin" runat="server" Text="Cuadre" BorderWidth="0" BackColor="Transparent" ForeColor="black"
                                            OnClick="BtnCuadre_Click" />
                                    </a>
                                </li>

                            </ul>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link active dropdown-toggle" href="#"
                                role="button" data-bs-toggle="dropdown" aria-expanded="false">Seguridad
                            </a>
                            <ul class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                                <li>
                                    <a class="dropdown-item" href="#">
                                        <img src="/Content/bootstrap-icons/icons/person-plus.svg" alt="Bootstrap" width="22" height="22" />
                                        <asp:Button ID="Button5" runat="server" Text="Usuarios" BorderWidth="0" BackColor="Transparent" ForeColor="black"
                                            OnClick="BtnAdminUsuarios_Click" />
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


        <%--Mensajes flotantes--%>
        <!-- Modal -->
        <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <img src="/Content/bootstrap-icons/icons/exclamation-triangle.svg" alt="Bootstrap" width="32" height="32" class="btn-warning rounded-3" />
                        <div class="container g-2">

                            <h5 class="modal-title" id="exampleModalLabel">¡Proceso de Actualización!</h5>
                        </div>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        ¿Está seguro de continuar con el proceso de actualización?
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                        <button runat="server" type="button" class="btn btn-danger" data-bs-dismiss="modal" onserverclick="BtnActualizar_Click">Continuar</button>
                    </div>
                </div>
            </div>
        </div>

        <%--Fin de Mensajes Flotante--%>
        <br />
        <div class="container">

            <div class="row g-2">
                <div class="col-md-2">
                    <div class="container">
                        <div class="row">
                            <div class="col g-1">
                                <asp:TextBox ID="TbID" runat="server" type="number" class="form-control" placeholder="ID"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                    ControlToValidate="TbID" runat="server"
                                    ErrorMessage="Solo se permiten números"
                                    ValidationExpression="\d+" ForeColor="Red"
                                    EnableClientScript="false">
                                </asp:RegularExpressionValidator>
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
                <div class="col-md-3">
                    <div class="container">
                        <div class="row">
                            <div class="col g-1">
                                <asp:DropDownList ID="DropDownListLottery" runat="server" CssClass="btn btn-secondary" Width="100%" ToolTip="Seleccione Loteria">
                                </asp:DropDownList>
                            </div>

                        </div>
                    </div>

                </div>

                <div class="col-4 col-md-1">
                    <div class="container">
                        <div class="row">
                            <div class="col g-1">
                                <button id="BtnBuscar" runat="server" class="btn btn-primary" clientidmode="Static" onserverclick="BtnBuscar_Click">
                                    <b>
                                        <img src="/Content/bootstrap-icons/icons/search.svg" alt="Bootstrap" width="22" height="22" /><i>
                                    Buscar </i></b>
                                </button>
                            </div>
                        </div>

                    </div>

                </div>
                <div class="col-4 col-md-1">
                    <div class="container">
                        <div class="row">

                            <div class="col g-1">
                                <asp:TextBox ID="TbComision" runat="server" type="number" class="form-control" placeholder="%" Width="90"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                    ControlToValidate="TbComision" runat="server"
                                    ErrorMessage="Solo se permiten números"
                                    ValidationExpression="\d+" ForeColor="Red"
                                    EnableClientScript="false">
                                </asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="col-4 col-md-2">
                    <div class="container">
                        <div class="row">
                            <div class="col g-1">
                                <%--type="button" data-bs-toggle="modal" data-bs-target="#exampleModal""--%>
                                <button class="btn btn-primary" type="button" data-bs-toggle="modal" data-bs-target="#exampleModal">
                                    <b>
                                        <img src="/Content/bootstrap-icons/icons/save.svg" alt="Bootstrap" width="22" height="22" /><i>
                                    Actua.</i></b>
                                </button>
                            </div>
                        </div>
                    </div>

                </div>

            </div>


        </div>


        <br />
        <div class="container table-responsive">
            <asp:GridView ID="GvTipoJugada" runat="server" AutoGenerateColumns="False" Width="100%"
                CssClass="table table-responsive table-striped table-hover table-sm"
                DataKeyNames="PlayTypeID,Name,LotteryName,CommissionPercent,PartnerCommissionPercent,Enabled,LotteryID,CustomerID,CustomerName,ShiftName"
                EmptyDataText="No se encontraron datos entre los limites establecidos!"
                AllowCustomPaging="True"
                ForeColor="#333333"
                GridLines="Horizontal">
                <Columns>
                    <asp:BoundField DataField="PlayTypeID" HeaderText="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Nombre" />
                    <asp:BoundField DataField="LotteryName" HeaderText="Loteria">
                        <HeaderStyle CssClass="ocultar-div-md" Wrap="False"></HeaderStyle>
                        <ItemStyle CssClass="ocultar-div-md" Wrap="False"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="CommissionPercent" HeaderText="% C." />
                    <asp:BoundField DataField="PartnerCommissionPercent" HeaderText="% C.S." />
                    <asp:BoundField DataField="Enabled" HeaderText="Activo">
                        <HeaderStyle CssClass="ocultar-div-md" Wrap="False"></HeaderStyle>
                        <ItemStyle CssClass="ocultar-div-md" Wrap="False"></ItemStyle>
                    </asp:BoundField>
                    <%-- <asp:CheckBoxField DataField="Selected" HeaderText="Selec." ReadOnly="false" Visible="false"/>--%>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="CbHeader" runat="server" AutoPostBack="true" Text=" Todo" OnCheckedChanged="CbHeader_CheckedChanged" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CbItem" runat="server" OnCheckedChanged="CbItem_CheckedChanged" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="LotteryID" HeaderText="LotteryID" Visible="false" />
                    <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" Visible="false" />
                    <asp:BoundField DataField="CustomerName" HeaderText="CustomerName" Visible="false" />
                    <asp:BoundField DataField="ShiftName" HeaderText="ShiftName" Visible="false" />

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
