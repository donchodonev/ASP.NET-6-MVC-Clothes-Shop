$(document).ready(function () {
    $('#addProduct')[0].reset();
});

let elements = document.getElementsByClassName('sizeInput');

function onChange() {
    let el = document.getElementById("quantitySpan");
    el.textContent = "";
};