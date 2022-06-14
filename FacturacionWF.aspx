<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FacturacionWF.aspx.cs"
    Inherits="SoftLoans.FacturacionWF" %>

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

    <!-- Print -->

    <link href="/Content/print.min.css" rel="stylesheet" type="text/css">
    <%--<script src="/Scripts/print.min.js"></script>--%>
    <script src="https://unpkg.com/print-js@1.0.60/dist/print.js"></script>

    

    <script type = "text/javascript">
        function DisableButton() {
            document.getElementById("<%=BtnJugar.ClientID %>").disabled = true;
        }
        window.onbeforeunload = DisableButton;
    </script>


    <script>
        function BtPrint(prn) {
            var S = "#Intent;scheme=rawbt;";
            var P = "package=ru.a402d.rawbtprinter;end;";
            var textEncoded = encodeURI(prn);
            window.location.href = "intent:" + textEncoded + S + P;
        }

        function selectAllText(senderID)
        {
            document.getElementById(senderID).focus();
            document.getElementById(senderID).select();
        }

    </script>
   

    <%-- Controlar el Evento KeyPress --%>
    <script>

        function disableEnterKey(e) {
            var key;
            if (window.event) {
                key = window.event.keyCode; //IE
                var tbP = document.getElementById("TbMonto");
                if (e.keyCode == 13) {
                    tbP.focus();
                }
                
                // $("#TbMonto").trigger("click");
            }
            else
                key = e.which; //firefox     

            return (key != 13);
        }
      
    </script>
    <style>
        .radius {
            border-radius: 40px;
        }
    </style>


