<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuWF.aspx.cs" Inherits="SoftLoans.MenuWF" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html lang="en">

<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>SoftLoans</title>

    <!-- Bootstrap CSS -->
    <link href="/Content/bootstrap.min.css" rel="stylesheet" type="text/css">
    <script src="/Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>

    <!-- SweetAlert -->
    <script src="/Scripts/SweetAlert.min.js"></script>
    <link href="/Content/sweetalert/sweet-alert.css" rel="stylesheet" />



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

        <div id="toast" runat="server" class="toast" role="alert" aria-live="assertive" aria-atomic="true">
            <div class="toast-header">
                <img src="..." class="rounded me-2" alt="...">
                <strong class="me-auto">Bootstrap</strong>
                <small class="text-muted">11 mins ago</small>
                <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
            </div>
            <div class="toast-body">
                Hello, world! This is a toast message.
            </div>
        </div>


        <div id="grafico" class="col-auto text-center d-block d-sm-none">
            <asp:Chart runat="server" ID="ChartVxUM" BorderlineDashStyle="Dash" PaletteCustomColors="Red; Green">
                <Series>
                    <asp:Series Name="SeriesVxUM"></asp:Series>
                </Series>
                <Titles>
                    <asp:Title Text="Flujo del dia" Font="Microsoft Sans Serif, 15pt"></asp:Title>
                </Titles>
                <Legends>
                    <asp:Legend Title="Flujo" Alignment="Center" Docking="Bottom"
                        IsTextAutoFit="False"
                        LegendStyle="Row">
                    </asp:Legend>
                </Legends>
                <ChartAreas>
                    <asp:ChartArea Name="ChartAreaVxUM"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <asp:Chart runat="server" ID="ChartVxMM" BorderlineDashStyle="Dash" Width="360px">
                <Series>
                    <asp:Series Name="SeriesVxMSM"></asp:Series>
                    <asp:Series Name="SeriesVxMEM"></asp:Series>

                </Series>
                <Legends>
                    <asp:Legend Name="Legend1M" Title="Flujo de dinero">
                    </asp:Legend>
                </Legends>

                <Titles>
                    <asp:Title Name="TitleVxMM" Text="Flujo del 2021" Font="Microsoft Sans Serif, 15pt"></asp:Title>
                </Titles>
                <ChartAreas>
                    <asp:ChartArea Name="ChartAreaVxMM">
                        <AxisX2 MaximumAutoSize="100">
                        </AxisX2>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>


        </div>
        <div id="graficoW" class="col-auto text-center d-none d-sm-block">
            <asp:Chart runat="server" ID="ChartVxUW" BorderlineDashStyle="Dash" PaletteCustomColors="Red; Green" Width="400px" Height="400px">
                <Series>
                    <asp:Series Name="SeriesVxUW"></asp:Series>
                </Series>
                <Titles>
                    <asp:Title Text="Flujo del dia" Font="Microsoft Sans Serif, 15pt"></asp:Title>
                </Titles>
                <Legends>
                    <asp:Legend Title="Flujo" Alignment="Center" Docking="Bottom"
                        IsTextAutoFit="False"
                        LegendStyle="Row">
                    </asp:Legend>
                </Legends>
                <ChartAreas>
                    <asp:ChartArea Name="ChartAreaVxUW"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>

            <asp:Chart runat="server" ID="ChartVxMW" BorderlineDashStyle="Dash" Width="600px" Height="400px">
                <Series>
                    <asp:Series Name="SeriesVxMSW"></asp:Series>
                    <asp:Series Name="SeriesVxMEW"></asp:Series>

                </Series>
                <Legends>
                    <asp:Legend Name="Legend1W" Title="Flujo de dinero">
                    </asp:Legend>
                </Legends>

                <Titles>
                    <asp:Title Name="TitleVxMW" Text="Flujo del 2021" Font="Microsoft Sans Serif, 15pt"></asp:Title>
                </Titles>
                <ChartAreas>
                    <asp:ChartArea Name="ChartAreaVxMW">
                        <AxisX2 MaximumAutoSize="100">
                        </AxisX2>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>


        </div>


    </form>



</body>

</html>
