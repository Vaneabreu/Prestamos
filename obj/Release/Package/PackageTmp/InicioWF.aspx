<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioWF.aspx.cs" Inherits="SoftLoans.InicioWF" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>SoftLoans</title>
    <!-- Bootstrap CSS -->
    <link href="/Content/bootstrap.min.css" rel="stylesheet">

    <!-- SweetAlert -->
    <script src="/Scripts/SweetAlert.min.js"></script>
    <link href="/Content/sweetalert/sweet-alert.css" rel="stylesheet" />

    <%-- Controlar el Evento KeyPress --%>
    <script>

        function disableEnterKey(e) {
            var key;
            if (window.event) {
                key = window.event.keyCode; //IE
                var tbP = document.getElementById("TbPassword");
                //var tbU = document.getElementById("TbUser");
                var value = document.getElementById('<%=TbUser.ClientID%>').value;
                if (e.keyCode == 13) {
                    tbP.focus();
                }
                
            }
            else
                key = e.which; //firefox     

            return (key != 13);
        }

       
    </script>



</head>

<body class="bg-dark">
    <form id="form1" runat="server">
        <%--<script src="node_modules/bootstrap/dist/js/bootstrap.bundle.min.js"></script>--%>
        <%--    
     <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js"></script>  --%>

        <script src="/Scripts/bootstrap.bundle.min.js"></script>
        <script src="/Scripts/loansApp.js"></script>

        <section>
            <div class="row g-0">
                <div class="col-lg-7 g-0 d-none d-lg-block">
                    <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel">

                        <div class="carousel-indicators">
                            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0"
                                class="active" aria-label="Slide 1">
                            </button>
                            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1"
                                aria-label="Slide 2">
                            </button>
                        </div>
                        <div class="carousel-inner">
                            <div class="carousel-item min-vh-100 active" style="background-image: url('/imagen/imagenH.png'); background-position: center; background-position: center">
                            </div>
                            <div class="carousel-item min-vh-100" style="background-image: url('/imagen/imagenV.png'); background-position: center; background-position: center">
                            </div>
                        </div>
                        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators"
                            data-bs-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Previous</span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators"
                            data-bs-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Next</span>
                        </button>
                    </div>

                </div>
                <div class="col-lg-4 align-items-sm-baseline flex-column">

                    <div class="px-lg-5 pt-lg-4 pb-lg-3 p-5 w-100" >
                        <img src="/imagen/IconoColor.png" class="img-fluid fix" />
                    </div>

                    <div class="px-lg-5 py-lg-4 p-lg-5 w-100 ">
                        <h2 class="text-light fw-bold mb-4" style="margin-left: 5%; margin-right: 5%">Bienvenidos a SoftLoans</h2>
                        <div class="mb-0" style="margin-left: 5%; margin-right: 5%">
                            <label for="exampleInputEmail1" class="text-light form-label fw-bold">Usuario</label>
                            <asp:TextBox ID="TbUser" runat="server" CssClass="form-control bg-dark-x  border-0"
                                Height="40px" placeholder="Ingrese su usuario"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVUser" runat="server"
                                ControlToValidate="TbUser"
                                ErrorMessage="Campo obligatorio"
                                ForeColor="Red"
                                EnableClientScript="false">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="mb-3" style="margin-left: 5%; margin-right: 5%">
                            <label for="exampleInputPassword1" class="text-light form-label fw-bold">Contraseña</label>
                            <asp:TextBox ID="TbPassword" runat="server" CssClass="form-control bg-dark-x border-0" TextMode="Password"
                                Height="40px" placeholder="Ingrese su contraseña"></asp:TextBox>
                        </div>
                        <div class="mb-3" style="margin-left: 5%; margin-right: 5%">
                            <button runat="server" class="btn btn-primary w-100 mb-0" onserverclick="BtnIniciar_Click">
                                <b>
                                    <i>Iniciar sesión</i>
                                </b>
                            </button>                            
                        </div>
                        <div class="mb-3" style="margin-left: 5%; margin-right: 5%; text-align:right" >                            
                           <label id="lbVersion" runat="server" class="text-light form-label fw-normal" style="text-align:right"></label>                            
                        </div>
                        <asp:HiddenField id="myHiddenInput" runat="server"/>

                    </div>

                </div>
            </div>
        </section>


    </form>


</body>

</html>
