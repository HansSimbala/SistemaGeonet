var list = [];
function agregarCarritoLS(idEquipo) {
    list.push(idEquipo);
    localStorage.setItem("Equipo", list);
}


///*Obtener datos almacenados*/
//var nombre = localStorage.getItem("Nombre");
//var apellido = localStorage.getItem("Apellido");
///*Mostrar datos almacenados*/
//document.getElementById("nombre").innerHTML = nombre;
//document.getElementById("apellido").innerHTML = apellido; 