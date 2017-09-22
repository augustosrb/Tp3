$(document).ready(function () {

    var row = null;
	
    $('#btnRegistrarSOAP').click(function () {

        hc = $("#historiaClinica").val();
        subjetivo = $("#txtSubjetivo").val();
        apre = $("#txtAApreciacion").val();
        
        if (hc == null && subjetivo == null && apre == null) {
            $.get("http://localhost:55465/actualizarpostope/registrarPostOpe",
                { nHistoriaClinica: hc, cSubjetivo: subjetivo, cApreciacion: apre },
                function (result, status) {
                    toastr.success("", 'Registro Exitoso');

                });
        }
        else
        {
                toastr.error("", 'Ingrese todos los campos.');
        }
    });

    $('#btnAgregarAct').click(function () {
        $("#txtActividad").val("");
        $("#chkMañana").prop('checked', false);
        $("#chkTarde").prop('checked', false);
        $("#chkNoche").prop('checked', false);
    });


    $('#agregarActividad').click(function () {
        var table = $('#tableNoPaging1').DataTable();

        var txtActividad = $("#txtActividad").val();

        var chkMañana = "";
        var chkTarde = "";
        var chkNoche = "";

        if ($('#chkMañana').is(":checked")) {
            var chkMañana = $("#chkMañana").val();
        }
        if ($('#chkTarde').is(":checked")) {
            var chkTarde = $("#chkTarde").val();
        }
        if ($('#chkNoche').is(":checked")) {
            var chkNoche = $("#chkNoche").val();
        }



        

       

        $('input:checkbox:checked').val(); 


        table.row.add([
            txtActividad,
            chkMañana + ' ' + chkTarde + ' ' + chkNoche]
        ).draw();
    });

    $('#txtAApreciacion').change(function () {

        var input = $("#txtAApreciacion").val();
        //alert(input);
        var pclave1 = "sangre";
        var pclave2 = "rojo";
        var pclave3 = "dolor";
        var pclave4 = "fiebre";

        var npclave1 = input.search(pclave1);
        var npclave2 = input.search(pclave2);
        var npclave3 = input.search(pclave3);
        var npclave4 = input.search(pclave4);

        if (npclave1 != -1 || npclave2 != -1 || npclave3 != -1 || npclave4 != -1) {
            $('#chkEstable').prop('checked', false);
            $('#chkRiesgoso').prop('checked', true);    
        }
        else
        {
            $('#chkEstable').prop('checked', true);
            $('#chkRiesgoso').prop('checked', false); 
        }
    });

    //Metodos
    $("#buscarxHistoria").click(function (e) {
        e.preventDefault();

        var historiaClinica = $("#historiaClinica").val();

        $.get("http://localhost:55465/actualizarpostope/buscarPacienteHistoria", { hc: historiaClinica }, function (result, status) {

            $.each(result, function (key, value) {
                //alert('[name=' + key + ']' + ' ' + value);
                $('[name=' + key + ']', '#form_datos_pacientexhc').val(value);
                
            });
        });
    });

    $("#obtenerDatos").click(function (e) {
        e.preventDefault();
        var servicioActivo = 0;

        $.ajax({
            url: "http://localhost:49238/home/ListadoResultados",
            success: function (data) {
                servicioActivo = 1;
                //alert(data);

                var oTable = $('#tableNoPaging').dataTable();

                oTable.fnClearTable();
                $.each(data, function (key, value) {
                    oTable.fnAddData([value.cDato, value.cValor, value.cEstado, value.cRangos
                    ]);
                });

                oTable.fnDraw();
            },
            error: function (xhr, ajaxOptions, thrownError) {
                if (xhr.status == 404) {
                    alert(thrownError);
                }
                if (servicioActivo == 0) {
                    toastr.warning("", 'Servicio Inactivo');
                    var oTable = $('#tableNoPaging').dataTable();

                    oTable.fnClearTable();
                    

                    oTable.fnDraw();
                }
            }
        });
    });
});