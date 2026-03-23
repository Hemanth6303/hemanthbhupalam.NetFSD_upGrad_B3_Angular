// ================= CART FUNCTIONS =================

// Get cart safely from LocalStorage
function getCart() {
    try {
        let cart = JSON.parse(localStorage.getItem("cart"));

        // Return empty array if invalid
        if (!Array.isArray(cart)) return [];

        return cart;

    } catch (error) {
        console.error("Cart parse error:", error);
        localStorage.removeItem("cart");
        return [];
    }
}

// Save cart
function saveCart(cart) {
    localStorage.setItem("cart", JSON.stringify(cart));
}

// Update cart count in navbar
function updateCartCount() {
    let cart = getCart();
    $("#cartCount").text(cart.length);
}


// ================= ADD TO CART =================

// Add product with quantity (safe + optimized)
function addToCartWithQty(product, qty) {

    // Validate product
    if (!product || !product.id) {
        console.error("Invalid product:", product);
        return;
    }

    // Ensure valid quantity
    qty = parseInt(qty) || 1;

    let cart = getCart();

    let existing = cart.find(p => p.id == product.id);

    if (existing) {
        // ✅ Limit max quantity to 10
        existing.qty = Math.min(existing.qty + qty, 10);
    } else {
        let newProduct = { ...product, qty: qty };
        cart.push(newProduct);
    }

    saveCart(cart);
    updateCartCount();

    // Show alert if alertBox exists
    if ($("#alertBox").length) {
        $("#alertBox").html(`
            <div class="alert alert-success alert-dismissible fade show mt-3" role="alert">
                Product added to cart 🛒
                <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
            </div>
        `);
    }
}


// ================= PRODUCT DETAILS =================

// Load product details from JSON
function loadProductDetails() {

    let params = new URLSearchParams(window.location.search);
    let id = params.get("id");

    // Invalid ID
    if (!id) {
        $("#productDetails").html(`
            <div class="text-danger text-center mt-4">
                Invalid product ID ❗
            </div>
        `);
        return;
    }

    // Fetch products
    $.getJSON("data/products.json")

        .done(function (products) {

            let product = products.find(p => p.id == id);

            // Product not found
            if (!product) {
                $("#productDetails").html(`
                    <div class="text-danger text-center mt-4">
                        Product not found ❗
                    </div>
                `);
                return;
            }

            let html = `
            <div class="col-lg-5 col-md-6 col-12">

                <div class="card p-3 text-center shadow">
                    <img src="${product.image}" 
                         class="img-fluid mb-3 rounded" 
                         style="max-height:250px; object-fit:contain;">

                    <h5>${product.name}</h5>

                    <p class="text-muted">${product.description}</p>

                    <h5 class="text-success">₹${product.price}</h5>

                    <!-- Quantity -->
                    <div class="d-flex justify-content-center align-items-center gap-2 mt-3">
                        <button class="btn btn-outline-secondary btn-sm" id="decrease">−</button>
                        <input type="number" id="qty" class="form-control text-center" value="1" min="1" max="10" style="width:80px;">
                        <button class="btn btn-outline-secondary btn-sm" id="increase">+</button>
                    </div>

                    <button class="btn btn-success mt-3" id="add">
                        Add to Cart 🛒
                    </button>

                    <a href="products.html" class="btn btn-outline-primary mt-2">
                        Back
                    </a>

                </div>

            </div>
            `;

            $("#productDetails").html(html);

        })

        .fail(function () {
            $("#productDetails").html(`
                <div class="text-danger text-center mt-4">
                    Failed to load product ❗
                </div>
            `);
        });
}


// ================= EVENT HANDLING =================

// Increase quantity
$(document).on("click", "#increase", function () {
    let qty = parseInt($("#qty").val()) || 1;

    if (qty < 10) {
        $("#qty").val(qty + 1);
    }
});

// Decrease quantity
$(document).on("click", "#decrease", function () {
    let qty = parseInt($("#qty").val()) || 1;

    if (qty > 1) {
        $("#qty").val(qty - 1);
    }
});

// Add to cart click
$(document).on("click", "#add", function () {

    let qty = parseInt($("#qty").val());

    if (isNaN(qty) || qty < 1) qty = 1;
    if (qty > 10) qty = 10;

    $("#qty").val(qty);

    // Get product ID from URL again (safe approach)
    let params = new URLSearchParams(window.location.search);
    let id = params.get("id");

    $.getJSON("data/products.json", function (products) {

        let product = products.find(p => p.id == id);

        if (!product) {
            console.error("Product not found");
            return;
        }

        addToCartWithQty(product, qty);

    });

});


// ================= INIT =================

// Run on page load
$(document).ready(function () {
    updateCartCount();
    loadProductDetails();
});