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
    return false
}

function filter(__val__) {
    var preg = /^([0-9]+\.?[0-9]{0,3})$/;
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