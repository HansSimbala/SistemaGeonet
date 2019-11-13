$(document).ready(function () {
    $('#myModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var clickedButtonId = button.data('Id');
        $("#IdDetalleCarrito").text(clickedButtonId);
        $("input #id").val(clickedButtonId);
    });
}