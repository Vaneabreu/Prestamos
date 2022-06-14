<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketsListWF.aspx.cs" Inherits="SoftLoans.TicketsListWF" %>

<!DOCTYPE html>

<html lang="en">

<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Tickets</title>
    <!-- Bootstrap CSS -->
    <link href="/Content/bootstrap.min.css" rel="stylesheet" type="text/css">
    <script src="/Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>

    <!-- SweetAlert -->
    <script src="/Scripts/SweetAlert.min.js"></script>
    <link href="/Content/sweetalert/sweet-alert.css" rel="stylesheet" />

    <!-- Print -->
    <link href="/Content/print.min.css" rel="stylesheet" type="text/css">
    <script src="/Scripts/print.min.js"></script>

    <link href="/Content/estilos.css" rel="stylesheet" type="text/css">

    <script>
        function BtPrint(prn) {
            var S = "#Intent;scheme=rawbt;";
            var P = "package=ru.a402d.rawbtprinter;end;";
            var textEncoded = encodeURI(prn);
            window.location.href = "intent:" + textEncoded + S + P;
        }
    </script>


</head>

<body>



    <script src="/Scripts/app.js"></script>

    <script src="/Scripts/bootstrap.bundle.min.js" type="text/javascript"></script>

    <%--    <pre id="pre_print" style="display: none">
--------------------------------
            TEST
--------------------------------
Items 1
                      3 x $20.00
Items 2
                      1 x $40.00
********************************
                   TOTAL $100.00
