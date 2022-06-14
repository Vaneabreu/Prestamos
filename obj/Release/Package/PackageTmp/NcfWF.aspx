<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NcfWF.aspx.cs" Inherits="SoftLoans.NcfWF" %>

<!DOCTYPE html>

<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Rutas de Cobrador</title>
    <!-- Bootstrap CSS -->
    <link href="/Content/bootstrap.min.css" rel="stylesheet" type="text/css">
    <script src="/Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>

    <!-- SweetAlert -->
    <script src="/Scripts/SweetAlert.min.js"></script>
    <link href="/Content/sweetalert/sweet-alert.css" rel="stylesheet" />


    <link href="/Content/estilos.css" rel="stylesheet" type="text/css">
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
            <div class="row g-3">
                <div class="col-md-2">
                    <label for="LbSecuecniaInicial" class="form-label">Secuencia Inicial</label>
                    <asp:TextBox ID="TbSecuenciaInicial" runat="server" Type="number" class="form-control" placeholder="0"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVSecuecniaInicial" runat="server"
                        ControlToValidate="TbSecuenciaInicial"
                        ErrorMessage="Campo obligatorio"
                        ForeColor="Red"
                        EnableClientScript="false">
                    </asp:RequiredFieldValidator>
                </div>
                <div class="col-md-2">
                    <label for="LbSecuecniaFinal" class="form-label">Secuencia Final</label>
                    <asp:TextBox ID="TbSecuenciaFinal" runat="server" Type="number" class="form-control" placeholder="0"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVSecuecniaFinal" runat="server"
                        ControlToValidate="TbSecuenciaInicial"
                        ErrorMessage="Campo obligatorio"
                        ForeColor="Red"
                        EnableClientScript="false">
                    </asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6">
                    <label for="inputLotery4" class="form-label">Prefijo de NCF</label><br />
                    <asp:DropDownList ID="DropDownPrefijoNCF" runat="server" CssClass="btn btn-secondary dropdown-toggle" Width="100%">
                    </asp:DropDownList>
                </div>
                <br />
                <div class="col-md-6 align-self-end">
                    <div class="col g-1">
                        <button id="BtnRecargar" onserverclick="BtnRecargar_ServerClick" runat="server" class="btn btn-primary" clientidmode="Static">
                            <b>
                                <img src="/Content/bootstrap-icons/icons/bootstrap-reboot.svg" alt="Bootstrap" width="22" height="22" /><i>
                                    Recargar </i></b>
                        </button>
                        <button type="button" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#exampleModal">
                            <b>
                                <img src="/Content/bootstrap-icons/icons/save2.svg" alt="Bootstrap" width="22" height="22" /><i>
                                    Actualizar </i></b>
                        </button>


                    </div>
                </div>
                <div class="container table-responsive">
                    <asp:GridView ID="GvNcf" runat="server" Width="100%"
                        CssClass="table table-responsive table-striped table-hover table-sm" AutoGenerateColumns="False"
                        DataKeyNames="NcfType"
                        EmptyDataText="No se encontraron datos entre los limites establecidos!"
                        AllowCustomPaging="True"
                        ForeColor="#333333"
                        GridLines="Horizontal">

                        <Columns>

                            <%--ItemStyle-CssClass="d-none d-lg-block" HeaderStyle-CssClass="d-none d-lg-block"--%>
                            <asp:BoundField DataField="NcfType" HeaderText="Prefijo" ReadOnly="True" SortExpression="Prefijo" />

                            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description">
                                <HeaderStyle Width="100px" HorizontalAlign="Center" CssClass="ocultar-div-sm"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" CssClass="ocultar-div-sm"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="CurrentSequence" HeaderText="S. Inicial" SortExpression="Secuencia Inicial" />
                            <asp:BoundField DataField="FinalSequence" HeaderText="S. Final" SortExpression="Secuencia Final" />
                            <asp:BoundField DataField="NcfNumber" HeaderText="NCF" SortExpression="NCF" />

                        </Columns>

                        <EditRowStyle BackColor="#2461BF" Width="100%" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#212529" Font-Bold="True" ForeColor="White"
                            HorizontalAlign="Center" Wrap="False" />
                        <%-- #0d6efd --%>
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" Wrap="False" />
                        <SelectedRowStyle CssClass="bg-danger text-info" Font-Bold="True" ForeColor="#333333" />

                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />

                    </asp:GridView>
                    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
                    </asp:ScriptManager>
                </div>

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
                                ¿Está seguro de continuar con el proceso de Actualización?
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                                <button id="BtnActualizar" type="button" class="btn btn-success" onserverclick="BtnActualizar_ServerClick" runat="server">Continuar</button>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Modal -->
                <div class="modal fade" id="exampleModal1" tabindex="-1" aria-labelledby="exampleModalLabel1" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLabel1">Modal title</h5>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                ...
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                                <button type="button" class="btn btn-primary">Save changes</button>
                            </div>
                        </div>
                    </div>
                </div>

            </div>


        </div>


        <div>
        </div>
    </form>
</body>
</html>
