var MujZavod = MujZavod || {};

MujZavod.Registration = function (opts) {
    this._opts = opts;
    this._wrapper = $('#'+opts.wrapper);
    this._btn;

    this.show = function () {
        this._wrapper.append($('<button>Přihlásit</button>'));
        this._btn = this._wrapper.find('button');

        $(this._btn).on('click', function () {
            new MujZavod.Modal().setBody('test');
        });
    }

    this.show();
}