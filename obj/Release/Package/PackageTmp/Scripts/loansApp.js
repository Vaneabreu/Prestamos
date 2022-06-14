
function next() {
    var dd = document.getElementById("Img1")
    dd.style = "background-image: url('imagen/imagenV.png'); background-size: auto;background-position: center";
    dd.class = "carousel-item min-vh-100 img-1 active";
}
function back() {
    var dd = document.getElementById("Img1")
    dd.style = "background-image: url('imagen/imagenH.png'); background-size: auto;background-position: center";
    dd.class = "carousel-item min-vh-100 img-1 active";
}


function alertaNueva() {
    var confirm_value = document.createElement("INPUT");
    confirm_value.type = "hidden";
    confirm_value.name = "confirm_value";
    swal({
        title: "Estas seguro?",
        text: "Una vez eliminado, ¡no podrá recuperar este cliente!",
        icon: "warning",
        buttons: true,

        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                confirm_value.value = "Yes";


            } else {
                confirm_value.value = "No";

            }

        });
    document.forms[0].appendChild(confirm_value);
}

function Imagenes(dirImage, listId) {

    var dir = dirImage;
    var myArray = dirImage.split(",");
    var myArrayID = listId.split(",");
    //<button runat="server"  onserverclick="BtnCerrarSeccion_Click" class="btn btn-primary">
    //
    //<b>
    //    <img src="/Content/bootstrap-icons/icons/file-earmark-plus.svg" alt="Bootstrap" width="22"
    //        height="22" /><i> Imprimir </i></b
    // <button runat="server" id="btn${index}" name="btn" class="btn-loteria" onserverclick="BtnSeleccionLoteria_Click">btn${index}<b><img src=${currentValue} class="img-thumbnail img-loteria"/></b></button>

    var tablaFila = document.getElementById("ListImg");
    myArray.forEach(function (currentValue, index, arr) {
        tablaFila.innerHTML +=
            ` <div class="col-lg-2 container-img-Lis">                        
                   <a  runat="server" onserverclick="BtnSeleccionLoteria_Click">aaaaa</a>
                </div> 
            `

    })

}


function AlertaImagen() {
    swal({
        title: "Proceso completado!",
        text: "Ttexto largo",
        icon: "success",
        buttons: ["Permanecer aqui", "Ir a ventana de consulta"],
        type: "success",
        dangerMode: true


    })
}


/************Metodos en USO**************************/
function VentasMensual2( Enero,Febrero,Marzo,Abril,Mayo,Junio,Julio,Agosto,Septiembre, Optubre, Novienbre,Diciembre)
{
    const labels = [
        'Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo','Junio', 'Julio', 'Agosto', 'Septiembre', 'Optubre', 'Novienbre', 'Diciembre',
    ];
    const data = {
        labels: labels,
        datasets: [{
            label: 'ventas de Numeros',
            backgroundColor: 'rgb(255, 99, 132)',
            borderColor: 'rgb(255, 99, 132)',
            //data: [Enero, Febrero, Marzo, Abril, Mayo, Junio, Julio, Agosto, Septiembre, Optubre, Novienbre, Diciembre],
            data: [0, 0, 0, 0, 30000, 2000, 700, 500, 0, 0, 0, 0],

        }]
    };
    const config = {
        type: 'line',
        data,
        options: {}
    };
    var myChart = new Chart(
        document.getElementById('myChart'),
        config
    );
}


function Confirmacion(texto, dir) {
    swal({
        title: "Proceso completado!",
        text: "" + texto + "",
        icon: "success",
        buttons: ["Permanecer aqui", "Ir a ventana de consulta"],
        type: "success"

        // dangerMode: true


    })
        .then((willDelete) => {
            if (willDelete) {
                window.location = dir;
            }

        });


}

function ConfirmacionOneButton(texto, dir) {
    swal({
        title: "Proceso completado!",
        text: "" + texto + "",
        icon: "success",
        buttons: "Ir a ventana de consulta",
        type: "success"

        // dangerMode: true


    })
        .then((willDelete) => {
            if (willDelete) {
                window.location = dir;
            }

        });


}

