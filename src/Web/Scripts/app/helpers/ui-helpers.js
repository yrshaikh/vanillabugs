var UiHelpers = UiHelpers || {};

UiHelpers.dom = {
    scrollToDiv: function (className) {
        setTimeout(function () {
            $('.' + className)[0].scrollIntoView(true);
        });
    },
    focusElement: function (id) {
        setTimeout(function () {
            var element = window.document.getElementById(id);
            if (element)
                element.focus();
        });
    }
}

UiHelpers.pop = {
    showMessage: function (message) {
        swal(message);
    },
    showLoader: function (title, message) {
        swal({
            title: title,
            text: message,
            imageUrl: '/content/themes/base/images/loader.gif',
            showConfirmButton: false
        });
    },
    showSuccess: function (title, message, fn) {
        swal({ title: title, message: message, type: "success" }, function () {
            console.log("ok pressed", fn);
            fn.call();
        });
    },
    showError: function (title, message) {
        swal(title, message, "error");
    },
    close: function () {
        swal.close();
    }
}