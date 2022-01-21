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
        success: function (cartCountPlus1) {
            let cartIcon = document.getElementById('cart-icon');
            cartIcon.style.backgroundColor = 'lightgreen';
            cartIcon.textContent = cartCountPlus1;
        }
    });
};

function createCart() {
    $.ajax({
        type: 'GET',
        url: 'https://localhost:7206/api/cart/'
    });
};

function getCartCount() {
    $.ajax({
        type: 'GET',
        url: 'https://localhost:7206/api/cart/count',
        success: function (count) {
            let cartIcon = document.getElementById('cart-icon');

            if (count > 0) {
                cartIcon.style.backgroundColor = 'lightgreen';
                cartIcon.textContent = count;
            }
        }
    });
};



function isInt(n) {
    return n % 1 === 0;
}

let millisecondsToWait = 200;

setTimeout(function () {
    getCartCount();
}, millisecondsToWait);