function EliminarCliente(index) {

    swal({
        title: "Estas seguro?",
        text: "Una vez eliminado, ¡no podrá recuperar este cliente!",
        icon: "warning",
        buttons: true,

        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                PageMethods.Borrar(index, onSucess, onError);
            } else {
                //swal("¡Tu archivo cliente está a salvo!");
                //alert('Cannot process your request at the moment, please try later.');

            }

        });

    function onSucess(result) {
        //swal(result, {
        //    icon: "success",
        //});
    }

    function onError(result) {
        alert('Cannot process your request at the moment, please try later.');
    }
}
function EliminarLimiteNumero(index) {

    swal({
        title: "¡Proceso de Eliminación!",
        text: "¿Está seguro de continuar con dicho proceso?",
        icon: "warning",
        buttons: true,

        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                PageMethods.BorrarLimiteNumero(index, onSucess, onError);
            } else {
                //swal("¡Tu archivo cliente está a salvo!");
                //alert('Cannot process your request at the moment, please try later.');

            }

        });

    function onSucess(result) {
        //swal(result, {
        //    icon: "success",
        //});
    }

    function onError(result) {
        alert('Cannot process your request at the moment, please try later.');
    }
}
function Imprimir() {

    // var tablaFila = document.getElementById("form1");

    var tablaFila1 = ` <div class="container" style="background-color: aqua; width: 300px; text-align-last: center">
            <h5>Banca 01</h5><div>Pagamos al instante</div><a style="margin: 10px"></a><div style="text-align-last: left">
                <a>Telefono:</a><a>829-248-4353</a></div><div style="text-align-last: left"><a>Vendedor:</a><a>Victor Manuel</a></div>
            <div style="text-align-last: left"><a>Fecha:</a><a>21/05/2021 00:03:06</a></div><br /><div style="text-align-last: center;">
                <a>Num. Ticket:</a><a>210004552</a></div><div style="text-align-last: center"><h6>Jugadas</h6></div><div style="text-align-last: left">
                <a>LP:</a><a>La Primera</a></div><br /><div class="row"><div class="col-5" style="text-align-last: left; font-weight: bold;">TP Nume.</div>
                <div class="col" style="text-align-last: left; font-weight: bold;">Loterias</div><div class="col" style="text-align-last: right; font-weight: bold;">
                    Valor</div></div><div class="row"><div class="col" style="text-align-last: center;">-------------------------------------------</div></div>
            <div class="row"><div class="col-5" style="text-align-last: left; font-weight: bold;">QN 87-99-09</div><div class="col" style="text-align-last: left; font-weight: bold;">
                    LP</div><div class="col" style="text-align-last: right; font-weight: bold;">S100</div></div><div class="row"><div class="col" style="text-align-last: center;">
                    -------------------------------------------</div> </div><div class="row"><div class="col-5" style="text-align-last: left; font-weight: bold;">SUB-T</div>
                <div class="col" style="text-align-last: right; font-weight: bold;">Rd$100</div></div><div class="row"><div class="col-5" style="text-align-last: left; font-weight: bold;">
                    Free</div><div class="col" style="text-align-last: right; font-weight: bold;">Rd$0</div></div><div class="row"><div class="col-5" style="text-align-last: left; font-weight: bold;">
                    TOTAL</div><div class="col" style="text-align-last: right; font-weight: bold;">Rd$100</div></div><div class="row"><div class="col" style="text-align-last: center;">
                    -------------------------------------------
                    -------------------------------------------
                </div></div><div class="row"><div class="col" style="text-align-last: center;">Buena Suerte</div></div><div class="col" style="text-align-last: center;">Revisar su ticket
                </div><div class="col" style="text-align-last: center;">No pagamos sin ticket</div><br /></div>
            `
    ////var printContents = document.getElementById('imp1').innerHTML;
    //w = window.open();
    //w.document.write(tablaFila1);
    //w.document.close(); // necessary for IE >= 10
    //w.focus(); // necessary for IE >= 10
    //w.print();
    //w.close();
    return tablaFila1;
}

