<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketsDetalleWF.aspx.cs"
    Inherits="SoftLoans.TicketsDetalleWF" %>

<!DOCTYPE html>

<html>

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
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

    <pre id="pre_print" style="display: none">
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
        </pre>

    <form id="form1" runat="server">
        <%--Menu User--%>
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
                                        <img src="/Content/bootstrap-icons/icons/suit-diamond.svg" alt="Bootstrap" width="22" height="22"/>
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
                <div class="col-3 col-md-3">
                    <b>
                        <label class="form-label"># Ticket</label></b>
                </div>
                <div class="col-9 col-md-9">
                    <label runat="server" id="TbTicketID" class="form-label"></label>
                </div>

                <div class="col-3 col-md-3">
                    <b>
                        <label class="form-label">Loteria</label></b>
                </div>
                <div class="col-9 col-md-9">
                    <label runat="server" id="TbLotteryName" class="form-label"></label>
                </div>
                <div class="col-3 col-md-3">
                    <b>
                        <label class="form-label">T. Ganado</label></b>
                </div>
                <div class="col-9 col-md-9">
                    <label runat="server" id="TbTotalGain" class="form-label"></label>
                </div>

                <div class="col-md-4">
                    <div class="col g-1">
                        <button onserverclick="BtnImprimir_Click" runat="server" class="btn btn-primary">
                            <b>
                                <img src="/Content/bootstrap-icons/icons/file-earmark-plus.svg" alt="Bootstrap" width="22"
                                    height="22" /><i>Re-Imprimir </i></b>
                        </button>


                    </div>


                </div>

            </div>


        </div>

        <div class="container">
        </div>
        <br />
        <div class="container table-responsive">
            <asp:GridView ID="GvTicketsDetail" runat="server" Width="100%"
                CssClass="table table-responsive table-striped table-hover table-sm" AutoGenerateColumns="False"
                DataKeyNames="transactionID"
                EmptyDataText="No se encontraron datos entre los limites establecidos!"
                AllowCustomPaging="True"
                OnSelectedIndexChanged="GvTicketsDetail_SelectedIndexChanged"
                OnRowDeleting="GvTicketsDetail_RowDeleting" ForeColor="#333333"
                GridLines="Horizontal">

                <Columns>

                    <%--ItemStyle-CssClass="d-none d-lg-block" HeaderStyle-CssClass="d-none d-lg-block"--%>


                    <asp:BoundField DataField="numbers" HeaderText="Números" SortExpression="Números" HeaderStyle-Wrap="true">
                        <HeaderStyle Wrap="False" Width="10px"></HeaderStyle>
                        <ItemStyle Wrap="False" Width="10px"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="playTypeName" HeaderText="Tipo" SortExpression="Tipo" HeaderStyle-Wrap="true">
                        <HeaderStyle Wrap="False"></HeaderStyle>
                        <ItemStyle Wrap="False"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="amount" HeaderText="Monto" SortExpression="Monto" />

                    <asp:BoundField DataField="gainAmount" HeaderText="Ganado" SortExpression="Ganado" />



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

        <div class="container printClose" id="TicketReImprimirC" runat="server" style="background-color: aqua; display: none; width: 300px; text-align-last: center; align-content: center;">
            <div class="row" id="TicketReImprimir" runat="server">
            </div>
            <br />
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-6">
                        <img runat="server" src="" id="imgQRCode" />
                    </div>
                </div>
            </div>

            <br />
            <div>
            </div>





        </div>


    </form>

</body>



</html>


