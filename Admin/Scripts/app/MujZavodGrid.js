var MujZavod = MujZavod || {};

MujZavod.Grids = {};

MujZavod.GridLanguage = {
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
};

MujZavod.Grid = function (opts) {

    this.opts;
    this.table;

    this.addGrid = function (opts) {

        var gridOpts = {
            language: MujZavod.GridLanguage,

            columnDefs: [
                {
                    "targets": [0],
                    "visible": false,
                    "searchable": false
                }
            ],
            buttons: [
                'csv', 'excel', 'pdf'
            ]
        };

        if (opts.ajax != null) {
            gridOpts.ajax = opts.ajax;
        }

        if (opts.columns != null)
            gridOpts.columns = opts.columns;

        this.table = $('#' + opts.Id).DataTable(gridOpts);

        $('#' + opts.Id + '_wrapper .table-caption').text(opts.name);


        this.table.buttons().container()
            .appendTo('#' + opts.Id + '_wrapper .table-header .DT-lf-right');
        

        if (opts.addUrl != undefined && opts.addUrl != null && opts.addUrl != '') {
            var $btnAdd = $('<button class="btn btn-sm btn-info pull-left "><span class="btn-label-icon left fa fa-plus"></span>Přidat</button>');

            var that = this;
            $btnAdd.on('click', function () {
                new MujZavod.Modal().loadFromUrl(opts.addUrl, function (modal) {
                    that.refresh();
                    modal.close();
                });
            });
            $('#' + opts.Id + '_wrapper .table-header .DT-lf-right').append($btnAdd);
        }

        MujZavod.Grids[opts.Id] = this;
    }

    this.refresh = function () {
        this.table.ajax.reload();
    }

    this.addGrid(opts);



    
}