function ReImprimir() {
    printJS({
        printable: "TicketReImprimirC",
        type: "html",
        css: ['/Content/bootstrap.min.css'],
        style: "'.custom-GG { color: red; } .aling-T-R{text-align-last: right;} .aling-T-C{text-align-last: center; font-size: 20px}.aling-T-L{text-align-last: left;} .negrita-T{color: black;  font-weight: bold;}.fs-m { font-size: 20px}.fs-l {font-size: large;}.fs-xl {1.8em}.lineaSolida-T{border-width: 2px; border-style: solid; border-color: black;}.lineaPuntos-T{border-width: 2px; border-style: dashed; border-color: black; margin:0px;}' ",
        targetStyles: ['*'],

        onPrintDialogClose: reImprimirComplete
    });
}

function ReImprimir1() {
    printJS({
        printable: "TicketReImprimirC",
        type: "html",
        css: '/Content/bootstrap.min.css',
        style: ` '.custom-GG { color: red; } 
            .aling-T-R{text-align-last: right;}
            .aling-T-C{text-align-last: center;}
            .aling-T-L{text-align-last: left;}
            .negrita-T{color: black;  font-weight: bold;}
            .lineaSolida-T{border-width: 2px; border-style: solid; border-color: black;}
            .lineaPuntos-T{border-width: 2px; border-style: dashed; border-color: black; margin:0px;}'
            `,

        onPrintDialogClose: reImprimirComplete
    });
}
function reImprimirComplete() {
    var TicketImprimirC = document.getElementById("TicketReImprimirC");
    TicketImprimirC.style = "display: none;";
}


function printTest() {
    printJS({
        printable: "TicketImprimir",
        type: "html",
        css: ['/Content/bootstrap.min.css'],
        style: "'.custom-GG { color: red; } .aling-T-R{text-align-last: right;} .aling-T-C{text-align-last: center; font-size: 20px}.aling-T-L{text-align-last: left;} .negrita-T{color: black;  font-weight: bold;}.fs-m { font-size: 20px}.fs-l {font-size: large;}.fs-xl {1.8em}.lineaSolida-T{border-width: 2px; border-style: solid; border-color: black;}.lineaPuntos-T{border-width: 2px; border-style: dashed; border-color: black; margin:0px;}' ",
        targetStyles: ['*'],
        onPrintDialogClose: printJobComplete
        
    });
}


function ImprimirListadoTicket() {



    printJS({
        printable: "GvListPretamos",
        type: "html",
        css: ['/Content/bootstrap.min.css', '/Content/print.min.css'],
     

        onPrintDialogClose: ImprimirListadoTicketCompletado
    });
}



function ImprimirListadoTicketCompletado() {

    var ListadoImprimir = document.getElementById("ListadoImprimir");
    ListadoImprimir.style = "display: none;";
    document.getElementById("BtnBuscar").click(); return false;
}


function printJobComplete() {
    var TicketImprimirC = document.getElementById("TicketImprimirC");
    TicketImprimirC.style = "display: none;";
    document.getElementById("BtnAgregar").click(); return false;

    /* PageMethods.Limpiar();*/


}


function NotificacionYN(index, title, text, metodo) {

    swal({
        title: title,
        text: text,
        icon: "warning",
        buttons: true,

        dangerMode: true,
    })
        .then((willAction) => {
            if (willAction) {
                switch (metodo) {
                    case "Borrar":
                        PageMethods.Borrar(index, onSucess, onError);
                        break;
                    case "Cancelar":
                        PageMethods.Cancelar(index, onSucess, onError);
                        break;
                    case "Guardar":
                        PageMethods.Guardar(index, onSucess, onError);
                        break;

                }

            } else {
                //swal("¡Tu archivo cliente está a salvo!");
                //alert('Cannot process your request at the moment, please try later.');

            }

        });

    function onSucess(result) {
        //swal(result, {
        //    icon: "success",
        //});
    }

    function onError(result) {
        alert('Cannot process your request at the moment, please try later.');
    }
}

function disableEnterKey1(e) {
    var key;
    if (window.event.key = "Enter") {
        key = window.event.keyCode; //IE
        var tbP = document.getElementById("TbMonto");
        if (e.keyCode == 13) {
            tbP.focus();
        }
       
        // $("#TbMonto").trigger("click");
    }
    else {
        key = e.which; //firefox  
    }


    return (key != 13);
}
function disableEnterKey2(e) {
    var key;
    if (window.event.key = "Enter") {
        key = window.event.keyCode; //IE
        //var tbP = document.getElementById("TbNumero");
        //tbP.Text = "1111";
       //console.log(key + "SI");
        // 
    }
    else {
        key = e.which; //firefox  
        //console.log(key + "NO");
    }

    if ((key != 13)) {
    } else {
        //var Btn = document.getElementById('BtnAgregar');
        //console.log(Btn.id + "NO");
        document.getElementById("BtnAgregar").click(); return false;
       // Btn.Click();
        //return true;
    }

}