--------------------------------
        </pre>--%>

    <form id="form1" runat="server">
        <%--Menu User--%>
        <nav runat="server" id="menuUser" class="navbar navbar-expand-lg navbar-dark bg-primary " style="height: 10% !important">
            <div class="container-fluid">
                <a></a>
                <button runat="server" class="navbar-brand btn-primary" onserverclick="BtnLoterias_Click">
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
                                <asp:Button ID="BtnCuadre" runat="server" Text="Cuadre" BorderWidth="0" BackColor="Transparent" ForeColor="White"
                                    OnClick="BtnCuadre_Click" />
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

            <div class="row g-2">
                <div class="col-2 col-md-2">
                    <div class="container p-2">
                        <label id="inputIdCliente4" class="form-label">Ticket</label>
                    </div>
                </div>
                <div class="col-10 col-md-10">
                    <asp:TextBox ID="TbTicketID" runat="server" type="number" class="form-control" placeholder="ID Ticket"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                        ControlToValidate="TbTicketID" runat="server"
                        ErrorMessage="Solo se permiten números"
                        ValidationExpression="\d+" ForeColor="Red"
                        EnableClientScript="true">
                    </asp:RegularExpressionValidator>
                </div>

                <div class="col-2 col-md-1">
                    <div class="container p-2">
                        <label for="inputIdFechaInicio" class="form-label">Desde</label>
                    </div>
                </div>
                <div class="col-10 col-md-3">
                    <input type="date" class="form-control" id="InputFechaInicio" value="" runat="server" clientidmode="Static" />
                </div>

                <div class="col-2 col-md-1">
                    <div class="container p-2">
                        <label for="inputIdFechaFin" class="form-label">Hasta</label>
                    </div>
                </div>
                <div class="col-10 col-md-3">
                    <input type="date" class="form-control" id="InputFechaFin" value="" runat="server" clientidmode="Static" />
                </div>

                <div class="col-2 col-md-1">
                    <div class="container p-2">
                        <label runat="server" id="inputBranch" class="form-label">Punto</label>
                    </div>
                </div>
                <div class="col-10 col-md-3">
                    <asp:DropDownList ID="DropDownListBranch" runat="server" CssClass="btn btn-secondary dropdown-toggle" Width="100%">
                    </asp:DropDownList>
                </div>





                <div class="col-md-6">
                    <div class="col g-1">
                        <button id="BtnBuscar" onserverclick="BtnBuscar_Click" runat="server" class="btn btn-primary" clientidmode="Static">
                            <b>
                                <img src="/Content/bootstrap-icons/icons/search.svg" alt="Bootstrap" width="22" height="22" /><i>
                                    Buscar </i></b>
                        </button>
                        <button onserverclick="BtnImprimir_Click" runat="server" class="btn btn-primary">
                            <b>
                                <img src="/Content/bootstrap-icons/icons/file-earmark-plus.svg" alt="Bootstrap" width="22"
                                    height="22" /><i> Imprimir </i></b>
                        </button>
                        <button class="btn btn-primary" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasWithBackdrop" aria-controls="offcanvasWithBackdrop">
                            <b>
                                <img src="/Content/bootstrap-icons/icons/info-circle.svg" alt="Bootstrap" width="22" height="22" />
                                <i>Inf.Lot.</i>
                            </b>
                        </button>

                        <div class="offcanvas offcanvas-start" tabindex="-1" id="offcanvasWithBackdrop" aria-labelledby="offcanvasWithBackdropLabel">
                            <div class="offcanvas-header">
                                <h5 class="offcanvas-title" id="offcanvasWithBackdropLabel">Iniciales de Loterias</h5>
                                <button type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                            </div>
                            <div class="offcanvas-body">
                                <asp:Label runat="server" CssClass="btn btn-info w-100">NA  -Nacional</asp:Label>
                                <asp:Label runat="server" CssClass="btn btn-light w-100">LE  -Leidsa</asp:Label>
                                <asp:Label runat="server" CssClass="btn btn-info w-100">SNL -Super PaleNacional-Leidsa</asp:Label>
                                <asp:Label runat="server" CssClass="btn btn-light w-100">LO  -Loteka</asp:Label>
                                <asp:Label runat="server" CssClass="btn btn-info w-100">GA  -Ganamas</asp:Label>
                                <asp:Label runat="server" CssClass="btn btn-light w-100">SRG -Super PaleReal-Gana mas</asp:Label>
                                <asp:Label runat="server" CssClass="btn btn-info w-100">RE  -Real</asp:Label>
                                <asp:Label runat="server" CssClass="btn btn-light w-100">NYT -NewYork Tarde</asp:Label>
                                <asp:Label runat="server" CssClass="btn btn-info w-100">NYN -NewYork Noche</asp:Label>
                                <asp:Label runat="server" CssClass="btn btn-light w-100">FD  -FloridaDia</asp:Label>
                                <asp:Label runat="server" CssClass="btn btn-info w-100">FN  -FloridaNoche</asp:Label>
                                <asp:Label runat="server" CssClass="btn btn-light w-100">LP  -LaPrimera</asp:Label>
                                <asp:Label runat="server" CssClass="btn btn-info w-100">LS  -LaSuerte</asp:Label>
                                <asp:Label runat="server" CssClass="btn btn-light w-100">LD  -Lotedom</asp:Label>
                                <asp:Label runat="server" CssClass="btn btn-info w-100">AM  -AguilaMañana</asp:Label>
                                <asp:Label runat="server" CssClass="btn btn-light w-100">AMD -AguilaMedioDia</asp:Label>
                                <asp:Label runat="server" CssClass="btn btn-info w-100">AT  -AguilaTarde</asp:Label>
                                <asp:Label runat="server" CssClass="btn btn-light w-100">AN  -AguilaNoche</asp:Label>
                                <asp:Label runat="server" CssClass="btn btn-info w-100">KGT -King Lottery Tarde</asp:Label>
                                <asp:Label runat="server" CssClass="btn btn-light w-100">KGN -King Lottery Noche</asp:Label>

                            </div>
                        </div>



                    </div>


                </div>

            </div>


        </div>


        <br />
        <div class="container table-responsive">
            <asp:GridView ID="GvTickets" runat="server" Width="100%"
                CssClass="table table-responsive table-striped table-hover table-sm" AutoGenerateColumns="False"
                DataKeyNames="transactionID"
                EmptyDataText="No se encontraron datos entre los limites establecidos!"
                AllowCustomPaging="True"
                OnSelectedIndexChanged="GvTickets_SelectedIndexChanged"
                OnRowDeleting="GvTickets_RowDeleting" ForeColor="#333333"
                OnRowUpdating="GvTickets_RowUpdating"
                GridLines="Horizontal">

                <Columns>

                    <%--ItemStyle-CssClass="d-none d-lg-block" HeaderStyle-CssClass="d-none d-lg-block"--%>

                    <asp:BoundField DataField="transactionID" HeaderText="ID" SortExpression="ID" />

                    <asp:BoundField DataField="codeName" HeaderText="Cod." SortExpression="Cod. Loteria" HeaderStyle-Wrap="true">
                        <HeaderStyle Wrap="False" Width="10px"></HeaderStyle>
                        <ItemStyle Wrap="False" Width="10px"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="lotteryName" HeaderText="Loteria" SortExpression="Loteria" HeaderStyle-Wrap="true">
                        <HeaderStyle CssClass="ocultar-div-md" Wrap="False"></HeaderStyle>
                        <ItemStyle CssClass="ocultar-div-md" Wrap="False"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="amount" HeaderText="Monto" SortExpression="Monto" />

                    <asp:ButtonField ImageUrl="/Content/bootstrap-icons/icons/upload.svg" Text="" CommandName="Select" HeaderText="Copiar" ButtonType="Image">
                        <ControlStyle CssClass="btn btn-warning"></ControlStyle>
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle CssClass="btn-warning" HorizontalAlign="Center" Width="100px" />
                    </asp:ButtonField>


                    <asp:ButtonField ImageUrl="/Content/bootstrap-icons/icons/x-circle.svg" Text="" CommandName="Delete" HeaderText="Canc." ButtonType="Image">
                        <ControlStyle CssClass="btn btn-danger"></ControlStyle>
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle CssClass="btn-danger" HorizontalAlign="Center" Width="100px"></ItemStyle>
                    </asp:ButtonField>

                    <asp:ButtonField ImageUrl="/Content/bootstrap-icons/icons/card-list.svg" Text="" CommandName="Update" HeaderText="Det." ButtonType="Image">
                        <ControlStyle CssClass="btn btn-info"></ControlStyle>
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle CssClass="btn-info" HorizontalAlign="Center" Width="100px"></ItemStyle>
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
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
            </asp:ScriptManager>
        </div>

        <div class="container" id="ListadoImprimir" runat="server" style="background-color: aqua; display: none;">
        </div>


    </form>

</body>



</html>


