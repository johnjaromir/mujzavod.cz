var MujZavod = MujZavod || {};

MujZavod.Modals = MujZavod.Modals || [];

MujZavod.Modal = function (size) {
    this._callBack;

    this._modal;
    this._title;
    this._body;
    
    this._footer;

    this.size = size || 'md';

    this.showModal = function () {
        this._modal = $('<div class="modal fade in" id="modal-base" tabindex="-1" style="display: block;">'
            +'<div class="modal-dialog modal-'+this.size+'" >'
            +'<div class="modal-content">'
            +    '<div class="modal-header">'
            +        '<button type="button" class="close" data-dismiss="modal">×</button>'
            +'        <h4 class="modal-title" id="myModalLabel"></h4>'
            +'    </div>'
            +'    <div class="modal-body">'
            
            +      '</div>'
            +       '<div class="modal-footer">'
            +            '<button type="button" class="btn" data-dismiss="modal">Zavřít</button>'
                        
            + '</div></div></div>');

        this._title = this._modal.find('.modal-title');
        this._body = this._modal.find('.modal-body');
        this._footer = this._modal.find('.modal-footer');

        

        $(this._modal).on('hidden.bs.modal', function (e) {
            $(this).remove();
            MujZavod.Modals.pop();
            if (MujZavod.Modals.length > 0)
                $(document.body).addClass("modal-open");
        })

        $(this._modal).on('show.bs.modal', function (e) {
            MujZavod.Modals.push(this);
        })

        $(this._modal).modal('show');
    }


    this.setBody = function (msg) {
        this._body.html(msg);
    }

    this.setTitle = function (title) {
        _title.html(title);
    }

    this.setFooter = function (footer) {
        _footer.html(footer);
    }


    this.loadFromUrl = function (url, callBack) {
        var that = this;
        this._callBack = callBack;

        $.get(url, function (data) {
            that.parseData(data);
            that.setFooterSubmit();
        });

        
    }


    this.parseData = function (data) {
        this.setBody(data);

        var title = $(data).find('[data-mz-modal-title]');
        if (title != null) {
            this._title.html('');
            this._title.append(title);
            this._body.find('[data-mz-modal-title]').remove();
        }
    }

    this.submit = function () {
        var that = this;
        var form = $(this._body).find("form")[0];

        if (form != null) {
            $.post(form.action, $(form).serialize(), function (data) {
                if (data === "OK") {
                    if ($.isFunction(that._callBack)) {
                        that._callBack(that);
                    }
                } else {
                    that.parseData(data);
                }

            });
        }
    }


    this.close = function () {
        $(this._modal).modal('hide');
    }


    this.setFooterSubmit = function () {
        var btn = $('<button type="button" class="btn btn-primary">Uložit</button>');
        var that = this;
        $(btn).on('click', function (e) {
            that.submit();
            e.preventDefault();
        });

        this._footer.append(btn);
    }


    this.showModal();
    
}