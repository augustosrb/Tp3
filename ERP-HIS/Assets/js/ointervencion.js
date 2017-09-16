$(document).ready(function () {

    var cod_categoria = null;
    var row = null;
   

    //carga inicial
    cargar_combo_estado();

    //Metodos
    $("#btnRegistrarOrden").click(function (e) {
        e.preventDefault();

        doc = $("#documento").val();

        sede = $("#cboSede").val();
        sala = $("#cboSala").val();
        zona = $("#cboZona").val();
        habreposo = $("#cboHabReposo").val();

        $.get("http://localhost:55465/ointervencion/registrarOrden", { habreposo: habreposo, nOrdenMedId: 1 }, function (data, status) {

            toastr.success("", 'Registro Exitoso');
        });
    });


    
    //Metodos
    $("#btnConsultarOM").click(function (e) {
        e.preventDefault();

        metodo_listar();
    });
    
    $("#buscarPaciente").click(function (e) {
        e.preventDefault();

        var dni = $("#documento").val();

        //alert(dni);

        if (dni === "") {
            toastr.info("Ingrese un documento", 'Campo Vacío');
        }
        else
        {
             var oTable = $('#tableNoPaging').dataTable();

             $.get("http://localhost:55465/ointervencion/buscarPaciente", { dni: dni }, function (data, status) {

                 $.each(data, function (key, value) {
                  
                         $('[name=' + key + ']', '#form_datos_paciente').val(value);

                         if (key == 'lstOrdenMedica') {

                             oTable.fnClearTable();
                             $.each(data.lstOrdenMedica, function (key, value) {
                                 oTable.fnAddData([value.nOrdenMedId, value.cIdOrden, value.cSexo, value.cFechaIntervencion, value.cTipoIntNombre,
                                     '<input type="checkbox" class="checkboxes" value="1" />'
                                 ]);
                             });

                             oTable.fnDraw();
                         }

                         cargar_combo_sede();
                 });
            });
        }
    });

    $("#cboSede").on('change', function () {
       // alert(this.value);

        var name = "cboZona";
        var option_combo = "";

        $.get("http://localhost:55465/ambiente/ListadoZona", { nAmbienteId : this.value},function (result, status) {

            $('select[name="' + name + '"] option').remove();

            option_combo += "<option value='0'>::Seleccione</option>";

            $.each(result, function (key, value) {
                option_combo += "<option value=" + value.nAmbienteId + ">" + value.cAmbienteNombre + "</option>";
            });

            $('select[name="' + name + '"]').append(option_combo);

        });
    });
    $("#cboZona").on('change', function () {
        // alert(this.value);

        var name = "cboSala";
        var option_combo = "";

        $.get("http://localhost:55465/ambiente/ListadoSala", { nAmbienteId: this.value }, function (result, status) {

            $('select[name="' + name + '"] option').remove();

            option_combo += "<option value='0'>::Seleccione</option>";

            $.each(result, function (key, value) {
                option_combo += "<option value=" + value.nAmbienteId + ">" + value.cAmbienteNombre + "</option>";
            });

            $('select[name="' + name + '"]').append(option_combo);

        });
    });
    $("#cboSala").on('change', function () {
        // alert(this.value);

        var name = "cboHabReposo";
        var option_combo = "";

        $.get("http://localhost:55465/ambiente/ListadoHabitacionRep", { nAmbienteId: this.value }, function (result, status) {

            $('select[name="' + name + '"] option').remove();

            option_combo += "<option value='0'>::Seleccione</option>";

            $.each(result, function (key, value) {
                option_combo += "<option value=" + value.nAmbienteId + ">" + value.cAmbienteNombre + "</option>";
            });

            $('select[name="' + name + '"]').append(option_combo);

        });
    });
});

var cargar_combo_estado = function () {

    var name = "cboEstado";
    var option_combo = "";

    $.get("http://localhost:55465/maestro/ListadoEstadoClinica", function (result, status) {

        $('select[name="' + name + '"] option').remove();

        option_combo += "<option value='0'>::Seleccione</option>";

        $.each(result, function (key, value) {
            option_combo += "<option value=" + value.nItemId + ">" + value.cMaestroDescripcion + "</option>";
        });

        $('select[name="' + name + '"]').append(option_combo);

    });

}
var metodo_listar = function () {
    
    var oTable = $('#tableNormal').dataTable();
    var documento = $('#documento').val();
    var estado = $('#cboEstado').val();

    $.get("http://localhost:55465/ointervencion/ListadoOrden", { documento: documento , estado : estado } , function (data, status) {

        oTable.fnClearTable();

        $.each(data, function (key, value) {
            oTable.fnAddData([value.nOrdenIntervencionId, value.cIdIntervencion,
                value.cNomCompleto, value.cNroDocumento, value.cSede, value.cTipoIntNombre, value.cFechaIntervencion,
                value.cEstado,
            '<a><span id="editSistema" class="icon-pencil"></span> </a>',
            '<a> <span  class="icon-close"></span></a>'
            ]);
        });

        oTable.fnDraw();
    });
}

var cargar_combo_sede = function () {
    var name = "cboSede";

    var option_combo = "";

    $.get("http://localhost:55465/ambiente/ListadoSede", function (result, status) {

        $('select[name="' + name + '"] option').remove();

        option_combo += "<option value='0'>::Seleccione</option>";

        $.each(result, function (key, value) {
            option_combo += "<option value=" + value.nAmbienteId + ">" + value.cAmbienteNombre + "</option>";
        });

        $('select[name="' + name + '"]').append(option_combo);

    });

}