let elements = document.getElementsByClassName('sizeInput');

function onChange() {
    let el = document.getElementById("quantitySpan");
    el.textContent = "";
};

function addToCart(data) {
    $.ajax({
        type: 'POST',
        contentType: 'application/json',
        url: 'https://localhost:7206/api/cart/',
        data: JSON.stringify(data),
        dataType: 'json',
        success: function () {
            console.log("success")
        }
    });
};

function createCart() {
    $.ajax({
        type: 'GET',
        url: 'https://localhost:7206/api/cart/'
    });
};