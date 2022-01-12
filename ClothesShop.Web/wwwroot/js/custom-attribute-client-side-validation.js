jQuery.validator.addMethod("price",
    function (value, element, param) {

        let minPrice = Number(element.attributes["data-val-price-minprice"].value);
        let maxPrice = Number(element.attributes["data-val-price-maxprice"].value);

        if (Number(value) <= minPrice || Number(value) > maxPrice) {
            return false;
        }
        else {
            return true;
        }
    });

jQuery.validator.unobtrusive.adapters.addBool("price");
