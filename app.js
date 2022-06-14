function next()
{
    var dd = document.getElementById("Img1")
    dd.style = "background-image: url('imagen/imagenV.png'); background-size: auto;background-position: center";
    dd.class = "carousel-item min-vh-100 img-1 active";
}
function back(){
    var dd = document.getElementById("Img1")
    dd.style = "background-image: url('imagen/imagenH.png'); background-size: auto;background-position: center";
    dd.class = "carousel-item min-vh-100 img-1 active";
}

function tabla() {


    var tablaFila = document.getElementById("filasClientes");
    for (let index = 0; index < 10; index++) {
        tablaFila.innerHTML +=
            `  <div class="row border border-dark"> 
            <div class="col-1 d-none d-lg-block id="${index}"">
             ${index}
            </div>
            <div class="col-2 d-none d-lg-block">
            0540150014-4
            </div>
            <div class="col">
            Victor
            </div>   
            <div class="col d-none d-lg-block">
            Mancebo
            </div> 
            <div class="col-2 d-none d-lg-block" >
            829-248-4353
            </div>              
            <div class="col-1 d-none d-lg-block">
            SI
            </div>
            <div class="col-1  btn-warning" style="min-width: 60px  ;max-width: 70px">             
            <img onclick="alertaFila(${index})" src="/node_modules/bootstrap-icons/icons/pencil.svg" alt="Bootstrap" width="20" height="20"></img>
            </div>
            <div class="col-1 btn-danger" style="min-width: 60px  ;max-width: 70px">        
            <img src="/node_modules/bootstrap-icons/icons/trash.svg" alt="Bootstrap" width="20" height="20" color="red"></img>
            </div>
            </div>
            `

    }


}


function alertaFila(id) {
    alert("fila numero: " + id);
}

function Confirmacion(texto,direccion) {
    if (confirm(texto)) {
        Response.Redirect(direccion);
    }
}