</head>
<body style="background-color: #0074d9">
   

    <script src="/Scripts/app.js"></script>
    <script src="/Scripts/bootstrap.bundle.min.js" type="text/javascript"></script>
    <table style="width: 100%"></table>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark bg-primary " style="height:10% !important">
            <div class="container-fluid">
                <a></a>
                <button runat="server" class="navbar-brand btn-primary" onserverclick="BtnSeleccionLoteria_Click"  >
                    <b>
                        <img src="imagen/Icononegro.png" alt="Bootstrap" width="28" height="28" />
                        <i>Soft Banking</i>
                    </b>
                </button>

                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent"
                    aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>

                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent" >
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link active">
                                <img src="/Content/bootstrap-icons/icons/gem.svg" alt="Bootstrap" width="22" height="22" />
                                <asp:Button ID="BtnLoteria" runat="server" Text="Loteria" BorderWidth="0" BackColor="Transparent"
                                    ForeColor="White"
                                    OnClick="BtnSeleccionLoteria_Click" />
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active">
                                <img src="/Content/bootstrap-icons/icons/inbox-fill.svg" alt="Bootstrap" width="22"
                                    height="22" />
                                <asp:Button ID="BtnCuadre" runat="server" Text="Cuadre" BorderWidth="0" BackColor="Transparent"
                                    ForeColor="White"
                                    OnClick="BtnCuadre_Click" />
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active">
                                <img src="/Content/bootstrap-icons/icons/stickies.svg" alt="Bootstrap" width="22"
                                    height="22" />
                                <asp:Button ID="BtnTickets" runat="server" Text="Tickets" BorderWidth="0" BackColor="Transparent"
                                    ForeColor="White"
                                    OnClick="BtnTickets_Click" />
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active">
                                <img src="/Content/bootstrap-icons/icons/trophy.svg" alt="Bootstrap" width="22" height="22" />
                                <asp:Button ID="BtnTicketsWin" runat="server" Text="Tickets Ganadores" BorderWidth="0"
                                    BackColor="Transparent" ForeColor="White"
                                    OnClick="BtnTicketsWin_Click" />
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active">
                                <img src="/Content/bootstrap-icons/icons/suit-diamond.svg" alt="Bootstrap" width="22"
                                    height="22" />
                                <asp:Button ID="BtnNumerosGanadores" runat="server" Text="Números Ganadores" BorderWidth="0"
                                    BackColor="Transparent" ForeColor="White"
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

        <div class="container">
            <div class="col">

                <div class="row p-2 " style="border-bottom-left-radius: 50px; border-bottom-right-radius: 50px; background-color: white">
                    <a>
                        <asp:Label ID="Label1" runat="server" Text="ID Lot:" CssClass="ne"></asp:Label>
                        <asp:Label ID="LbLoteriaID" runat="server" Text="000000"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text="Loteria:"></asp:Label>
                        <asp:Label ID="LbLoteriaNombre" runat="server" Text="La mejor"></asp:Label>
                        <asp:Label ID="LbTardeNoche" runat="server" Visible="false"></asp:Label>
                    </a>
                    <a>
                        <asp:Label ID="Label4" runat="server" Text="Fecha:"></asp:Label>
                        <asp:Label ID="LbHora" runat="server" Text="000000"></asp:Label>
                        <asp:Label ID="LbSubTotal" runat="server" Text="S: $0" CssClass="text-danger" Font-Bold="true"></asp:Label>
                        <asp:Label ID="LbFree" runat="server" Text="F: $0" CssClass="text-danger" Font-Bold="true"></asp:Label>
                        <asp:Label ID="LbTotal" runat="server" Text="Total: $0" CssClass="text-danger" Font-Bold="true"></asp:Label>
                    </a>



                    <div class="row">
                        <div class="col">
                            <a></a>
                        </div>
                        <div class="col w-100">
                            <div class="row justify-content-end">
                            </div>

                        </div>


                    </div>

                </div>
                <%-- <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>--%>

                <div class="row p-2">
                    <div class="col">
                        <asp:Button runat="server" ID="BtnAutoQN" Text="Auto QN" CssClass="bnt btn-info radius"
                            Width="100%" OnClick="BtnAutoQN_Click" />
                    </div>
                    <div class="col">
                        <asp:Button runat="server" ID="BtbAutoPL" Text="Auto PL" CssClass="bnt  btn-light radius"
                            Width="100%" OnClick="BtnAutoPL_Click" />
                    </div>
                    <div class="col">
                        <asp:Button runat="server" ID="BtnAutoTP" Text="Auto TP" CssClass="bnt btn-secondary radius"
                            Width="100%" OnClick="BtnAutoTP_Click" />
                    </div>

                </div>


                <div class="row p-1">

                    <div class="col">
                        <asp:ScriptManager runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="TbNumero" runat="server" class="form-control" type="number" placeholder="Numeros" AutoCompleteType="Disabled" onFocus="selectAllText(this.id)"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="REVNumero"
                                    ControlToValidate="TbNumero" runat="server"
                                    ErrorMessage="Solo números"
                                    ValidationExpression="\d+" ForeColor="Red"
                                    EnableClientScript="false">
                                </asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RFVNumero" runat="server"
                                    ControlToValidate="TbNumero"
                                    ErrorMessage="Campo obligatorio"
                                    ForeColor="Red"
                                    EnableClientScript="true">
                                </asp:RequiredFieldValidator>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">

                            <ContentTemplate>
                                <asp:TextBox ID="TbMonto" runat="server" class="form-control" type="number" placeholder="Monto" AutoCompleteType="Disabled"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="REVMonto"
                                    ControlToValidate="TbMonto" runat="server"
                                    ErrorMessage="Solo números"
                                    ValidationExpression="\d+" ForeColor="Red"
                                    EnableClientScript="false">
                                </asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RFVMonto" runat="server"
                                    ControlToValidate="TbMonto"
                                    ErrorMessage="Campo obligatorio"
                                    ForeColor="Red"
                                    EnableClientScript="false">
                                </asp:RequiredFieldValidator>

                            </ContentTemplate>

                        </asp:UpdatePanel>


                    </div>
                    <div class="col">
                        <asp:Button runat="server" ID="BtnAgregar" Text="Agregar" CssClass="bnt btn-warning radius"
                            Width="100%" Height="40px" OnClick="BtnAgregar_Click" ClientIDMode="Static" />
                    </div>
                </div>

                <div class="row p-1" style="border-top-left-radius: 50px; border-top-right-radius: 50px; background-color: white; text-align-last: center">

                    <div class="col">
                        <asp:Button runat="server" OnClick="BtnCombinar_Click" ID="BtnCombinar" Text="Combinar"
                            CssClass="bnt btn-primary radius"
                            Width="100%" Height="40px" />
                    </div>
                    <div class="col">
                        <asp:Button runat="server" ID="BtnSLM" Text="Loterias Multi." CssClass="bnt btn-dark radius"
                            Width="100%" Height="40px" OnClientClick="return false;" data-bs-toggle="offcanvas" data-bs-target="#offcanvasScrolling" aria-controls="offcanvasScrolling" />
                        <div class="offcanvas offcanvas-start" data-bs-scroll="true" data-bs-backdrop="false"
                            tabindex="-1" id="offcanvasScrolling" aria-labelledby="offcanvasScrollingLabel">
                            <div class="offcanvas-header">
                                <h5 class="offcanvas-title" id="offcanvasScrollingLabel">Seleccion de Multiple Loterias
                                </h5>
                                <button runat="server" type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas"
                                    aria-label="Close" onserverclick="CBCheckedChanged">
                                </button>
                            </div>
                            <div class="offcanvas-body">

                                <asp:CheckBox ID="Cb1" runat="server" Text="Nacional"
                                    CssClass="btn btn-dark w-100" OnCheckedChanged="CBCheckedChanged" />
                                <asp:CheckBox ID="Cb4" runat="server" Text="Leidsa"
                                    CssClass="btn btn-secondary w-100" OnCheckedChanged="CBCheckedChanged" />
                                <asp:CheckBox ID="Cb5" runat="server" Text="Super Pale Nacional-Leidsa"
                                    CssClass="btn btn-dark w-100" OnCheckedChanged="CBCheckedChanged" />
                                <asp:CheckBox ID="Cb12" runat="server" Text="Loteka" CssClass="btn btn-secondary w-100"
                                    OnCheckedChanged="CBCheckedChanged" />
                                <asp:CheckBox ID="Cb15" runat="server" Text="Gana mas" CssClass="btn btn-dark w-100"
                                    OnCheckedChanged="CBCheckedChanged" />
                                <asp:CheckBox ID="Cb32" runat="server" Text="Super Pale Real-Gana mas" CssClass="btn btn-secondary w-100"
                                    OnCheckedChanged="CBCheckedChanged" />
                                <asp:CheckBox ID="Cb33" runat="server" Text="Real" CssClass="btn btn-dark w-100"
                                    OnCheckedChanged="CBCheckedChanged" />
                                <asp:CheckBox ID="Cb37" runat="server" Text="NewYork Tarde" CssClass="btn btn-secondary w-100"
                                    OnCheckedChanged="CBCheckedChanged" />
                                <asp:CheckBox ID="Cb38" runat="server" Text="NewYork Noche"
                                    CssClass="btn btn-dark w-100" OnCheckedChanged="CBCheckedChanged" />
                                <asp:CheckBox ID="Cb39" runat="server" Text="Florida Dia" CssClass="btn btn-secondary w-100"
                                    OnCheckedChanged="CBCheckedChanged" />
                                <asp:CheckBox ID="Cb40" runat="server" Text="Florida Noche" CssClass="btn btn-dark w-100"
                                    OnCheckedChanged="CBCheckedChanged" />
                                <asp:CheckBox ID="Cb41" runat="server" Text="La Primera" CssClass="btn btn-secondary w-100"
                                    OnCheckedChanged="CBCheckedChanged" />
                                <asp:CheckBox ID="Cb42" runat="server" Text="La Suerte" CssClass="btn btn-dark w-100"
                                    OnCheckedChanged="CBCheckedChanged" />
                                <asp:CheckBox ID="Cb43" runat="server" Text="Lotedom" CssClass="btn btn-secondary w-100"
                                    OnCheckedChanged="CBCheckedChanged" />
                                <asp:CheckBox ID="Cb44" runat="server" Text="Aguila Mañana" CssClass="btn btn-dark w-100"
                                    OnCheckedChanged="CBCheckedChanged" />
                                <asp:CheckBox ID="Cb45" runat="server" Text="Aguila Medio Dia" CssClass="btn btn-secondary w-100"
                                    OnCheckedChanged="CBCheckedChanged" />
                                <asp:CheckBox ID="Cb46" runat="server" Text="Aguila Tarde" CssClass="btn btn-dark w-100"
                                    OnCheckedChanged="CBCheckedChanged" />
                                <asp:CheckBox ID="Cb47" runat="server" Text="Aguila Noche" CssClass="btn btn-secondary w-100"
                                    OnCheckedChanged="CBCheckedChanged" />
                                <asp:CheckBox ID="Cb48" runat="server" Text="King Lottery Tarde" CssClass="btn btn-dark w-100"
                                    OnCheckedChanged="CBCheckedChanged" />
                                <asp:CheckBox ID="Cb49" runat="server" Text="King Lottery Noche" CssClass="btn btn-secondary w-100"
                                    OnCheckedChanged="CBCheckedChanged" />
                            </div>
                        </div>

                    </div>

                </div>

                <div class="row p-2" style="background-color: white">
                    <div id="CuerpoTicket" style="overflow: scroll; overflow-y: scroll; height: calc(100vh - 380px);">
                        <asp:GridView ID="GvTicket" runat="server" Width="100%"
                            CssClass="table table-responsive table-striped table-hover table-sm" AutoGenerateColumns="False"
                            DataKeyNames="Tipo,Numeros,Monto"
                            EmptyDataText="No se encontraron datos entre los limites establecidos!"
                            AllowCustomPaging="True" ForeColor="#333333"
                            GridLines="Horizontal" OnRowDeleting="GvTicket_RowDeleting"
                            OnRowDeleted="GvTicket_RowDeleted"
                            OnSelectedIndexChanged="GvTicket_SelectedIndexChanged">

                            <Columns>

                                <%--ItemStyle-CssClass="d-none d-lg-block" HeaderStyle-CssClass="d-none d-lg-block"--%>
                                <asp:BoundField DataField="Tipo" HeaderText="Tipo" ReadOnly="True" SortExpression="Tipo" />
                                <asp:BoundField DataField="Numeros" HeaderText="Numeros" SortExpression="Numeros" />
                                <asp:BoundField DataField="Monto" HeaderText="Monto" SortExpression="Monto" />

                                <asp:ButtonField Text="Eliminar" CommandName="select" HeaderText="Eliminar" ButtonType="Button">
                                    <ControlStyle CssClass="btn btn-danger"></ControlStyle>
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle CssClass="btn-danger" HorizontalAlign="Right" Width="100px"></ItemStyle>
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
                        <%-- <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
                        </asp:ScriptManager>--%>
                    </div>
                </div>

                <div id="PieP" class="row p-2" style="border-bottom-left-radius: 50px; border-bottom-right-radius: 50px; background-color: white;">

                    <div class="col">
                        <asp:Button runat="server" ID="BtnJugar" Text="Jugar" CssClass="btn btn-success radius"
                            OnClick="BtnJugar_Click"
                            Width="100%" Height="40px" />

                        <%--  OnClientClick="LimpiarPrueba()"  --%>
                    </div>

                    <div class="col">
                        <asp:Button runat="server" ID="BtbBorrar" OnClick="BtnBorrar_Click" Text="Borrar Todo"
                            CssClass="bnt btn-danger radius"
                            Width="100%" Height="40px" />
                    </div>

                </div>

             

                <div class="container printClose TranspColor" id="TicketImprimirC" runat="server" style="background-color: white; display: none; width: 300px; text-align-last: center; align-content: center;">
                    <div class="row m-1" id="TicketImprimir" runat="server" >
                    </div>
                    <br />
                    <div class="container">
                        <div class="row justify-content-center" >
                            <div class="col-6">
                                <img runat="server" src="" id="imgQRCode" />
                            </div>
                        </div>
                    </div>

                    <br />
                    <div>
                    </div>





                </div>


            </div>
        </div>

    </form>


</body>
</html>
