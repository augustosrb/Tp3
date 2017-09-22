$(document).ready(function () {
    var cod_categoria = null;
    var row = null;

    var d = new Date();

    var month = d.getMonth() + 1;
    var day = d.getDate();

    var output = (day < 10 ? '0' : '') + day + '/' +
        (month < 10 ? '0' : '') + month + '/' +
        d.getFullYear();

    $("#fecha").val(output);

    var tipointervenciones = "";
    var name = "tipointervencion";

    $('div.myClass').click(function () {
        var text = $(this).text();
        alert(text);
        // do something with the text
    });

    $('#myDiv1').on("click", function () { 
        alert("onclick");
    });
    $.get("http://localhost:55465/planificarintervencion/ListadoTipoInt", function (result, status) {

        $('select[id="' + name + '"] option').remove();

        tipointervenciones += "<option value='0'>::Seleccione::</option>";

        $.each(result, function (key, value) {
            tipointervenciones += "<option value=" + value.nTipoIntervencionId + ">" + value.cTipoIntNombre + "</option>";
        });

        $('select[id="' + name + '"]').append(tipointervenciones);
    });

    function Ficha(pacid, nombres, intervencion, porcentaje, ubicacion, color, sexo, edad) {
        var resultado = "";

        resultado =
            /*"<div class='myClass'>1</div>"+
            "<div class='myClass'>2</div>"+
            "<div class='myClass'>3</div>"+*/
            "<div  class='col-md-4 column sortable'>" +
            "<div  class='portlet portlet- sortable box " + color + "'>" +
            "<div class='portlet-title'>" +
            "<div class='tools'>" +
            "<a href='' class='remove'> </a>" +
            "</div>" +
            "</div>" +
            "<div class='portlet-body'>" +
            "<div class='row'>" +
            "<div class='col-md-4'>" +
            "<img src='../assets/pages/img/avatars/team" + pacid + ".jpg' width='100' height='80' />" +
            "</div>" +
            "<div class='col-md-8'>" +
            "<label class='control-label bold'>DATOS PACIENTE</label>" +
            "<label class='control-label'>Apellidos y Nombres</label>" +
            "<label id='myDiv1' class='control-label bold'>" + nombres + "</label>" +
            "</div>" +
            "</div>" +
            "<div class='row'>" +
            "<div class='col-md-6'>" +
            "<label class='control-label'>Tipo Intervención</label>" +
            "<label class='control-label bold'>" + intervencion + "</label>" +
            "</div>" +
            "<div class='col-md-6'>" +
            "<label class='control-label'>Progreso Atención</label> <br/>" +
            "<label class='control-label bold'>" + porcentaje + "</label>" +
            "</div>" +
            "</div>" +
            "<div class='row'>" +
            "<div class='col-md-12 text-center'>" +
            "<label class='control-label bold'>Ubicación : " + ubicacion + "</label>" +
            "</div>" +
            "</div>" +
            "</div>" +
            "</div>" +
            "</div>";

        return resultado;
    }

    $.get("http://localhost:55465/priorizaratencion/ListadoPriorizados", function (result, status) {
        var fichastotal = "";
        var popups = "";

        $.each(result, function (key, value) {
            fichastotal = fichastotal + " " + Ficha(value.nPacienteId, value.cNombres, value.cTipoIntNombre, value.cPorcentaje, value.cAmbienteNombre, value.cColor, value.cSexo, value.nEdad);
        });
        fichastotalcuadro.innerHTML = fichastotal;
    });


    $("#btnConsultarPlan").click(function (e) {
        e.preventDefault();

        metodo_listar();
    });

    $('#tableNormal').on('click', 'span.icon-doc', function (e) {
        e.preventDefault();

        var oTable = $('#tableNormal').dataTable();
        row = $(this).parents('tr')[0];
        var ordenIntId = oTable.fnGetData(row)[1];
        $("#codorden").text(ordenIntId);
    });


    $("#btnRegDetalle").click(function (e) {
        e.preventDefault();

        registrar_detalle();
    });
});

var modal = function () {
  

    alert("hola");
    var name = $("div.portlet").find("input[class='exclusive']").val();
    alert(name);

}

var metodo_listar = function () {
    var oTable = $('#tableNormal').dataTable();
    var tipoint = $("#tipointervencion").val();
    var fecha = $("#fecha").val();

    $.get("http://localhost:55465/planificarintervencion/ListadoPlan", { dtFecha: fecha, nTipoInt: tipoint }, function (data, status) {

        oTable.fnClearTable();

        $.each(data, function (key, value) {
            oTable.fnAddData([value.cNombres, value.nOrdenIntervencionId, value.nTipoIntervencionId, value.cTipoIntNombre,
            value.cFecha, value.nCantMedicos, value.nCantReq,
                '<a > <span id="editSistema" class="icon-users"></span> </a>',
                '<a href="#basic" data-toggle="modal"> <span class="icon-doc"></span></a>'
            ]);
        });

        oTable.fnDraw();
    });
}

var registrar_detalle = function () {
    var descripcion = $("#descripcion").val();
    var cantidad = $("#cantidad").val();
    var ordenid = $("#codorden").text();

    toastr.options = {
        "closeButton": true,
        "debug": false,
        "positionClass": "toast-top-center",
        "onclick": null,
        "showDuration": "1000",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }

    if (descripcion == "") {
        toastr.error('', 'Ingrese Descripción');
    } else if (cantidad == "") {
        toastr.error('', 'Ingrese Cantidad');
    } else {
        $.get("http://localhost:55465/planificarintervencion/InsertarReqPlan", { nOrdenIntervencionId: ordenid, cRequisitoDesc: descripcion, nCantidad: cantidad }, function (data, status) {
            $("#descripcion").val("");
            $("#cantidad").val("");
            toastr.success('', 'Registro Satisfactorio');
            metodo_listar();
        });
    }
}