//Inicio Codigo en USO

function ImprimirListPrestamos() {



    printJS({
        printable: "DivGridView",
        type: "html",

        header: '<h3 class="custom-h3">Listado de Prestamos</h3>',
        css: ['/Content/bootstrap.min.css', '/Content/print.min.css'],



        onPrintDialogClose: ImprimirListadoTicketCompletado
    });
}



function ImprimirListPrestamoCompletado() {

    document.getElementById("BtnRecargarDatos").click(); return false;
}

//function GenerdorIDUnico()
//{
//    var navigator_info = window.navigator;
//    var screen_info = window.screen;
//    var uid = navigator_info.mimeTypes.length;
//    uid += navigator_info.userAgent.replace(/D+/g, "");
//    uid += navigator_info.plugins.length;
//    uid += screen_info.height || "";
//    uid += screen_info.width || "";
//    uid += screen_info.pixelDepth || "";
//    document.querySelector('#myHiddenInput').value = uid;
//    //document.querySelector('#LbCodigoEquipo').innerText = uid;
//}


function GenerdorIDUnico() {
    var navigator_info = window.navigator;
    var screen_info = window.screen;
    var uid = navigator_info.mimeTypes.length;
    uid += navigator_info.userAgent.replace(/D+/g, "");
    uid += navigator_info.plugins.length;
    uid += screen_info.height || "";
    uid += screen_info.width || "";
    uid += screen_info.pixelDepth || "";
    uid = new DeviceUUID().get();
    document.querySelector('#myHiddenInput').value = uid;
    //document.querySelector('#LbCodigoEquipo').innerText = uid;
}

function Notificacion(texto, titulo, icono) {
    swal({
        title: "" + titulo + "",
        text: "" + texto + "",
        icon: "" + icono + "",
        dangerMode: true
    });


}

function ImprimirReciboCobro(Empresa, Telefono, Fecha, ClienteNombre,
    IdPrestamo, NumCuotaPagada, TotalCuota,
    ValorPagado, MontoCuota, Abono,
    CuotaAtrasada, MontoTotalPendiente, vendedor, montoAtraso) {

    printJS({
        printable: "DivReciboCobro",
        header: '<h3 class="aling-T-C negrita-T">'+Empresa+'</h3>'
            + '<h5 class="aling-T-C negrita-T">(' + Telefono + ')</h5>'
            + '<hr class="lineaPuntos-T" />'
            + '<br />'
            + '<h4 class="aling-T-C negrita-T">Recibo de Cobro</h4>'
            + '<hr class="lineaPuntos-T" />'
            + '<h5 class="aling-T-L negrita-T">Fecha: ' + Fecha + '</h5>'
            + '<h5 class="aling-T-L negrita-T"># Prestamo: ' + IdPrestamo + '</h5>'
            + '<h5 class="aling-T-L negrita-T">Cliente: ' + ClienteNombre + '</h5>'
            + '<hr class="lineaPuntos-T" />'
            + '<h5 class="aling-T-L">Pago a cuota: <b>' + NumCuotaPagada + ' de ' + TotalCuota+'</b></h5>'
            + '<h5 class="aling-T-L">Abono a Cuota: <b>' + Abono + '</b></h5>'
            + '<h5 class="aling-T-L">Valor Pagado: <b>' + ValorPagado + '</b></h5>'
            + '<h5 class="aling-T-L">Monto Cuota: <b>' + MontoCuota + '</b></h5>'
            + '<h5 class="aling-T-L">Monto Atraso: <b>' + montoAtraso + '</b></h5>'
            + '<h5 class="aling-T-L">Cuota Atrasadas: <b>' + CuotaAtrasada + '</b></h5>'
            + '<br />'
            + '<h5 class="aling-T-L ">Total Pendiente: <b>' + MontoTotalPendiente + '</b></h5>'
            + '<br />'
            + '<h5 class="aling-T-C ">Cobrador: ' + vendedor + '</h5>'
            + '<br>'
            + '<h5 class="aling-T-C negrita-T">Firma Cliente</h5>',
        type: "html",
        css: ['/Content/bootstrap.min.css', '/Content/print.min.css','/Content/estilos.css'],
        onPrintDialogClose: ImprimirReciboCompletado
    });
}

