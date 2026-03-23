// ================= INIT =================

$(document).ready(function () {
    loadCart();
    updateCartCount();
});


// ================= LOAD CART =================

function loadCart() {

    let cart = getCart();

    let html = "";
    let total = 0;

    // ✅ EMPTY CART
    if (cart.length === 0) {

        $("#cartItems").html(`
        <tr>
            <td colspan="4" class="text-center">
                <div class="p-4">
                    <h5>Your cart is empty 🛒</h5>
                    <a href="products.html" class="btn btn-primary mt-2">Shop Now</a>
                </div>
            </td>
        </tr>
        `);

        $("#total").text("0");

        $("#checkoutBtn").prop("disabled", true);

        return;
    }

    $("#checkoutBtn").prop("disabled", false);

    cart.forEach((item, index) => {

        let qty = item.qty || 1;
        let price = item.price || 0;

        total += price * qty;

        html += `
        <tr class="align-middle text-center">

            <td class="fw-semibold">${item.name}</td>

            <td>
                <div class="d-flex justify-content-center align-items-center gap-2">

                    <button class="btn btn-outline-secondary btn-sm minus" data-index="${index}">−</button>

                    <span class="fw-bold">${qty}</span>

                    <button class="btn btn-outline-secondary btn-sm plus" data-index="${index}">+</button>

                </div>
            </td>

            <td class="text-success fw-bold">₹${price}</td>

            <td>
                <button class="btn btn-danger btn-sm remove" data-index="${index}">
                    Remove
                </button>
            </td>

        </tr>
        `;
    });

    $("#cartItems").html(html);
    $("#total").text(total);
}


// ================= EVENTS =================

// ➕ Increase Quantity
$(document).on("click", ".plus", function () {

    let index = $(this).data("index");
    let cart = getCart();

    if (!cart[index]) return;

    if (cart[index].qty < 10) {
        cart[index].qty++;
    }

    updateCart(cart);
});


// ➖ Decrease Quantity
$(document).on("click", ".minus", function () {

    let index = $(this).data("index");
    let cart = getCart();

    if (!cart[index]) return;

    if (cart[index].qty > 1) {
        cart[index].qty--;
    }

    updateCart(cart);
});


// ❌ Remove Item
$(document).on("click", ".remove", function () {

    let index = $(this).data("index");
    let cart = getCart();

    if (!cart[index]) return;

    cart.splice(index, 1);

    updateCart(cart);
});


// ================= HELPER =================

function updateCart(cart) {
    saveCart(cart);
    loadCart();
    updateCartCount();
}