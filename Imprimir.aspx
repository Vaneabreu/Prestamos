<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Imprimir.aspx.cs" Inherits="SoftLoans.Imprimir" %>

<!DOCTYPE html>

<html lang="en">
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
        <div class="container" style="background-color: aqua; width: 300px; text-align-last: center">
            <%--Contenedor del Ticket--%>
            <h5>Banca 01</h5>
            <div>
                Pagamos al instante
            </div>

            <a style="margin: 10px"></a>

            <div style="text-align-last: left">
                <a>Telefono:</a>
                <a>829-248-4353</a>

            </div>
            <div style="text-align-last: left">
                <a>Vendedor:</a>
                <a>Victor Manuel</a>

            </div>
            <div style="text-align-last: left">
                <a>Fecha:</a>
                <a>21/05/2021 00:03:06</a>

            </div>
            <br />

            <div style="text-align-last: center;">
                <a>Num. Ticket:</a>
                <a>210004552</a>

            </div>
            <div style="text-align-last: center">
                <h6>Jugadas</h6>

            </div>
            <div style="text-align-last: left">
                <a>LP:</a>
                <a>La Primera</a>

            </div>
            <br />

            <div class="row">
                <div class="col-5" style="text-align-last: left; font-weight: bold;">
                    TP Nume.
                </div>
                <div class="col" style="text-align-last: left; font-weight: bold;">
                    Loterias
                </div>
                <div class="col" style="text-align-last: right; font-weight: bold;">
                    Valor
                </div>

            </div>
            <div class="row">
                <div class="col" style="text-align-last: center;">
                    -------------------------------------------
                </div>
            </div>
            <div class="row">
                <div class="col-5" style="text-align-last: left; font-weight: bold;">
                    QN 87-99-09
                </div>
                <div class="col" style="text-align-last: left; font-weight: bold;">
                    LP
                </div>
                <div class="col" style="text-align-last: right; font-weight: bold;">
                    S100
                </div>

            </div>
            <div class="row">
                <div class="col" style="text-align-last: center;">
                    -------------------------------------------
                </div>
            </div>


            <section>
                <table>

                </table>

            </section>
            <div class="row">
                <div class="col-5" style="text-align-last: left; font-weight: bold;">
                    SUB-T
                </div>
                <div class="col" style="text-align-last: right; font-weight: bold;">
                    Rd$100
                </div>

            </div>
            <div class="row">
                <div class="col-5" style="text-align-last: left; font-weight: bold;">
                    Free
                </div>
                <div class="col" style="text-align-last: right; font-weight: bold;">
                    Rd$0
                </div>

            </div>
            <div class="row">
                <div class="col-5" style="text-align-last: left; font-weight: bold;">
                    TOTAL
                </div>
                <div class="col" style="text-align-last: right; font-weight: bold;">
                    Rd$100
                </div>

            </div>
            <div class="row">
                <div class="col" style="text-align-last: center;">
                    -------------------------------------------
                    -------------------------------------------
                </div>
            </div>
            <div class="row">
                <div class="col" style="text-align-last: center;">
                    Buena Suerte
                </div>
            </div>
            <div class="col" style="text-align-last: center;">
                Revisar su ticket
            </div>
            <div class="col" style="text-align-last: center;">
                No pagamos sin ticket
            </div>
            <br />
            <div>
                <img runat="server" src="" id="imgCtrl" />
            </div>
            <br />

        </div>

        <div class="container">
            <h2>How to Generate QR Code in ASP.NET MVC</h2>
            <div class="row">
                <div class="col-md-9">
                    <div class="form-group">
                        <label>Enter Something</label>
                        <div class="input-group">
                            <input type="text" id="TbCode" runat="server" class="form-control" value="@ViewBase.txtQRCode" />
                            <div class="input-group-prepend">
                                <button runat="server" type="submit" onserverclick="BtnGenerarQR_Click">Generte QR</button>
                            </div>

                        </div>

                    </div>
                </div>
            </div>



        </div>
    </form>
</body>
</html>
