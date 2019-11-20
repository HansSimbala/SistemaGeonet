function getPago() {
    var idMetodoPago = document.getElementById("IdMetodoPago").value;
    var tarjeta = document.getElementById("Tarjeta");
    var voucher = document.getElementById("Voucher");
    if (idMetodoPago == 1) {
        tarjeta.style.display = 'block';
        voucher.style.display = 'none';
    } else {
        tarjeta.style.display = 'none';
        voucher.style.display = 'block';
    }
}

function ordenarPedido() {
    var IdCarritoOrden;
    var IdPago;
    var fechapedido;
    var direccion;
    var telefono;
    var email;
    var IdMetodoPago = document.getElementById("IdMetodoPago").value;
    console.log("metodo"+IdMetodoPago);

    if (IdMetodoPago == 1) {
        var numeroTarjeta = document.getElementById("IdTarjeta").value;
        var cvv = document.getElementById("IdCvv").value;
        var FechaVencimiento = document.getElementById("IdFecha").value;
        $.ajax({
            type: 'POST',
            url: "/Tarjetas/Agregar",
            data: {
                numeroTarjeta,
                cvv,
                FechaVencimiento
            },
            success: function (response) {
                console.log("idtarjeta" + response);
                IdPago = response;
            },
        });
    }
    else if (IdMetodoPago == 2) {
        var foto = document.getElementById("idFoto").value;
        console.log(foto);

        $.ajax({
            type: 'POST',
            url: "/Vouchers/Agregar",
            data: {
                foto
            },
            success: function (response) {
                console.log("idvoucher" + response);
                IdPago = response;
            },
        });
    } else {
        document.getElementById("message").innerHTML = "Seleccionar un método de pago.";
        document.getElementById("message").style.color = "#ff0000";
        return;
    }
    $.ajax({
        type: 'POST',
        url: "/OrdenPedidoes/Agregar",
        data: {
            IdCarritoOrden,
            fechapedido,
            direccion,
            telefono,
            email,
            IdMetodoPago,
            IdPago
        },
        success: function (response) {
            console.log(response);
        },
    });
}