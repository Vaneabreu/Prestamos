<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrestamosWF.aspx.cs" Inherits="SoftLoans.PrestamosWF" %>

<!DOCTYPE html>

<html lang="en">

<head>
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
        <div id="DivPrestamoB" runat="server" class="container">
            <div class="row g-3">
                <div class="col-md-6">
                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Id Préstamo"
                        Visible="false"></asp:TextBox>
                    <label for="inputIdPrestamo4" class="form-label">Id Préstamo</label>
                    <asp:TextBox ID="TbID" runat="server" type="number" class="form-control" placeholder="Id Préstamo"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="inputIdCliente4" class="form-label">Id Cliente</label>
                    <asp:TextBox ID="TbCustomerID" runat="server" type="number" class="form-control" placeholder="Id Cliente"></asp:TextBox>

                </div>

                <div class="col-md-6">
                    <label for="inputIdCliente4" class="form-label">Nombre Cliente</label>
                    <asp:TextBox ID="TbCustumerName" runat="server" class="form-control" placeholder="Nombre Cliente"></asp:TextBox>
                </div>


            </div>


            <br />
            <div class="col-md-6">
                <div class="col g-1">
                    <button id="BtnBuscar" onserverclick="BtnBuscar_Click" runat="server" class="btn btn-primary" clientidmode="Static">
                        <b>
                            <img src="/Content/bootstrap-icons/icons/search.svg" alt="Bootstrap" width="22" height="22" /><i>
                                    Buscar </i></b>
                    </button>
                    <button id="BtnNuevo" onserverclick="BtnNuevo_Click" runat="server" class="btn btn-primary" clientidmode="Static">
                        <b>
                            <img src="/Content/bootstrap-icons/icons/file-earmark-plus.svg" alt="Bootstrap" width="22" height="22" /><i>
                                    Nuevo </i></b>
                    </button>
                    <button onserverclick="BtnImprimir_Click" runat="server" class="btn btn-primary">
                        <b>
                            <img src="/Content/bootstrap-icons/icons/file-earmark-plus.svg" alt="Bootstrap" width="22"
                                height="22" /><i> Imprimir </i></b>
                    </button>

                </div>


            </div>


        </div>
        <br />



        <div id="DivGvPrestamoB" runat="server" class="container table-responsive">
            <asp:GridView ID="GvPrestamos" runat="server" Width="100%"
                CssClass="table table-responsive table-striped table-hover table-sm" AutoGenerateColumns="False"
                DataKeyNames="ID"
                EmptyDataText="No se encontraron datos entre los limites establecidos!"
                AllowCustomPaging="True"
                OnSelectedIndexChanged="GvPrestamos_SelectedIndexChanged"
                OnRowDeleting="GvPrestamos_RowDeleting" ForeColor="#333333"
                OnRowDataBound="GvPrestamos_RowDataBound"
                GridLines="Horizontal">

                <Columns>

                    <%--ItemStyle-CssClass="d-none d-lg-block" HeaderStyle-CssClass="d-none d-lg-block"--%>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID">
                        <HeaderStyle Width="100px" HorizontalAlign="Center" CssClass="ocultar-div-sm"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" CssClass="ocultar-div-sm"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Capital" HeaderText="Capital" SortExpression="Capital">
                        <HeaderStyle Width="180px" CssClass="ocultar-div-md"></HeaderStyle>
                        <ItemStyle CssClass="ocultar-div-md"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="CustomerName" HeaderText="Cliente" SortExpression="Cliente" />


                    <asp:BoundField DataField="Date" HeaderText="Fecha" SortExpression="Fecha">
                        <HeaderStyle CssClass="ocultar-div-lg"></HeaderStyle>
                        <ItemStyle CssClass="ocultar-div-lg"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="InterestAmount" HeaderText="Interes" SortExpression="Interes">
                        <HeaderStyle CssClass="ocultar-div-lg"></HeaderStyle>
                        <ItemStyle CssClass="ocultar-div-lg"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="TotalAmount" HeaderText="Total" SortExpression="Total"
                        HeaderStyle-Width="100px" ItemStyle-Width="100px">
                        <HeaderStyle Width="100px" CssClass="ocultar-div-xl"></HeaderStyle>
                        <ItemStyle Width="100px" CssClass="ocultar-div-xl"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Status" HeaderText="Estado" SortExpression="Estado" />

                    <asp:ButtonField ImageUrl="/Content/bootstrap-icons/icons/card-list.svg" CommandName="Select" HeaderText="Det." ButtonType="Image">
                        <ControlStyle CssClass="btn btn-warning"></ControlStyle>
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle CssClass="btn-warning" HorizontalAlign="Center" Width="50px" />
                    </asp:ButtonField>


                    <asp:ButtonField ImageUrl="/Content/bootstrap-icons/icons/x-circle.svg" CommandName="Delete" HeaderText="Canc." ButtonType="Image">
                        <ControlStyle CssClass="btn btn-danger"></ControlStyle>
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle CssClass="btn-danger" HorizontalAlign="Center" Width="50px"></ItemStyle>
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
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
            </asp:ScriptManager>
        </div>


    </form>

</body>

</html>
