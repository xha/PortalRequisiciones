$(document).on('ajaxStart', function () {
    loading_show();
})

$(document).on('ajaxStop', function (start) {
    loading_hide();
})

function solo_enteros(e) {
    var tipo = e.keyCode;
    //if ((tipo == 8) || (tipo == 9) || (tipo == 116) || (tipo == 46)) return true; // BACKSPACE, TAB, F5, DELETE
    var regex = new RegExp("^[0-9]+$");
    var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(str)) {
        return true;
    }
    e.preventDefault();
    return false
}

function solo_numeros(e) {
    var tipo = e.keyCode;
    //if ((tipo == 8) || (tipo == 9) || (tipo == 116) || (tipo == 46)) return true; // BACKSPACE, TAB, F5, DELETE
    var regex = new RegExp("^[0-9.]+$");
    var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(str)) {
        return true;
    }
    e.preventDefault();
    return false
}

function solo_alfanumericos(e) {
    var tipo = e.keyCode;
    //if ((tipo == 8) || (tipo == 9) || (tipo == 116) || (tipo == 46)) return true; // BACKSPACE, TAB, F5, DELETE
    var regex = new RegExp("^[a-zA-ZñÑ.0-9@\ \-]+$");
    var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(str)) {
        return true;
    }

    e.preventDefault();
    return false
}

function valida_cantidad(campo) {
    var cantidad = $("#" + campo)[0];
    var i;
    var aux = 0;

    for (i = 0; i < cantidad.value.length; i++) {
        if (cantidad.value.charAt(i) == '.') {
            aux++;
        }
    }

    if (aux > 1) {
        cantidad.value = Math.round((cantidad.value.slice(0, (cantidad.value.length - 1))) * 100) / 100;
    }
}

function solo_decimal(e, valor) {
    var tipo = e.keyCode;
    //if ((tipo == 8) || (tipo == 9) || (tipo == 116) || (tipo == 46)) return true; // BACKSPACE, TAB, F5, DELETE
    var regex = new RegExp("^[0-9.]+$");
    var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    var tempValue = valor.value + str;
    if (regex.test(str)) {
        if (filter(tempValue)) return true;
    }
    e.preventDefault();
    return false;
}

function filter(__val__) {
    var preg = /^([0-9]+\.?[0-9]{0,4})$/;
    if (preg.test(__val__) === true) {
        return true;
    } else {
        return false;
    }
}

function convertir_float(valor) {
    var temp = "";
    temp = valor.replace(".", "");
    temp = parseFloat(temp.replace(",", "."));

    return temp;
}

function MostrarMensaje(Tipo, Mensaje) {
    toastr.options = {
        closeButton: true,
        progressBar: true,
        preventDuplicates: true,
        preventOpenDuplicates: true,
        showMethod: 'slideDown',
        timeOut: 4000,
        positionClass: "toast-bottom-center",
    };

    switch (Tipo) {
        case "Verde":
            toastr.success(Mensaje, "Procesado");
            break;

        case "Amarillo":
            toastr.warning(Mensaje, "Alerta");
            break;

        case "Rojo":
            toastr.error(Mensaje, "Alerta");
            break;

        case "Azul":
            toastr.info(Mensaje, "Información");
            break;
    }
}

function loading_show() {
    $('body').loadingModal({
        text: 'Por favor espere',
        animation: 'circle',
    });
    $('body').loadingModal('show');
}

function loading_hide() {
    $('body').loadingModal('hide');
}

function textCounter(f, c, maxlimit) {
    var field = $("#" +f)[0];
    var countfield = $("#" + c)[0];
    if (field.value.length > maxlimit) {// if too long...trim it!
        field.value = field.value.substring(0, maxlimit);
        // otherwise, update 'characters left' counter
    } else {
        countfield.value = maxlimit - field.value.length;
    }
}