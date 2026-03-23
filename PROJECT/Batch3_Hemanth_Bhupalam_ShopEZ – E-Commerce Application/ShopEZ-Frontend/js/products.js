// ================= INIT =================

// Run when page loads
$(document).ready(function () {

    loadProducts();

    // Search + Price Filter
    $("#searchBox, #priceFilter").on("keyup change", function () {
        loadProducts(currentCategory);
    });

    // Category Buttons
    $(".category-btn").click(function () {

        currentCategory = $(this).data("category");

        $(".category-btn")
            .removeClass("btn-primary")
            .addClass("btn-outline-primary");

        $(this)
            .removeClass("btn-outline-primary")
            .addClass("btn-primary");

        loadProducts(currentCategory);
    });

});

// Default category
let currentCategory = "all";


// ================= LOAD PRODUCTS =================

// Load products from JSON and apply filters
function loadProducts(selectedCategory = "all") {

    // ✅ Loading Spinner (UX improvement)
    $("#productList").html(`
        <div class="text-center w-100">
            <div class="spinner-border text-primary"></div>
            <p>Loading products...</p>
        </div>
    `);

    $.getJSON("data/products.json")

        // ✅ SUCCESS
        .done(function (products) {

            // 👉 Home page → show trending products
            if (window.location.pathname.includes("index.html")) {
                let trending = getTrendingProducts(products);
                displayProducts(trending);
                return;
            }

            // Get search + filter values
            let keyword = $("#searchBox").val()?.toLowerCase() || "";
            let price = $("#priceFilter").val();

            // Apply filters
            let filteredProducts = products.filter(function (p) {

                let matchName = p.name.toLowerCase().includes(keyword);

                let matchCategory =
                    selectedCategory === "all" ||
                    p.category === selectedCategory;

                let matchPrice = true;

                if (price === "low") matchPrice = p.price < 5000;
                if (price === "mid") matchPrice = p.price >= 5000 && p.price <= 30000;
                if (price === "high") matchPrice = p.price > 30000;

                return matchName && matchCategory && matchPrice;

            });

            // ✅ No products found UI
            if (filteredProducts.length === 0) {
                $("#productList").html(`
                    <div class="text-center text-muted w-100">
                        <h5>No products found 😢</h5>
                    </div>
                `);
                return;
            }

            displayProducts(filteredProducts);

        })

        // ❌ ERROR HANDLING
        .fail(function () {
            $("#productList").html(`
                <div class="text-center text-danger">
                    Failed to load products ❗
                </div>
            `);
        });
}


// ================= TRENDING =================

// Get top 8 expensive products
function getTrendingProducts(products) {

    let sorted = [...products].sort((a, b) => b.price - a.price);

    return sorted.slice(0, 8);
}


// ================= DISPLAY PRODUCTS =================

// Display product cards
function displayProducts(products) {

    let html = "";

    products.forEach(function (product) {

        html += `
        <div class="col-lg-3 col-md-4 col-sm-6 col-12">

            <div class="card fade-in mb-4 shadow-sm h-100">
                <img src="${product.image}" class="card-img-top product-img">

                <div class="card-body text-center">

                    <h5>${product.name}</h5>

                    <p class="text-success fw-bold">₹${product.price}</p>

                    <a href="product-details.html?id=${product.id}" 
                       class="btn btn-primary btn-sm me-2">
                        View
                    </a>

                    <button class="btn btn-success btn-sm addCart" 
                            data-id="${product.id}">
                        Add
                    </button>

                </div>

            </div>

        </div>
        `;
    });

    $("#productList").html(html);

    attachEvents();
}


// ================= EVENTS =================

// Attach click events for Add to Cart
function attachEvents() {

    $(".addCart").click(function () {

        let id = $(this).data("id");

        // ✅ Fetch product safely from JSON
        $.getJSON("data/products.json", function (allProducts) {

            let product = allProducts.find(p => p.id == id);

            if (!product) {
                console.error("Product not found");
                return;
            }

            addToCartWithQty(product, 1);

        });

    });

}