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
    var numeroTarjeta = document.getElementById("cardnumber").value.replace(/ /g, "");
    console.log(numeroTarjeta)
    var cvv = document.getElementById("securitycode").value;
    var FechaVencimiento = document.getElementById("expirationdate").value;
    $.ajax({
        type: 'POST',
        url: "/Tarjetas/Agregar",
        data: {
            numeroTarjeta,
            cvv,
            FechaVencimiento
        },
        success: function (response) {
            console.log(response);
        },
    });
}

    //var idTarjeta = document.getElementById("IdTarjeta").value;
    //console.log(idTarjeta);
    //var visaRegEx = /^(?:4[0-9]{12}(?:[0-9]{3})?)$/;

    //if (visaRegEx.test(idTarjeta) === false) {
    //    console.log("Please provide a valid Visa number!");
    //}
    //else {
    //    console.log("Thank You!");
    //}  