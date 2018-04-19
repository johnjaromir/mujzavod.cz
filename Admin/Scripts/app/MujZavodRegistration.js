var MujZavod = MujZavod || {};

MujZavod.Registration = function (opts) {
    this._opts = opts;
    this._wrapper = $(opts.wrapper);
    
    this._modal;

    this._registrationType;

    

    this.show = function () {
        
        var that = this;
        $(this._wrapper).on('click', function () {
            that._modal = new MujZavod.Modal();
            that._modal.loadFromUrl(that._opts.url + '/RaceRegistration/RegisterOnRace?raceKey=' + that._opts.raceKey);
            that._modal._footer.html('');
        });
    }

    this.setStepOne = function (type) {
        this._modal._footer.html('<button type="button" class="btn pull-left" data-wizard-action="prev">Zpět</button>'
            + '<button type="button" class="btn btn-primary pull-right" onclick="MujZavod.Registration.nextStep();">Další</button>');

        if (type != null)
            this._registrationType = type;

        this.getElem('#RegistrationTypeId').val(this._registrationType);

        if (this._registrationType == 1) {
            this.getElem('#mzStepTwo-1').show();
            this.getElem('#mzStepTwo-2').hide();
        }
        else {
            this.getElem('#mzStepTwo-2').show();
            this.getElem('#mzStepTwo-1').hide();

            var chckCreateAccount = this.getElem('#CreateAccount');

            var that = this;
            chckCreateAccount.on('click', function () {
                if ($(this).is(':checked'))
                    that.getElem('#mzDivCreateAccountPassword').show();
                else
                    that.getElem('#mzDivCreateAccountPassword').hide();
            });

            if (chckCreateAccount.is(':checked'))
                that.getElem('#mzDivCreateAccountPassword').show();
            else
                that.getElem('#mzDivCreateAccountPassword').hide();

        }
    }

    this.setStepTwo = function () {
        var that = this;
        if (this._registrationType == 1) {
            // ověříme login
            $.post(this._opts.url + '/RaceRegistration/CheckLogin', {
                email: this.getElem('#EmailLogin').val(),
                password: this.getElem('#PasswordLogin').val()
            }).done(function (ret) {
                if (ret.Success)
                    that.initStepThree(ret.User);
                else
                    that.showError(ret.Err);
            });
        }
        else {

            var empty = this.getElem('#divUserData').find("input").filter(function () {
                return this.value === "";
            });
            if (empty.length) {
                this.showError('Vyplňte prosím všechny položky');
            }
            else {
                // pokud chceme vytvořit účet, zkontrolujeme dostupnost přihlašovacího jména
                if (this.getElem('#CreateAccount').is(':checked')) {
                    if (this.getElem('#Password').val().length < 6) {
                        this.showError('Heslo musí mít minimálně 6 znaků');
                    }
                    else if (this.getElem('#Password').val() != this.getElem('#ConfirmPassword').val()) {
                        this.showError('Hesla se neshodují');
                    }
                    else {
                        $.post(this._opts.url + '/RaceRegistration/CheckFreeLogin', {
                            email: this.getElem('#Email').val()
                        }).done(function (ret) {
                            if (ret == "OK")
                                that.initStepThree();
                            else
                                that.showError(ret);
                        });
                    }
                }
                else
                    this.initStepThree();
            }
        }
        
    }

    this.initStepThree = function (user) {
        var genderId, birthDate;
        if (user != null) {
            genderId = user.EGenderId;
            birthDate = user.BirthDate;
        }
        else {
            genderId = this.getElem('#EGenderId').val();
            birthDate = this.getElem('#BirthDate').val();
        }

        this.renderSelectCategory(genderId, birthDate);

        var that = this;
        this.getElem('#RaceCategoryId').on('change', function () {
            that.renderSelectSubCategory(genderId, birthDate, $(this).val());
        });

        this.goNext();
    }

    this.renderSelectCategory = function (genderId, birthDate) {
        var that = this;
        $.post(this._opts.url + '/RaceRegistration/GetCategoryForUser', {
            raceKey: this._opts.raceKey,
            birthDate: birthDate,
            genderId: genderId
        })
        .done(function (data) {
            var dict = data;
            that.getElem('#RaceCategoryId').html('');
            that.getElem('#RaceCategoryId').append('<option>Vyberte kategorii</option>');
            for (var i = 0; i < dict.length; i++) {
                
                that.getElem('#RaceCategoryId').append('<option value=' + dict[i].key + '>' + dict[i].value + '</option>');
            }

        });
        
    }


    this.renderSelectSubCategory = function (genderId, birthDate, raceCategoryId) {
        var that = this;
        $.post(this._opts.url + '/RaceRegistration/GetSubCategoryForUser', {
            
            birthDate: birthDate,
            genderId: genderId,
            raceCategoryId: raceCategoryId
        })
            .done(function (data) {
                var dict = data;
                that.getElem('#RaceSubCategoryId').html('');
                that.getElem('#RaceSubCategoryId').append('<option>Vyberte podkategorii</option>');
                for (var i = 0; i < dict.length; i++) {
                    
                    that.getElem('#RaceSubCategoryId').append('<option value=' + dict[i].key + '>' + dict[i].value + '</option>');
                }

            });

    }


    this.Register = function () {
        if (this.getElem('#RaceCategoryId').val() == '') {
            this.showError('Vyberte kategorii');
        }
        else if (this.getElem('#RaceSubCategoryId').val() == '') {
            this.showError('Vyberte podkategorii');
        }
        else {

            var form = $(this._modal._body).find("form")[0];
            var that = this;
            if (form != null) {
                $.post(this._opts.url+'/RaceRegistration/RegisterOnRace', $(form).serialize(), function (data) {
                    if (data === "OK") {
                        that._modal._footer.html('');
                        that.goNext();
                    } else {
                        that._modal.parseData(data);
                    }

                });
            }

            
        }
    }



    this.goNext = function () {
        
        this.getElem('#mzWizard').pxWizard('goNext');
    }

    this.nextStep = function () {
        var actStep = this.getElem('#mzWizard').pxWizard('getActiveStepIndex');
        if (actStep == 1)
            this.setStepTwo();
        else if (actStep == 2)
            this.Register();
    }

    this.getElem = function (selector) {
        return this._modal._body.find(selector);
    }

    this.showError = function (msg) {
        MujZavod.Alert(msg);
    }

    this.show();

    MujZavod.Registration = this;
}