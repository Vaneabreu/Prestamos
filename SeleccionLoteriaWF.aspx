  <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionLoteriaWF.aspx.cs"
    Inherits="SoftLoans.SeleccionLoteriaWF" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Facturacion</title>
    <!-- Bootstrap CSS -->
    <link href="/Content/bootstrap.min.css" rel="stylesheet" type="text/css">

    <!-- SweetAlert -->
    <script src="/Scripts/SweetAlert.min.js"></script>
    <link href="/Content/sweetalert/sweet-alert.css" rel="stylesheet" />


    <link href="/Content/estilos.css" rel="stylesheet" type="text/css">
</head>
<body>
    <script src="/Scripts/app.js"></script>
    <script src="/Scripts/bootstrap.bundle.min.js" type="text/javascript"></script>

    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark bg-primary" style="height:10% !important">
            <div class="container-fluid">
                <a></a>
                <button runat="server" class="navbar-brand btn-primary" onserverclick="BtnLoterias_Click">
                    <b>
                        <%--<img src="/Content/bootstrap-icons/icons/gem.svg" alt="Bootstrap" width="22" height="22" />--%>
                         <img src="imagen/Icononegro.png" alt="Bootstrap" width="28" height="28" />
                        <i>Soft Banking </i>
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


        <br />

        <div class="container">

            <div id="ListImg" class="container-img justify-content-center ">
                <div runat="server" id="Div44" class="m-2">
                    <button runat="server" id="Btn44" title="44" name="Aguila Mañana" class="btn-loteria"
                        onserverclick="BtnFacturacion_Click">
                        <b>
                            <img src="imagen/Aguila_Mañana.jpg" class="img-thumbnail img-loteria" />

                        </b>

                    </button>
                </div>

                <div runat="server" id="Div41" class="m-2">
                    <button runat="server" id="Btn41" name="La Primera" class="btn-loteria" onserverclick="BtnFacturacion_Click">
                        <b>
                            <img src="imagen/La_Primera.jpg" class="img-thumbnail img-loteria" />

                        </b>

                    </button>
                </div>
                <div runat="server" id="Div42" class="m-2">
                    <button runat="server" id="Btn42" name="La Suerte" class="btn-loteria" onserverclick="BtnFacturacion_Click">
                        <b>
                            <img src="imagen/La_Suerte.jpg" class="img-thumbnail img-loteria" />

                        </b>

                    </button>
                </div>

                <div runat="server" id="Div48" class="m-2">
                    <button runat="server" id="Btn48" name="King Lottery Tarde" class="btn-loteria" onserverclick="BtnFacturacion_Click">
                        <b>
                            <img src="imagen/King_Lottery_Tarde.jpg" class="img-thumbnail img-loteria" />

                        </b>

                    </button>
                </div>

                <div runat="server" id="Div45" class="m-2">
                    <button runat="server" id="Btn45" name="Aguila Medio Dia" class="btn-loteria" onserverclick="BtnFacturacion_Click">
                        <b>
                            <img src="imagen/Aguila_Medio_Dia.jpg" class="img-thumbnail img-loteria" />

                        </b>

                    </button>
                </div>
                <div runat="server" id="Div32" class="m-2">
                    <button runat="server" id="Btn32" name="Real" class="btn-loteria" onserverclick="BtnFacturacion_Click">
                        <b>
                            <img src="imagen/SP_Real-Ganamas.jpg" class="img-thumbnail img-loteria" />

                        </b>

                    </button>
                </div>
                <div runat="server" id="Div33" class="m-2">
                    <button runat="server" id="Btn33" name="Real" class="btn-loteria" onserverclick="BtnFacturacion_Click">
                        <b>
                            <img src="imagen/Real.jpg" class="img-thumbnail img-loteria" />

                        </b>

                    </button>
                </div>
                <div runat="server" id="Div39" class="m-2">
                    <button runat="server" id="Btn39" name="Florida Dia" class="btn-loteria" onserverclick="BtnFacturacion_Click">
                        <b>
                            <img src="imagen/Florida_Dia.jpg" class="img-thumbnail img-loteria" />

                        </b>
                    </button>
                </div>
                <div runat="server" id="Div37" class="m-2">
                    <button runat="server" id="Btn37" name="NewYork Tarde" class="btn-loteria" onserverclick="BtnFacturacion_Click">
                        <b>
                            <img src="imagen/New_York_Tarde.jpg" class="img-thumbnail img-loteria" />

                        </b>

                    </button>
                </div>

                <div runat="server" id="Div43" class="m-2">
                    <button runat="server" id="Btn43" name="Lotedom" class="btn-loteria" onserverclick="BtnFacturacion_Click">
                        <b>
                            <img src="imagen/Lotedom.jpg" class="img-thumbnail img-loteria" />

                        </b>

                    </button>
                </div>

                <div runat="server" id="Div15" class="m-2">
                    <button runat="server" id="Btn15" name="Gana mas" class="btn-loteria" onserverclick="BtnFacturacion_Click">
                        <b>
                            <img src="imagen/Ganamas.jpg" class="img-thumbnail img-loteria" />

                        </b>

                    </button>
                </div>
                <div runat="server" id="Div46" class="m-2">
                    <button runat="server" id="Btn46" name="Aguila Tarde" class="btn-loteria" onserverclick="BtnFacturacion_Click">
                        <b>
                            <img src="imagen/Aguila_Tarde.jpg" class="img-thumbnail img-loteria" />

                        </b>
                    </button>
                </div>
                <div runat="server" id="Div5" class="m-2">
                    <button runat="server" id="Btn5" name="Super Pale Nacional-Leidsa" class="btn-loteria"
                        onserverclick="BtnFacturacion_Click">
                        <b>
                            <img src="imagen/SP_Nacional-Leidsa.jpg" class="img-thumbnail img-loteria" />

                        </b>

                    </button>
                </div>

                <div runat="server" id="Div1" class="m-2">
                    <button runat="server" id="Btn1" name="Nacional" value="Nacional" class="btn-loteria"
                        onserverclick="BtnFacturacion_Click">
                        <b>
                            <img src="imagen/Nacional.jpg" class="img-thumbnail img-loteria" />

                        </b>

                    </button>

                </div>
                <div runat="server" id="Div49" class="m-2">
                    <button runat="server" id="Btn49" name="King Lottery Noche" class="btn-loteria" onserverclick="BtnFacturacion_Click">
                        <b>
                            <img src="imagen/King_Lottery_Noche.jpg" class="img-thumbnail img-loteria" />

                        </b>

                    </button>
                </div>
                <div runat="server" id="Div12" class="m-2">
                    <button runat="server" id="Btn12" name="Loteka" class="btn-loteria" onserverclick="BtnFacturacion_Click">
                        <b>
                            <img src="imagen/Loteka.jpg" class="img-thumbnail img-loteria" />

                        </b>

                    </button>
                </div>
                <div runat="server" id="Div4" class="m-2">
                    <button runat="server" id="Btn4" name="Leidsa" class="btn-loteria" onserverclick="BtnFacturacion_Click">
                        <b>
                            <img src="imagen/Leidsa.jpg" class="img-thumbnail img-loteria" />

                        </b>

                    </button>
                </div>
                <div runat="server" id="Div47" class="m-2">
                    <button runat="server" id="Btn47" name="Aguila Noche" class="btn-loteria" onserverclick="BtnFacturacion_Click">
                        <b>
                            <img src="imagen/Aguila_Noche.jpg" class="img-thumbnail img-loteria" />

                        </b>

                    </button>
                </div>
                <div runat="server" id="Div40" class="m-2">
                    <button runat="server" id="Btn40" name="Florida Noche" class="btn-loteria" onserverclick="BtnFacturacion_Click">
                        <b>
                            <img src="imagen/Florida_Noche.jpg" class="img-thumbnail img-loteria" />

                        </b>

                    </button>
                </div>
                <div runat="server" id="Div38" class="m-2">
                    <button runat="server" id="Btn38" name="NewYork Noche" class="btn-loteria" onserverclick="BtnFacturacion_Click">
                        <b>
                            <img src="imagen/New_York_Noche.jpg" class="img-thumbnail img-loteria" />

                        </b>

                    </button>
                </div>
            </div>

        </div>



    </form>
</body>
</html>

