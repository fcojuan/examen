toastr.options = {
    "closeButton": false,
    "debug": false,
    "newestOnTop": false,
    "progressBar": false, /*se activae si de utilza el full- width*/
    "positionClass": "toast-top-center", /*toast-top-center  toast-top-left  toast-top-right   "toast-top-full-width",*/
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
}


window.MostrarToastr = (tipo, mensaje) => {
    if (tipo === "success") {
        toastr.options
        Command: toastr["success"](mensaje, "Operación Exitosa");
        //toastr.success(mensaje, "Operación Exitosa");
    }

    if (tipo === "info") {
        toastr.options
        Command: toastr["info"](mensaje, "Información");
    }

    if (tipo === "warning") {
        toastr.options
        Command: toastr["warning"](mensaje, "Error Preventivo");
    }

    if (tipo === "error") {
        toastr.options
        Command: toastr["error"](mensaje, "Operación Fallida");
    }
}

window.MostrarSwal = (tipo, mensaje) => {
    if (tipo === "success") {
        Swal.fire('Notificación Exitosa', mensaje, 'success')
    }

    //if (tipo === "info") {
    //    toastr.options
    //    Command: toastr["info"](mensaje, "Información");
    //}

    //if (tipo === "warning") {
    //    toastr.options
    //    Command: toastr["warning"](mensaje, "Error Preventivo");
    //}

    if (tipo === "error") {
        Swal.fire('Notificación Fallida', mensaje, 'error')
    }
}
/*--------------------------ENTER EN LOS INPUT------------------*/
window.onFocus = (id) => {
    var currInput = document.activeElement;
    if (currInput.tagName.toLowerCase() == "input") {
        var inputs = document.getElementsByTagName("input");
        var currInput = document.activeElement;
        for (var i = 0; i < inputs.length; i++) {
            if (inputs[i] == currInput) {
                var next = inputs[i + 1];
                if (next && next.focus) {
                    next.focus();
                }
                break;
            }
        }
    }
}
/*-------------------PONER EL FOCUS EN EL PRIMER INPUT*/
window.focusElement = (element) => {
    var elementToFocus = document.getElementById(element);
    elementToFocus.focus();
};
