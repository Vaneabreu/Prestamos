<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NumerosGanadoresCrearWF.aspx.cs"
    Inherits="SoftLoans.NumerosGanadoresCrearWF" %>

<!DOCTYPE html>

<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Números Ganadores</title>
    <!-- Bootstrap CSS -->
    <link href="/Content/bootstrap.min.css" rel="stylesheet" type="text/css">

    <!-- SweetAlert -->
    <script src="/Scripts/SweetAlert.min.js"></script>
    <link href="/Content/sweetalert/sweet-alert.css" rel="stylesheet" />


</head>

<body>

    <script src="/Scripts/app.js"></script>
    <script src="/Scripts/bootstrap.bundle.min.js" type="text/javascript"></script>



    <form id="form1" runat="server">

        <%--menu user--%>
        <nav runat="server" id="menuUser" class="navbar navbar-expand-lg navbar-dark bg-primary " style="height: 10% !important">
            <div class="container-fluid">
                <a></a>
                <button runat="server" class="navbar-brand btn-primary">
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
                        <li class="nav-item">
                            <a class="nav-link active">
                                <img src="/Content/bootstrap-icons/icons/gem.svg" alt="Bootstrap" width="22" height="22" />
                                <asp:Button ID="BtnLoteria" runat="server" Text="Loteria" BorderWidth="0" BackColor="Transparent" ForeColor="White"
                                    OnClick="BtnLoterias_Click" />
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active">
                                <img src="/Content/bootstrap-icons/icons/inbox-fill.svg" alt="Bootstrap" width="22" height="22" />
                                <asp:Button ID="BtnCuadre" runat="server" Text="Cuadre" BorderWidth="0" BackColor="Transparent" ForeColor="White" />
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active">
                                <img src="/Content/bootstrap-icons/icons/stickies.svg" alt="Bootstrap" width="22" height="22" />
                                <asp:Button ID="BtnTickets" runat="server" Text="Tickets" BorderWidth="0" BackColor="Transparent" ForeColor="White"
                                    OnClick="BtnTickets_Click" />
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active">
                                <img src="/Content/bootstrap-icons/icons/trophy.svg" alt="Bootstrap" width="22" height="22" />
                                <asp:Button ID="BtnTicketsWin" runat="server" Text="Tickets Ganadores" BorderWidth="0" BackColor="Transparent" ForeColor="White"
                                    OnClick="BtnTicketsWin_Click" />
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active">
                                <img src="/Content/bootstrap-icons/icons/suit-diamond.svg" alt="Bootstrap" width="22" height="22" />
                                <asp:Button ID="BtnNumerosGanadores" runat="server" Text="Números Ganadores" BorderWidth="0" BackColor="Transparent" ForeColor="White"
                                    OnClick="BtnNumerosGanadores_Click" />
                            </a>
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
        <%--fin menu user--%>

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

        <br />
        <div class="container">
            <div class="row g-3">

                <div class="col-md-6">
                    <label for="inputFirstNumber4" class="form-label">Primer Número</label>
                    <asp:TextBox ID="TbFirstNumber" type="number" runat="server" class="form-control" placeholder="Primer Número" MaxLength="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVFirstNumber" runat="server"
                        ControlToValidate="TbFirstNumber"
                        ErrorMessage="Campo obligatorio"
                        ForeColor="Red"
                        EnableClientScript="false">

                    </asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6">
                    <label for="inputSecondNumber4" class="form-label">Segundo Número</label>
                    <asp:TextBox ID="TbSecondNumber" type="number" runat="server" class="form-control" placeholder="Segundo Número" MaxLength="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVSecondNumber" runat="server"
                        ControlToValidate="TbSecondNumber"
                        ErrorMessage="Campo obligatorio"
                        ForeColor="Red"
                        EnableClientScript="false">

                    </asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6">
                    <label for="inputThirdNumber4" class="form-label">Tercer Número</label>
                    <asp:TextBox ID="TbThirdNumber" type="number" runat="server" class="form-control" placeholder="Tercer Número" MaxLength="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVThirdNumber" runat="server"
                        ControlToValidate="TbThirdNumber"
                        ErrorMessage="Campo obligatorio"
                        ForeColor="Red"
                        EnableClientScript="false">

                    </asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6">
                    <label for="inputDate4" class="form-label">Fecha</label>
                    <input type="date" class="form-control" id="InputFecha" value="" runat="server" clientidmode="Static" />
                </div>
                <div class="col-md-6">
                    <label for="inputLotery4" class="form-label">Loteria</label><br />
                    <asp:DropDownList ID="DropDownListLottery" runat="server" CssClass="btn btn-secondary dropdown-toggle" Width="100%">
                    </asp:DropDownList>
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
                    <button runat="server" type="submit" class="btn btn-success" onserverclick="BtnGuardar_Click">
                        <b>
                            <img src="/Content/bootstrap-icons/icons/save.svg" alt="Bootstrap" width="22" height="22" /><i>
                                Guardar </i></b>
                    </button>
                </div>
            </div>

            <br />
            <div id="DivGridView" runat="server" class="table-responsive">
                <asp:GridView ID="GvBaseDatos" runat="server" AutoGenerateColumns="False" Width="100%"
                    CssClass="table table-responsive table-striped table-hover table-sm"
                    DataKeyNames="DataBaseName,Proceso"
                    EmptyDataText="No se encontraron datos entre los limites establecidos!"
                    AllowCustomPaging="True"
                    ForeColor="#333333"
                    GridLines="Horizontal">
                    <Columns>
                        <asp:BoundField DataField="DataBaseName" HeaderText="Base de datos" />
                        <asp:BoundField DataField="Proceso" HeaderText="Pro." />
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="CbHeader" runat="server" AutoPostBack="true" Text=" Todo" OnCheckedChanged="CbHeader_CheckedChanged" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CbItem" runat="server" OnCheckedChanged="CbItem_CheckedChanged" />
                            </ItemTemplate>
                        </asp:TemplateField>                    

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


        </div>


    </form>

</body>

</html>
