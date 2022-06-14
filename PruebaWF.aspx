<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PruebaWF.aspx.cs" Inherits="SoftLoans.PruebaWF" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-wEmeIV1mKuiNpC+IOBjI7aAzPcEZeedi5yW5f2yOq55WWLwNGmvvx4Um1vskeMj0" crossorigin="anonymous"/>

    <title></title>
</head>
<body>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-p34f1UUtsS3wqzfto5wAAmdvj+osOnFyQFpp4Ua3gs/ZVWx6oOypYoCJhGGScy+8" crossorigin="anonymous"></script>
        
    <form id="form1" runat="server">
        <div style="margin: 40px">
            <asp:Table ID="Table1" runat="server" Width="100%">

                <asp:TableRow runat="server" HorizontalAlign="Center">

                    <asp:TableCell runat="server" RowSpan="10" BackColor="Gray">
                        <div class="text-center"><a>Lista de Botones para la loterias</a>            
                            </div>
                    </asp:TableCell>

                    <asp:TableCell runat="server" RowSpan="3" BackColor="LightBlue">
                        <div class="text-center"><a>Datos de la banca, punto de venta, tres filas</a>            
                            </div>                         
                        <div class="text-center"><a>Punto de venta: Punto 1</a>                                     
                            </div>                            
                        <div class="text-center"><a>Limite disponible</a>   
                            </div>
                    </asp:TableCell>

                    <asp:TableCell runat="server" BackColor="Red">
                        <div class="text-center"><a>Reporte Detalle Numero</a>            
                            </div>
                    </asp:TableCell>
                    <asp:TableCell runat="server" BackColor="Red">
                        <div class="text-center"><a>Reporte Diario</a>            
                            </div>
                    </asp:TableCell>
                    <asp:TableCell runat="server" BackColor="Black" RowSpan="2" ColumnSpan="2">
                       
                    
                        <div class="text-center"><a style="color:white">Datos informativos</a>            
                            </div>
                    
                        <div class="text-center"><a style="color:white">Fecha: </a>            
                            </div>
                    
                        <div class="text-center"><a style="color:white">Usuario: </a>               
                            </div>
                    </asp:TableCell>

                </asp:TableRow>
                <asp:TableRow runat="server" HorizontalAlign="Center">
                    <asp:TableCell runat="server" BackColor="Black" RowSpan="2">
                        <div class="text-center"><a style="color:white">Total Vendido, dos filas</a>            
                            </div>
                         
                        <div class="text-center"><a style="color:white">RD$    47</a>            
                            </div>
                         <div class="text-center"><a style="color:white">RD$    47 %</a>            
                            </div>
                    </asp:TableCell>

                    <asp:TableCell runat="server" BackColor="Black" RowSpan="2">
                        <div class="text-center"><a style="color:white">Mondo Disponible</a>            
                            </div>
                        
                        <div class="text-center"><a style="color:white">RD$  4700</a>            
                            </div>
                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow runat="server" HorizontalAlign="Center">

                    <asp:TableCell runat="server" BackColor="Red">
                        <div class="text-center"><a>Imprimir Resporte Diario</a>            
                            </div>
                    </asp:TableCell>
                    <asp:TableCell runat="server" BackColor="Red">
                        <div class="text-center"><a>Numeros Ganadores</a>            
                            </div>
                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow runat="server" HorizontalAlign="Center">

                    <asp:TableCell runat="server" BackColor="DarkOrange" ColumnSpan="2">
                        <div class="text-center"><a style="color:white">33 -</a> <a>Real</a>           
                            </div>
                        
                        <div class="text-center"><a style="color:white">     Tarde</a>           
                            </div>
                    </asp:TableCell>
                    <asp:TableCell runat="server" BackColor="DarkOrange" ColumnSpan="4">
                        <asp:Table ID="Table2" runat="server" Width="100%">
                            <asp:TableRow runat="server" HorizontalAlign="Left">

                                <asp:TableCell runat="server">
                                    <asp:CheckBox ID="CheckBox3" runat="server" Checked="true" />Tarde                              
                            <asp:CheckBox ID="CheckBox4" runat="server" />Noche 
                                </asp:TableCell>
                                <asp:TableCell runat="server" HorizontalAlign="Center">
                                     <div>
                                     <a>Cierre del Sorteo</a></div>
                                </asp:TableCell>
                                <asp:TableCell runat="server" HorizontalAlign="Right">
                                     <div>
                                     <a>Tanda Cerrada</a></div>
                                </asp:TableCell>

                            </asp:TableRow>


                        </asp:Table>
                    </asp:TableCell>

                </asp:TableRow>
                <asp:TableRow runat="server" HorizontalAlign="Left">

                    <asp:TableCell runat="server" BackColor="DarkOrange" ColumnSpan="5">

                        <div>
                            <asp:Table ID="Table3" runat="server">
                                <asp:TableRow runat="server" HorizontalAlign="Left">

                                    <asp:TableCell runat="server" Width="500">
                                        <div>
                                            <a>Numero:</a>
                                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                            <a>Monto:</a>
                                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                        </div>
                                        <br />
                                        <div>
                                            <a>Ticket:</a>
                                        </div>
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" HorizontalAlign="Left">
                                        <div>
                                            <asp:Button ID="Button2" runat="server" Text="Agregar" OnClick="BtnAgregar_Click" />
                                            <asp:Button ID="Button3" runat="server" Text="Limpiar" />
                                        </div>
                                        <div>
                                            <asp:Button ID="Button4" runat="server" Text="Borrar Jugadas" />
                                        </div>
                                    </asp:TableCell>

                                </asp:TableRow>


                            </asp:Table>
                        </div>
                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow runat="server" HorizontalAlign="Left">

                    <asp:TableCell runat="server" BackColor="White" ColumnSpan="5">


                        <asp:Panel ID="Panel1" runat="server" Width="100%" BackColor="White" HorizontalAlign="Right">
                            <div>
                                <asp:GridView ID="GridView1" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                                    runat="server" AutoGenerateColumns="false">                                    <Columns>
                                        <asp:BoundField DataField="No" HeaderText="Id" ItemStyle-Width="30" />
                                        <asp:BoundField DataField="TipoJugada" HeaderText="Tipo de Jugada" ItemStyle-Width="150" />
                                        <asp:BoundField DataField="Numeros" HeaderText="Numeros" ItemStyle-Width="150" />                                        
                                        <asp:BoundField DataField="Monto" HeaderText="Monto" ItemStyle-Width="150"/>
                                    </Columns>
                                </asp:GridView>
                            </div>


                        </asp:Panel>
                    </asp:TableCell>



                </asp:TableRow>


            </asp:Table>


        </div>

    </form>
</body>
</html>