function ImprimirReciboCobroReimprimir(Empresa, Telefono, Fecha, ClienteNombre,
    IdPrestamo, NumCuotaPagada, TotalCuota,
    ValorPagado, MontoCuota, Abono,
    CuotaAtrasada, MontoTotalPendiente, vendedor, montoAtraso) {

    printJS({
        printable: "DivReciboCobro",
        header: '<h3 class="aling-T-C negrita-T">' + Empresa + '</h3>'
            + '<h5 class="aling-T-C negrita-T">(' + Telefono + ')</h5>'
            + '<hr class="lineaPuntos-T" />'
            + '<br />'
            + '<h4 class="aling-T-C negrita-T">Recibo de Cobro</h4>'
            + '<hr class="lineaPuntos-T" />'
            + '<h5 class="aling-T-L negrita-T">Fecha: ' + Fecha + '</h5>'
            + '<h5 class="aling-T-L negrita-T"># Prestamo: ' + IdPrestamo + '</h5>'
            + '<h5 class="aling-T-L negrita-T">Cliente: ' + ClienteNombre + '</h5>'
            + '<hr class="lineaPuntos-T" />'
            + '<h5 class="aling-T-L">Pago a cuota: <b>' + NumCuotaPagada + '</b></h5>'
            + '<h5 class="aling-T-L">Valor Pagado: <b>' + ValorPagado + '</b></h5>'
            + '<h5 class="aling-T-L">Monto Cuota: <b>' + MontoCuota + '</b></h5>'
            + '<h5 class="aling-T-L">Monto Atraso: <b>' + montoAtraso + '</b></h5>'
            + '<h5 class="aling-T-L">Cuota Atrasadas: <b>' + CuotaAtrasada + '</b></h5>'
            + '<br />'
            + '<h5 class="aling-T-L ">Total Pendiente: <b>' + MontoTotalPendiente + '</b></h5>'
            + '<br />'
            + '<h5 class="aling-T-C ">Cobrador: ' + vendedor + '</h5>'
            + '<br>'
            + '<h5 class="aling-T-C negrita-T">Firma Cliente</h5>',
        type: "html",
        css: ['/Content/bootstrap.min.css', '/Content/print.min.css', '/Content/estilos.css'],
        onPrintDialogClose: ImprimirReciboCompletado
    });
}


function ImprimirContrato(texto, title) {

    printJS({
        printable: "DivContrato",
        header: '<p style="text-align: center;">' + title + '</p><p style="text-align: justify;">'+texto+'</p>',
        type: "html",
        css: ['/Content/bootstrap.min.css', '/Content/print.min.css', '/Content/estilos.css'],
        onPrintDialogClose: ImprimirReciboCompletado
    });
}


function ImprimirRecibo() {



    printJS({
        printable: "ReciboImprimir",
        type: "html",
        css: ['/Content/bootstrap.min.css', '/Content/print.min.css'],


        onPrintDialogClose: ImprimirReciboCompletado
    });
}

function ImprimirReciboCompletado() {

    //var ListadoImprimir = document.getElementById("ReciboImprimir");
    //ListadoImprimir.style = "display: none;";
    document.getElementById("BtnBuscar").click(); return false;
}


function ImprimirListadoCobro(list) {



    printJS({
        printable: "div-list",//"DivGridViewListCobros",
        header: '<h3 class="aling-T-C negrita-T">Listado de Cobros Realizados</h3>'
          + list,
        type: "html",
        css: ['/Content/bootstrap.min.css', '/Content/print.min.css'],


        onPrintDialogClose: ImprimirListadoCobroCompletado
    });
}

function ImprimirListadoCobroCompletado() {

    //var ListadoImprimir = document.getElementById("ReciboImprimir");
    //ListadoImprimir.style = "display: none;";
    document.getElementById("BtnBuscar").click(); return false;
}
//Fin de codigo en Uso