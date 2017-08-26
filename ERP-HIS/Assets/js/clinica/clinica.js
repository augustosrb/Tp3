$(document).ready(function () {

    var cod_categoria = null;
    var row = null;

    $("#btnConsultarOM").click(function (e) {
        e.preventDefault();

        metodo_listar();
    });

    
    $("#buscarPaciente").click(function (e) {
        e.preventDefault();

        var dni = $("#documento").val();

        var oTable = $('#tableNoPaging').dataTable();

        $.get("http://localhost:55465/ointervencion/buscarPaciente", { dni: dni} ,function (data, status) {
            $.each(data, function (key, value) {
                    $('[name=' + key + ']', '#form_datos_paciente').val(value);
            });
        });

        $.get("http://localhost:55465/ointervencion/buscarOrdenesMedicas", { dni: dni }, function (data, status) {
            $.each(data, function (key, value) {
                oTable.fnClearTable();

                $.each(data, function (key, value) {
                    oTable.fnAddData([value.nOrdenMedId, value.IdOrden, "Jose Lopez", value.TipoInt, value.Estado
                    ]);
                });

                oTable.fnDraw();
            });
        });

    });
    
});

var metodo_listar = function () {
    
    var oTable = $('#tableNormal').dataTable();

    $.get("http://localhost:55465/ointervencion/ListadoOrden", function (data, status) {

        oTable.fnClearTable();

        $.each(data, function (key, value) {
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