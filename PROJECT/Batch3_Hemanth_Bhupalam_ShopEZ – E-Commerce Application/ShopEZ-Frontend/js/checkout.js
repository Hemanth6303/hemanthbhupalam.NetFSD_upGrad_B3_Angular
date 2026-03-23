$(document).ready(function () {

    loadOrderSummary();

    $("#checkoutForm").submit(function (e) {

        e.preventDefault();

        let name = $("input[placeholder='Full Name']").val().trim();
        let email = $("input[type='email']").val().trim().toLowerCase();
        let address = $("textarea").val().trim();
        let payment = $("input[name='payment']:checked").val();

        let cart = getCart();

        // ✅ CART EMPTY CHECK
        if (cart.length === 0) {
            showMessage("Your cart is empty 🛒", "warning");
            return;
        }

        // ✅ REQUIRED FIELDS
        if (name === "" || email === "" || address === "") {
            showMessage("Please fill all fields ❗", "danger");
            return;
        }

        // ✅ NAME VALIDATION
        let namePattern = /^[a-zA-Z ]{3,}$/;
        if (!namePattern.test(name)) {
            showMessage("Enter valid name (only letters, min 3 chars)", "warning");
            return;
        }

        // ✅ EMAIL VALIDATION
        let emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailPattern.test(email)) {
            showMessage("Enter a valid email address ❗", "danger");
            return;
        }

        // ✅ ADDRESS VALIDATION
        if (address.length < 10) {
            showMessage("Address must be at least 10 characters ❗", "warning");
            return;
        }
        //PAYMENT VALIDATION
        if (!payment) {
               showMessage("Please select payment method ❗", "warning");
                return;
        }

        // ✅ SUCCESS
        showMessage("Order placed successfully 🎉", "success");

        // ✅ CLEAR CART
        try {
            localStorage.removeItem("cart");
        } catch (error) {
            console.error("Error clearing cart:", error);
        }

        updateCartCount();

        setTimeout(function () {
            window.location.href = "success.html";
        }, 2000);

    });

});

// SHOW MESSAGE FUNCTION
function showMessage(msg, type) {

    $("#alertBox").html(`
        <div class="alert alert-${type} alert-dismissible fade show" role="alert">
            ${msg}
            <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
        </div>
    `);
}

// LOAD ORDER SUMMARY
function loadOrderSummary() {

    let cart = getCart();

    let html = "";
    let total = 0;

    // ✅ EMPTY CART
    if (cart.length === 0) {

        $("#orderSummary").html(`
            <li class="list-group-item text-center text-muted">
                Cart is empty 🛒
            </li>
        `);

        $("#orderTotal").text(0);

        // ✅ ADD YOUR CODE HERE (disable button)
        $("#checkoutForm button").prop("disabled", true);

        return;
    }

    // ✅ ENABLE BUTTON IF CART HAS ITEMS
    $("#checkoutForm button").prop("disabled", false);

    cart.forEach(function (item) {

        let qty = item.qty || 1;

        total += item.price * qty;

        html += `
        <li class="list-group-item d-flex justify-content-between align-items-center">
            ${item.name} (x${qty})
            <span>₹${item.price * qty}</span>
        </li>
        `;
    });

    $("#orderSummary").html(html);
    $("#orderTotal").text(total);
}