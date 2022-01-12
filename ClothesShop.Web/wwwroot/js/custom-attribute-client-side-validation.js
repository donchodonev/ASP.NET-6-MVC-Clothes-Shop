jQuery.validator.addMethod("price",
    function (value, element, param) {

        if (Number(value) <= 0 || Number(value) > 79228162514264337593543950335) {
            return false;
        }
        else {
            return true;
        }
    });

jQuery.validator.unobtrusive.adapters.addBool("price");
