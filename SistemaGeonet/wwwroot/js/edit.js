function editQuantity(IdDetalleCarrito, idcantidad) {
    var cantidad = document.getElementById(idcantidad).value;
    $.ajax({
        type: 'POST',
        url: "/DetalleCarritoes/Editar",
        data: {
            IdDetalleCarrito,
            cantidad
        },
        success: function (response) {
            console.log(response);
        },
    });
}