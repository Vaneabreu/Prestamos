<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CuadreWF.aspx.cs" Inherits="SoftLoans.CuadreWF" %>

<!DOCTYPE html>

<html lang="en">

<head>
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
        <%--Menu user--%>
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
                                    OnClick="BtnLoterias_Click" />
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


                <div class="col-md-4">
                    <div class="col g-1">
                        <button id="BtnBuscar" onserverclick="BtnBuscar_Click" runat="server" class="btn btn-primary">
                            <b>
                                <img src="/Content/bootstrap-icons/icons/search.svg" alt="Bootstrap" width="22" height="22" /><i>
                                    Buscar </i></b>
                        </button>
                        <button onserverclick="BtnImprimir_Click" runat="server" class="btn btn-primary">
                            <b>
                                <img src="/Content/bootstrap-icons/icons/file-earmark-plus.svg" alt="Bootstrap" width="22"
                                    height="22" /><i> Imprimir </i></b>
                        </button>

                    </div>
                </div>

            </div>


        </div>


        <br />
        <div class="container" id="ContCuadre">

            <div class="row g-2">

                <div class="col-12 col-md-5">
                    <div class="card" style="width: 18rem;">
                        <div class="card-header">
                            <b>
                                <label for="inputBalanceLabel" class="form-label">Balance Acumulado</label></b>
                        </div>
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item">
                                <b>
                                    <label style="font-family: 'Courier New'" id="Label1" class="form-label">Ventas:&nbsp;&nbsp;</label></b>
                                <label id="textVentas" style="font-family: 'Courier New'" runat="server" class="form-label"></label>

                            </li>
                            <li class="list-group-item">
                                <b>
                                    <label id="Label2" style="font-family: 'Courier New'" class="form-label">Comisión:</label></b>
                                <label id="textComision" style="font-family: 'Courier New'" runat="server" class="form-label"></label>

                            </li>
                            <li class="list-group-item">

                                <b>
                                    <label id="Label3" style="font-family: 'Courier New'" class="form-label">Premios:&nbsp</label></b>
                                <label id="textPremios" style="font-family: 'Courier New'" runat="server" class="form-label"></label>

                            </li>
                            <li class="list-group-item">

                                <b>
                                    <label id="Labe14" style="font-family: 'Courier New'" class="form-label">Free:&nbsp;&nbsp;&nbsp;&nbsp</label></b>
                                <label id="textFree" style="font-family: 'Courier New'" runat="server" class="form-label"></label>

                            </li>
                        </ul>
                        <div class="card-footer">
                            <b>
                                <label id="Label4" style="font-family: 'Courier New'" class="form-label">Total:&nbsp;&nbsp;&nbsp</label></b>
                            <label id="textTotal" style="font-family: 'Courier New'" runat="server" class="form-label"></label>
                        </div>
                    </div>
                </div>

                <br />

                <div class="col-12 col-md-5">
                    <div class="card" style="width: 18rem;">
                        <div class="card-header">
                            <b>
                                <label for="inputDateBalanceLabel" class="form-label">Balance por Fecha</label></b>
                        </div>
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item">
                                <b>
                                    <label id="Label5" style="font-family: 'Courier New'" class="form-label">Ventas:&nbsp;&nbsp</label></b>
                                <label id="textDateVentas" style="font-family: 'Courier New'" runat="server" class="form-label"></label>
                            </li>
                            <li class="list-group-item">
                                <b>
                                    <label id="Label6" style="font-family: 'Courier New'" class="form-label">Comisión:</label></b>
                                <label id="textDateComision" style="font-family: 'Courier New'" runat="server" class="form-label"></label>
                            </li>
                            <li class="list-group-item">
                                <b>
                                    <label id="Label7" style="font-family: 'Courier New'" class="form-label">Premios:&nbsp</label></b>
                                <label id="textDatePremios" style="font-family: 'Courier New'" runat="server" class="form-label"></label>
                            </li>
                            <li class="list-group-item">
                                <b>
                                    <label id="Label8" style="font-family: 'Courier New'" class="form-label">Free:&nbsp;&nbsp;&nbsp;&nbsp</label></b>
                                <label id="textDateFree" style="font-family: 'Courier New'" runat="server" class="form-label"></label>
                            </li>
                        </ul>
                        <div class="card-footer">
                            <b>
                                <label id="Label8" style="font-family: 'Courier New'" class="form-label">Total:&nbsp;&nbsp;&nbsp</label></b>
                            <label id="textDateTotal" style="font-family: 'Courier New'" runat="server" class="form-label"></label>
                        </div>
                    </div>
                </div>


                <div class="col-12 col-md-5">
                    <div id="cardCaida" runat="server" class="card" style="width: 18rem;">
                        <div class="card-header">
                            <b>
                                <label for="inputDateBalanceLabelCaida" class="form-label">Caida</label></b>
                        </div>
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item">
                                <b>
                                    <label id="textCaida" style="font-family: 'Courier New'" runat="server" class="form-label"></label></li>

                        </ul>

                    </div>
                </div>

                <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
                </asp:ScriptManager>
            </div>
        </div>

        <div class="container" id="CuadreImprimir" runat="server" style="background-color: aqua; display: none;">
        </div>


    </form>

</body>



</html>


