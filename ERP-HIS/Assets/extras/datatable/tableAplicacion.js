var TableAplicacion = function () {

    var tableNoPaging1 = function () {

        if ($.fn.dataTable.isDataTable('#tableNoPaging1')) {
            table = $('#tableNoPaging1').DataTable();
            return;
        }
        else {
            table = $('#tableNoPaging1');
        }
        var table = $('#tableNoPaging1');

        /* Fixed header extension: http://datatables.net/extensions/scroller/ */

        var oTable = table.dataTable({
            "paging": false,
            "bLengthChange": false,
            "ordering": false,
            "searching": false,
            "language": {
                "aria": {
                    "sortAscending": ": activate to sort column ascending",
                    "sortDescending": ": activate to sort column descending"
                },
                "emptyTable": "No se encontraron registros",
                "info": "     ",
                "infoEmpty": "    ",
                "infoFiltered": "(filtered1 from _MAX_ total entries)",
                "lengthMenu": "Show _MENU_",
                "search": "Search:",
                "zeroRecords": "No matching records found"
            },
            "deferRender": true,
            "order": [
                [0, 'asc']
            ],
            "lengthMenu": [
                [5, 10, 15, 20, -1],
                [5, 10, 15, 20, "All"] // change per page values here
            ],
            "pageLength": 5, // set the initial value
            //responsive: true,// setup responsive extension: http://datatables.net/extensions/responsive/
            "aoColumnDefs": [{
                "bSortable": false,
                "aTargets": ['nosort']
            },
            {
                "bVisible": false,
                "aTargets": ['novis']
            },
            ]
        });
    }

    var tableNoPaging= function () {

        if ($.fn.dataTable.isDataTable('#tableNoPaging')) {
            table = $('#tableNoPaging').DataTable();
            return;
        }
        else {
            table = $('#tableNoPaging');
        }
        var table = $('#tableNoPaging');

        /* Fixed header extension: http://datatables.net/extensions/scroller/ */

        var oTable = table.dataTable({
            "paging" : false,
            "bLengthChange": false,
            "ordering": false,
            "searching": false,
            "language": {
                "aria": {
                    "sortAscending": ": activate to sort column ascending",
                    "sortDescending": ": activate to sort column descending"
                },
                "emptyTable": "No se encontraron registros",
                "info": "     ",
                "infoEmpty": "    ",
                "infoFiltered": "(filtered1 from _MAX_ total entries)",
                "lengthMenu": "Show _MENU_",
                "search": "Search:",
                "zeroRecords": "No matching records found"
            },
            "deferRender": true,
            "order": [
                [0, 'asc']
            ],
            "lengthMenu": [
                [5, 10, 15, 20, -1],
                [5, 10, 15, 20, "All"] // change per page values here
            ],
            "pageLength": 5, // set the initial value
            //responsive: true,// setup responsive extension: http://datatables.net/extensions/responsive/
            "aoColumnDefs": [{
                "bSortable": false,
                "aTargets": ['nosort']
            },
            {
                "bVisible": false,
                "aTargets": ['novis']
            },
            ]
        });
    }
	
	 var tableNormal = function () {

		 if ( $.fn.dataTable.isDataTable('#tableNormal') ) {
	    	    table = $('#tableNormal').DataTable();
	    	    return;
	    	}
	    	else {
	    	    table = $('#tableNormal');
	    	}
	        var table = $('#tableNormal');

	        /* Fixed header extension: http://datatables.net/extensions/scroller/ */

            var oTable = table.dataTable({
                "bLengthChange": false,
                "ordering": false,
                "searching": false,
	        	"language": {
	                "aria": {
	                    "sortAscending": ": activate to sort column ascending",
	                    "sortDescending": ": activate to sort column descending"
	                },
                    "emptyTable": "No se encontraron registros",
                    "info": "Total registros:  _TOTAL_ / Mostrados: _START_ a _END_",
	                "infoEmpty": "No se encontraron registros",
	                "infoFiltered": "(filtered1 from _MAX_ total entries)",
                    "lengthMenu": "Show _MENU_",
                    "search": "Search:",
	                "zeroRecords": "No matching records found"
	            },
	            "deferRender": true,
	            "order": [
	                [0, 'asc']
	            ],
	            "lengthMenu": [
	                [5, 10, 15 ,20, -1],
	                [5, 10, 15 ,20, "All"] // change per page values here
	            ],
	            "pageLength": 5 , // set the initial value
	            //responsive: true,// setup responsive extension: http://datatables.net/extensions/responsive/
	            "aoColumnDefs": [{
	                "bSortable": false,
	                "aTargets": ['nosort']
	            },
	            {
	            	"bVisible": false,
	                "aTargets": ['novis']
	            },
	            ]           
	        });
	    }
	 
	 var tableReporte = function () {

		 if ( $.fn.dataTable.isDataTable('#tableReporte') ) {
	    	    table = $('#tableReporte').DataTable();
	    	    return;
	    	}
	    	else {
	    	    table = $('#tableReporte');
	    	}
	        var table = $('#tableReporte');

	        /* Fixed header extension: http://datatables.net/extensions/scroller/ */

	        var oTable = table.dataTable({
	        	"paging":   false,
	            "ordering": false,
	            "searching": false,
	        	"language": {
	                "aria": {
	                    "sortAscending": ": activate to sort column ascending",
	                    "sortDescending": ": activate to sort column descending"
	                },
	                "emptyTable": "No data available in table",
	                "info": "Showing _START_ to _END_ of _TOTAL_ entries",
	                "infoEmpty": "No entries found",
	                "infoFiltered": "(filtered1 from _MAX_ total entries)",
	                "lengthMenu": "_MENU_ entries",
	                "zeroRecords": "No matching records found"
	            },
	            "deferRender": true,
	            "order": [
	                [0, 'asc']
	            ],
	            "lengthMenu": [
	                [5, 10, 15 ,20, -1],
	                [5, 10, 15 ,20, "All"] // change per page values here
	            ],
	            "pageLength": 5 , // set the initial value
	            //responsive: true,// setup responsive extension: http://datatables.net/extensions/responsive/
	            "aoColumnDefs": [{
	                "bSortable": false,
	                "aTargets": ['nosort']
	            },
	            {
	            	"bVisible": false,
	                "aTargets": ['novis']
	            },
	            ]           
	        });
	    }
	 
	 var tableBuscarProducto= function () {

		 if ( $.fn.dataTable.isDataTable('#tableBuscarProducto') ) {
	    	    table = $('#tableBuscarProducto').DataTable();
	    	    return;
	    	}
	    	else {
	    	    table = $('#tableBuscarProducto');
	    	}
	        var table = $('#tableBuscarProducto');

	        /* Fixed header extension: http://datatables.net/extensions/scroller/ */

	        var oTable = table.dataTable({
                "paging": false,
                "ordering": false,
                "searching": false,
	            "info":     false,
	        	"language": {
	                "aria": {
	                    "sortAscending": ": activate to sort column ascending",
	                    "sortDescending": ": activate to sort column descending"
	                },
	                "emptyTable": "No se encuentran registros",
	                "info": "Showing _START_ to _END_ of _TOTAL_ entries",
	                "infoEmpty": "No entries found",
	                "infoFiltered": "(filtered1 from _MAX_ total entries)",
	                "lengthMenu": "_MENU_ entries",
	                "zeroRecords": "No matching records found"
	            },
	            "deferRender": true,
	            "order": [
	                [0, 'asc']
	            ],
	            //responsive: true,// setup responsive extension: http://datatables.net/extensions/responsive/
	            "aoColumnDefs": [{
	                "bSortable": false,
	                "aTargets": ['nosort']
	            },
	            {
	            	"bVisible": false,
	                "aTargets": ['novis']
	            }
	            ]           
	        });
	    }
	 
	 var tableFactura= function () {

		 if ( $.fn.dataTable.isDataTable('#tableFactura') ) {
	    	    table = $('#tableFactura').DataTable();
	    	    return;
	    	}
	    	else {
	    	    table = $('#tableFactura');
	    	}
	        var table = $('#tableFactura');

	        /* Fixed header extension: http://datatables.net/extensions/scroller/ */

	        var oTable = table.dataTable({
	        	
	        	   "footerCallback": function ( row, data, start, end, display ) {
	                   var api = this.api(), data;
	        
	                   // Remove the formatting to get integer data for summation
	                   var intVal = function ( i ) {
	                       return typeof i === 'string' ?
	                           i.replace(/[\$,]/g, '')*1 :
	                           typeof i === 'number' ?
	                               i : 0;
	                   };
	        
	                   // Total over all pages
	                   total = api
	                       .column(2)
	                       .data()
	                       .reduce( function (a, b) {
	                           return intVal(a) + intVal(b);
	                       }, 0 );
	        
	                   // Total over this page
	                   precioTotal = api
	                       .column( 5, { page: 'current'} )
	                       .data()
	                       .reduce( function (a, b) {
	                           return intVal(a) + intVal(b);
	                       }, 0 );
	                   
	                   rentaAdelantada = api
                       .column( 9, { page: 'current'} )
                       .data()
                       .reduce( function (a, b) {
                           return intVal(a) + intVal(b);
                       }, 0 );
	                   var total = 0;
	                   if($.isNumeric(rentaAdelantada))
	                   {
	                	   total = precioTotal + rentaAdelantada;
	                   }
	                   else
	                   {
	                	   total = precioTotal;   
	                   }
	                   
	                  
	                   // Update footer
	                   $( api.column(5).footer() ).html(
	                       'S/.'+ total.toFixed(2) + ' total'
	                   );
	               },
	        	"paging":   false,
	            "ordering": false,
	            "info":     false,
	        	"language": {
	                "aria": {
	                    "sortAscending": ": activate to sort column ascending",
	                    "sortDescending": ": activate to sort column descending"
	                },
	                "emptyTable": "No se encuentran registros",
	                "info": "Showing _START_ to _END_ of _TOTAL_ entries",
	                "infoEmpty": "No entries found",
	                "infoFiltered": "(filtered1 from _MAX_ total entries)",
	                "lengthMenu": "_MENU_ entries",
	                "zeroRecords": "No matching records found"
	            },
	            "deferRender": true,
	            "order": [
	                [0, 'asc']
	            ],
	            //responsive: true,// setup responsive extension: http://datatables.net/extensions/responsive/
	            "aoColumnDefs": [{
	                "bSortable": false,
	                "aTargets": ['nosort']
	            },
	            {
	            	"bVisible": false,
	                "aTargets": ['novis']
	            }
	            ]           
	        });
	    }

    return {

        //main function to initiate the module
        init: function () {

            if (!jQuery().dataTable) {
                return;
            }
            tableNormal();
            tableBuscarProducto();
            tableFactura();
            tableReporte();
            tableNoPaging();
            tableNoPaging1();
        }

    };
}();
if (App.isAngularJsApp() === false) { 
    jQuery(document).ready(function() {
    	TableAplicacion.init();
    });
}