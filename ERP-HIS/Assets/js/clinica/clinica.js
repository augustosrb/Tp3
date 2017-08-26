$(document).ready(function () {

    var cod_categoria = null;
    var row = null;

    $("#btnConsultarOM").click(function (e) {
        e.preventDefault();

        metodo_listar();
    });
    
});

var metodo_listar = function () {
    
    var oTable = $('#tableNormal').dataTable();

    //var formData = $('#busquedaSistema').serialize();

    //$('#pageBody').prepend(block);
    $.get("http://localhost:55465/ointervencion/ListadoOrden", function (data, status) {

        //alert("Data: " + data + "\nStatus: " + status);

        //block.remove();

        oTable.fnClearTable();

        $.each(data, function (key, value) {
            //alert("Value: " + value );

            oTable.fnAddData([value.Id, value.nOrdenIntId, value.DNI, value.ApeNom, value.Sede, value.TipoInt, value.Estado,
            '<a>' +
            '<span id="editSistema" class="icon-pencil"></span> ' +
            '</a>'+
            '<a>' +
            '<span  class="icon-close"></span></a>'
            ]);
        });

        oTable.fnDraw();
    });
}