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

            cartIcon.textContent = count;
        }
    });
};

function increaseProductQuantity(productKey) {

    let data = { key: productKey };

    $.ajax({
        type: 'POST',
        contentType: 'application/json',
        url: 'https://localhost:7206/api/cart/increaseProductCount',
        data: JSON.stringify(data),
        dataType: 'json',
        success: function (productCountAndTotal) {
            let result = JSON.parse(JSON.stringify(productCountAndTotal));
            let countSpan = document.getElementById(productKey + '-count');
            let totalPriceSpan = document.getElementById(productKey + '-totalPrice');
            countSpan.textContent = ` ${result.count} `;
            totalPriceSpan.textContent = `${result.total.toFixed(2)}`;
        }
    });
};

function decreaseProductQuantity(productKey) {

    let data = { key: productKey };

    $.ajax({
        type: 'POST',
        contentType: 'application/json',
        url: 'https://localhost:7206/api/cart/decreaseProductCount',
        data: JSON.stringify(data),
        dataType: 'json',
        success: function (productCountAndTotal) {
            let result = JSON.parse(JSON.stringify(productCountAndTotal));
            let countSpan = document.getElementById(productKey + '-count');
            let totalPriceSpan = document.getElementById(productKey + '-totalPrice');
            countSpan.textContent = ` ${result.count} `;
            totalPriceSpan.textContent = `${result.total.toFixed(2)}`;
        },
        error: function () {
            window.location.reload();
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


