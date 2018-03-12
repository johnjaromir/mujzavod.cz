var MujZavod = MujZavod || {};

MujZavod.Grids = {};

MujZavod.Grid = function (opts) {

    this.opts;
    this.table;

    this.addGrid = function (opts) {
        this.table = $('#' + opts.Id).DataTable({
            ajax: opts.ajax, columns: opts.columns,
            language: {
                "sEmptyTable": "Tabulka neobsahuje žádná data",
                "sInfo": "Zobrazuji _START_ až _END_ z celkem _TOTAL_ záznamů",
                "sInfoEmpty": "Zobrazuji 0 až 0 z 0 záznamů",
                "sInfoFiltered": "(filtrováno z celkem _MAX_ záznamů)",
                "sInfoPostFix": "",
                "sInfoThousands": " ",
                "sLengthMenu": "Zobraz záznamů _MENU_",
                "sLoadingRecords": "Načítám...",
                "sProcessing": "Provádím...",
                "sSearch": "Hledat:",
                "sZeroRecords": "Žádné záznamy nebyly nalezeny",
                "oPaginate": {
                    "sFirst": "První",
                    "sLast": "Poslední",
                    "sNext": "Další",
                    "sPrevious": "Předchozí"
                },
                "oAria": {
                    "sSortAscending": ": aktivujte pro řazení sloupce vzestupně",
                    "sSortDescending": ": aktivujte pro řazení sloupce sestupně"
                }
            },

            columnDefs: [
                {
                    "targets": [0],
                    "visible": false,
                    "searchable": false
                }
                ]
        });

        $('#' + opts.Id + '_wrapper .table-caption').text(opts.name);

        MujZavod.Grids[opts.Id] = this;
    }

    this.refresh = function (gridId) {
        this.table.ajax.reload();
    }

    this.addGrid(opts);



    
}